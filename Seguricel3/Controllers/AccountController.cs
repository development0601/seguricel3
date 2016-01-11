using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Seguricel3.Models;
using Newtonsoft.Json;
using System.Web.Security;
using Seguricel3.Helpers;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class AccountController : BaseController
    {

        private Encriptador Encrypt = new Encriptador();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel();
            ViewBag.Title = Resources.LoginResource.PageTitle;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HandleError()]
        public ActionResult Login(LoginViewModel model, string returnUrl)
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
                            } else
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
                                MinutesTimeZone = minZone
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

                            if (dataUsuario.FechaUltimaConexion == null)
                                PrimeraVez = true;

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

        private ActionResult ConectarUsuario(Usuario dataUsuario, SeguricelEntities db)
        {
            try {
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

        [SessionExpireFilter]
        [HandleError()]
        public ActionResult Perfil()
        {

            if (User == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.PerfilResource.PageTitle;
            ViewBag.PageHeader = Resources.PerfilResource.HeaderPage;
            ViewBag.ShowMenu = false;
            FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
            CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);


            PerfilViewModel model = new PerfilViewModel()
            {
                ConfirmPassword = string.Empty,
                Apodo = string.Empty,
                Email = serializeModel.Email,
                Password = string.Empty
            };

            return View(model);
        }
        [HandleError()]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult Perfil(PerfilViewModel model)
        {
            ViewBag.Title = Resources.PerfilResource.PageTitle;
            ViewBag.PageHeader = Resources.PerfilResource.HeaderPage;
            ViewBag.ShowMenu = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
            CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Usuario _dataUsuario = (from u in db.Usuario
                                        where u.IdUsuario == serializeModel.Id
                                        select u).FirstOrDefault();

                if (_dataUsuario != null)
                {

                    Encrypt.InicioClaves("53gur1cel!n37", "4LC_C0MUN1C4C10N35@S3GUR1C3L!N37", "53gur1c3l!4lcC0mun1c4c10n35@s3gur1c3lgm41l!c0m", 5);
                    string encryptedPassword = Encrypt.Encriptar(model.Password, Encriptador.HasAlgorimt.SHA1, Encriptador.Keysize.KS256);

                    _dataUsuario.ClaveUsuario = encryptedPassword;
                    _dataUsuario.Email = model.Email;
                    _dataUsuario.Pregunta1 = model.Pregunta1;
                    _dataUsuario.Respuesta1 = model.Respuesta1;
                    _dataUsuario.Pregunta2 = model.Pregunta2;
                    _dataUsuario.Respuesta2 = model.Respuesta2;
                    _dataUsuario.Pregunta3 = model.Pregunta3;
                    _dataUsuario.Respuesta3 = model.Respuesta3;

                    return ConectarUsuario(_dataUsuario, db);
                }
            }

            return View(model);
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //    var user = await UserManager.FindByNameAsync(model.Email);
                //    if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                //    {
                //        // No revelar que el usuario no existe o que no está confirmado
                //        return View("ForgotPasswordConfirmation");
                //    }

                //    // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                //    // Enviar correo electrónico con este vínculo
                //    // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                //    // await UserManager.SendEmailAsync(user.Id, "Restablecer contraseña", "Para restablecer la contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
                //    // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

                //// Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
                return View(model);
        }
        //
        // POST: /Account/LogOff
        [HandleError()]
        [SessionExpireFilter]
        public ActionResult LogOff()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            try
            {
                if (User != null)
                {
                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        Usuario Usuario = (from d in db.Usuario
                                           where d.IdUsuario == User.Id
                                            select d).FirstOrDefault();

                        if (Usuario != null)
                        {
                            Usuario.IdEstadoUsuario = 1;
                            Usuario.FechaCambioEstatus = DateTime.UtcNow;
                            db.SaveChanges();
                        }
                    }
                }
            }
            finally
            {
                try
                {
                    FormsAuthentication.SignOut();
                    TempData["Expired"] = "1";
                }
                catch { }
            }
            return RedirectToAction("Index", "Home");
        }
        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}