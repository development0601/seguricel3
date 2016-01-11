using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguricel3.Models;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;

namespace Seguricel3.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
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
                _htmlContent += string.Format("{0}: {1}{2}", Resources.ContactoResource.NombreContactoLabel,  model.NombreContacto, "<br />");
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