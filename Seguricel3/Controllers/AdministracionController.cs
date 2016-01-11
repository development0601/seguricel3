using Seguricel3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class AdministracionController : BaseController
    {
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.AdminIndexResource.PageTitle;
            ViewBag.PageHeader = Resources.AdminIndexResource.HeaderPage;
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.EstadisticaDispositivo = new List<Contrato_Dispositivo_Estadistica>();
            ViewBag.MensajesPendientes = new List<Contrato_Mensaje>();

            using (SeguricelEntities db = new SeguricelEntities())
            {

            }

            return View();
        }

    }
}