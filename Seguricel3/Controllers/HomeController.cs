using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguricel3.Models;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;


using System.Globalization;

using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Newtonsoft.Json;
using System.Web.Security;
using Seguricel3.Helpers;

using System.Data.Entity.Validation;

namespace Seguricel3.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HandleError()]
        public ActionResult Checklogin(LoginViewModel model, string returnUrl)
        {
            ViewBag.Title = Resources.LoginResource.PageTitle;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            Encriptador Encrypt = new Encriptador();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Encrypt.InicioClaves("53gur1cel!n37", "4LC_C0MUN1C4C10N35@S3GUR1C3L!N37", "53gur1c3l!4lcC0mun1c4c10n35@s3gur1c3lgm41l!c0m", 5);
                string encryptedPassword = Encrypt.Encriptar(model.Password, Encriptador.HasAlgorimt.SHA1, Encriptador.Keysize.KS256);

                Usuario dataUsuario = (from u in db.Usuario
                                       where (u.CodigoUsuario == model.Email | u.Email == model.Email) && u.ClaveUsuario == encryptedPassword
                                       select u).FirstOrDefault();

                if (dataUsuario != null)
                {
                    switch ((eEstadoUsuario)dataUsuario.IdEstadoUsuario)
                    {
                        case eEstadoUsuario.Conectado:
                        case eEstadoUsuario.Activo:
                            string[] utz = model.UserTimeZone.Split(':');
                            int hourZone;
                            int minZone;
                            if (utz.Length <= 0)
                            {
                                hourZone = 0;
                                minZone = 0;
                            }
                            else
                            {
                                hourZone = int.Parse(utz[0]);
                                minZone = int.Parse(utz[1]);
                            }

                            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel()
                            {
                                Email = dataUsuario.Email,
                                Estado = (eEstadoUsuario)dataUsuario.IdEstadoUsuario,
                                Id = dataUsuario.IdUsuario,
                                FechaUltimaConexion = DateTime.UtcNow,
                                Name = dataUsuario.Nombre,
                                IdTipoUsuario = dataUsuario.IdTipoUsuario,
                                HoursTimeZone = hourZone,
                                MinutesTimeZone = minZone,
                                Culture = Request.UserLanguages[0],
                                DefaultCulture = "es-VE"
                            };

                            string _jsonUserData = JsonConvert.SerializeObject(serializeModel);
                            FormsAuthenticationTicket authTicket =
                                new FormsAuthenticationTicket(1, serializeModel.Email,
                                    DateTime.UtcNow.AddHours(-4).AddMinutes(-30),
                                    DateTime.UtcNow.AddHours(-4).AddMinutes(-15),
                                    false, _jsonUserData);
                            string encTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            bool PrimeraVez = false;

                            /*if (dataUsuario.FechaUltimaConexion == null)
                                PrimeraVez = true;*/
                            PrimeraVez = dataUsuario.PrimeraVez;

                            Response.Cookies.Add(faCookie);
                            Session["user"] = encTicket;

                            if (PrimeraVez)
                                return RedirectToAction("Perfil", "Account");
                            else
                            {
                                return ConectarUsuario(dataUsuario, db);
                            }
                        case eEstadoUsuario.Inactivo:
                            ModelState.AddModelError("", Resources.LoginResource.LoginFailedMessageInactivo);
                            break;
                        case eEstadoUsuario.Bloqueado:
                            ModelState.AddModelError("", Resources.LoginResource.LoginFailedMessageBloqueado);
                            break;
                        default:
                            ModelState.AddModelError("", Resources.LoginResource.LoginFailedMessage);
                            break;
                    }
                }
                else
                {
                    ModelState.AddModelError("", Resources.LoginResource.LoginFailedMessage);
                }
            }
            return View(model);

        }

        public ActionResult ForgotPassword(LoginViewModel model)
        {
            
            return RedirectToAction("ForgotPassword", "Account");
        }

        private ActionResult ConectarUsuario(Usuario dataUsuario, SeguricelEntities db)
        {
            try
            {
                dataUsuario.IdEstadoUsuario = (int)eEstadoUsuario.Conectado;
                dataUsuario.FechaUltimaConexion = DateTime.UtcNow;
                dataUsuario.FechaCambioEstatus = DateTime.UtcNow;

                Usuario_Bitacora newBitacora = new Usuario_Bitacora()
                {
                    Accion = "Ingresando al Sistema",
                    DireccionIP_Privada = ClasesVarias.GetLocalIPAddress(),
                    DireccionIP_Publica = ClasesVarias.GetPublicIPAddress(),
                    FechaRegistro = DateTime.UtcNow,
                    IdUsuario = dataUsuario.IdUsuario,
                    IdBitacora = Guid.NewGuid(),
                    Observacion = ""
                };
                db.Usuario_Bitacora.Add(newBitacora);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

            if (Request.UserLanguages != null && Request.UserLanguages.Length > 0)
                Session["Culture"] = Request.UserLanguages[0];
            else
                Session["Culture"] = "en-US";

            switch ((eTipoUsuario)dataUsuario.IdTipoUsuario)
            {
                case eTipoUsuario.Instalador:
                    return RedirectToAction("Index", "Instalacion");
                case eTipoUsuario.Atención_Cliente:
                    return RedirectToAction("Index", "Atencion");
                case eTipoUsuario.Administrador_Sistema:
                case eTipoUsuario.Administrador:
                    return RedirectToAction("Index", "Administracion");
                case eTipoUsuario.Vendedor:
                    return RedirectToAction("Index", "Ventas");
                case eTipoUsuario.Administradora:
                    return RedirectToAction("Index", "Administradora");
                case eTipoUsuario.Firmware:
                    return RedirectToAction("Index", "Firmware");
                case eTipoUsuario.Franquiciado:
                    return RedirectToAction("Index", "Franquicia");
                case eTipoUsuario.Software:
                    return RedirectToAction("Index", "Software");
                default:
                    return RedirectToAction("Index", "Cliente");
            }
        }

        public ActionResult Solucion()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            ContactoCondominioModel Contacto = new ContactoCondominioModel();
            ViewBag.Title = Resources.HomeResource.AppTitle;
            return View(Contacto);
        }
        [HttpPost]
        public ActionResult Contacto(ContactoCondominioModel model)
        {
            if (ModelState.IsValid)
            {
                BaseDatosSQL.GuardarContacto(model);
                SendEmail Email = new SendEmail();
                Email.DE("SEGURICEL® <Seguricel@Seguricel.com>");
                Email.PARA("Info@Seguricel.com");
                Email.ASUNTO("Contacto recibido desde SEGURICEL®");

                string path = Server.MapPath(@"../Imagenes/logo_nuevo_small.png");
                LinkedResource logo = new LinkedResource(path, MediaTypeNames.Image.Gif);
                logo.ContentId = "logo";

                string _htmlContent = string.Empty;
                _htmlContent = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>";
                _htmlContent += "<html xmlns='http://www.w3.org/1999/xhtml'>";
                _htmlContent += "<head>";
                _htmlContent += "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />";
                _htmlContent += "<title>Solicitudes para el Salón de Fiestas</title>";
                _htmlContent += "</head>";
                _htmlContent += "<body style='font-family: Arial, Helvetica, sans-serif;";
                _htmlContent += "font-size: 9pt; color: #666'>";
                _htmlContent += "<table cellpadding='2' cellspacing='0' style='width:100%;'>";
                _htmlContent += "<tr>";
                _htmlContent += "<td align='center' style='font-family:Arial; font-size:12pt;'>";
                _htmlContent += "<table cellpadding='0' cellspacing='0' width='700px'>";
                _htmlContent += "<tr>";
                _htmlContent += "<td align='left' style='width:10%;background-color: #E6E6E6; '>";
                _htmlContent += "<img src=\"cid:Pic1\" alt='Seguricel' />";
                _htmlContent += "</td>";
                _htmlContent += "<td align='center' style='width:90%; font-size:18pt; font-weight:bold; color:Navy; vertical-align:bottom;background-color: #E6E6E6; '>";
                _htmlContent += "Contacto recibido desde SEGURICEL®</td>";
                _htmlContent += "</tr>";
                _htmlContent += "<tr>";
                _htmlContent += "<td colspan='2' align='left' style='text-align:justify; padding: 10px 2px 0px 15px;'>";
                _htmlContent += model.ContactoHeader;
                _htmlContent += "</td>";
                _htmlContent += "</tr>";
                _htmlContent += "<tr>";
                _htmlContent += "<td colspan='2' align='left' style='text-align:justify; padding: 10px 2px 0px 15px; font-weight:bold;'>";
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.NombreContactoLabel, model.NombreContacto, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.EmailContactoLabel, model.EmailContacto, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.TelefonoLocalContactoLabel, model.TelefonoLocalContacto, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.TelefonoMovilContactoLabel, model.TelefonoMovilContacto, "<br />");
                _htmlContent += "</td>";
                _htmlContent += "</tr>";
                _htmlContent += "<tr>";
                _htmlContent += "<td colspan='2' align='left' style='text-align:justify; padding: 10px 2px 0px 15px;'>";
                _htmlContent += model.ResidenciaHeader;
                _htmlContent += "</td>";
                _htmlContent += "</tr>";
                _htmlContent += "<tr>";
                _htmlContent += "<td colspan='2' align='left' style='text-align:justify; padding: 10px 2px 0px 15px; font-weight:bold;'>";
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.NombreResidenciaLabel, model.NombreResidencia, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.NroViviendasLabel, model.CantidadViviendas, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.NombreUrbanizacionLabel, model.NombreUrbanizacion, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.PaisLabel, model.GetNombrePais, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.EstadoLabel, model.GetNombreEstado, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.CiudadLabel, model.GetNombreCiudad, "<br />");

                if (model.OpcionesEnterar != 0)
                    _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.OpcionEnterarLabel, model.OpcionesEnterarString, "<br />");
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.ComentarioLabel, model.Comentario, "<br />");
                _htmlContent += "</td>";
                _htmlContent += "</tr>";
                _htmlContent += "</table>";
                _htmlContent += "</td>";
                _htmlContent += "</tr>";
                _htmlContent += "</table>";
                _htmlContent += "</body>";
                _htmlContent += "</html>";

                StringBuilder sb = new StringBuilder(_htmlContent);
                Email.CUERPO_EMAIL(_htmlContent);
                Email.TIPO_VISTA_EMAIL(TipoVistaEmail.HTML);
                Email.PRIORIDAD_ENTREGA(PrioridadEntrega.ALTA);
                Email.IMG = logo;
                // Se usa el login y password de Seguricel
                Email.CREDENCIALES(System.Configuration.ConfigurationManager.AppSettings["LoginCorreoSeguricel"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordCoreoSeguricel"].ToString());
                Email.SERVIDOR_SMTP(System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString());
                Email.NRO_PUERTO(System.Configuration.ConfigurationManager.AppSettings["NRO_PUERTO"].ToString());
                Email.HABILITO_Ssl(true);
                Email.USA_CREDENCIALES_POR_DEFECTO(false);
                Email.Enviar();

                model = new ContactoCondominioModel();
                return RedirectToAction("Index");
            }

            ViewBag.Title = Resources.HomeResource.AppTitle;
            if (model.Estado > 0 && (model.Estados == null || model.Estados.Count == 0))
            {
                var Estados = BaseDatosSQL.GetEstados(model.Pais);
                model.Estados = new SelectList(Estados, "Value", "Text").ToList();
            }
            if (model.Piso_Estado_Ciudad > 0 && (model.Ciudades == null || model.Ciudades.Count == 0))
            {
                var Ciudades = BaseDatosSQL.GetCiudades(model.Pais, model.Estado);
                model.Ciudades = new SelectList(Ciudades, "Value", "Text").ToList();
            }
            return View(model);
        }

        public JsonResult GetEstadosByPais(string IdPais)
        {
            if (string.IsNullOrEmpty(IdPais))
            {
                string Mensaje = string.Format("{0} en GetEstadosByPais", Resources.ContactoResource.ParameterExceptionMessage1);
                throw new ArgumentNullException(Mensaje);
            }
            long Id = 0;
            bool isValid = long.TryParse(IdPais, out Id);
            var Estados = BaseDatosSQL.GetEstados(Id);
            return Json(new SelectList(Estados, "Value", "Text"));
        }
        public JsonResult GetCiudadesByEstado(string IdPais, string IdEstado)
        {
            if (string.IsNullOrEmpty(IdPais) || string.IsNullOrEmpty(IdEstado))
            {
                string Mensaje = string.Format("{0} en GetCiudadesByEstado", Resources.ContactoResource.ParameterExceptionMessage1);
                throw new ArgumentNullException(Mensaje);
            }
            long idPais = 0;
            long idEstado = 0;
            bool isValid = long.TryParse(IdPais, out idPais);
            if (isValid)
                isValid = long.TryParse(IdEstado, out idEstado);
            var Ciudades = BaseDatosSQL.GetCiudades(idPais, idEstado);
            return Json(new SelectList(Ciudades, "Value", "Text"));
        }

        public ActionResult Company()
        {
            return View();
        }
        public ActionResult Franquicia()
        {
            return View();
        }
        public ActionResult ContactoFranquicia()
        {
            return View();
        }
    }
}