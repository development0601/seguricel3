using Seguricel3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class VentasController : BaseController
    {
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.CotizacionResource.PageTitle;
            ViewBag.PageHeader = Resources.CotizacionResource.HeaderPage;
            ViewBag.TableHeader = Resources.CotizacionResource.TableHeader;
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TitleAlarmaSilente = Resources.CotizacionResource.labelAlarmaSilente;
            ViewBag.TitleAccesoTelefonico = Resources.CotizacionResource.labelAccesoTelefono;
            ViewBag.TitleAccesoBiometrico = Resources.CotizacionResource.labelAccesoBiometrico;
            ViewBag.TitleAccesoRFID = Resources.CotizacionResource.labelAccesoRFID;
            ViewBag.TitleControlVigilancia = Resources.CotizacionResource.labelControlVigilancia;

            List<Models.CotizacionViewModel> data = new List<Models.CotizacionViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Cotizacion
                        select new Models.CotizacionViewModel
                        {
                            AccesoBiometrico = d.AccesoBiometrico,
                            AccesoRFID = d.AccesoRFID,
                            AccesoTelefonico = d.AccesoTelefonico,
                            AlarmaSilente = d.AlarmaSilente,
                            ControlVigilancia = d.ControlVigilancia,
                            DescripcionAccesoActual = d.DescripcionAccesoActual,
                            Direccion = d.Direccion,
                            FechaEstadoPropuesta = d.FechaEstadoPropuesta,
                            IdCiudad = d.IdCiudad,
                            IdCotizacion = d.IdCotizacion,
                            IdEstado = d.IdEstado,
                            IdEstadoPropuesta = d.IdEstadoPropuesta,
                            IdPais = d.IdPais,
                            IdTipoPropuesta = d.IdTipoPropuesta,
                            //IdVendedor = d.IdVendedor,
                            Nombre = d.Nombre,
                            NombreEmpresaVigilancia = d.NombreEmpresaVigilancia,
                            NroLocalesComerciales = d.NroLocalesComerciales,
                            NroResidenciasXTorre = d.NroResidenciasXTorre,
                            TotalResidencias = d.TotalResidencias,
                            TotalTorres = d.TotalTorres,
                            VigilanciaContratada = d.VigilanciaContratada
                        }).ToList();
            }

            return View(data);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Create()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            Models.CotizacionViewModel model = new Models.CotizacionViewModel();

            ViewBag.Title = Resources.CotizacionResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.CotizacionResource.CreateHeaderPage;
            model.PaisesDisponibles = ClasesVarias.GetPaises();
            model.Vendedores = ClasesVarias.GetVendedores();
            model.EstadosPropuesta = ClasesVarias.GetEstadosPropuesta();
            model.TiposPropuesta = ClasesVarias.GetTiposPropuesta();

            return View(model);
        }
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        public ActionResult Create(Models.CotizacionViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.CotizacionResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.CotizacionResource.CreateHeaderPage;
            model.PaisesDisponibles = ClasesVarias.GetPaises();
            model.Vendedores = ClasesVarias.GetVendedores();
            model.TiposPropuesta = ClasesVarias.GetTiposPropuesta();

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetEstadosByPais(string Id)
        {
            int IdPais = int.Parse(Id);
            IEnumerable<SelectListItem> Estados = ClasesVarias.GetEstados(IdPais);

            return Json(new SelectList(Estados, "Value", "Text"));
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetCiudadesByPais(string IdP, string IdE)
        {
            int IdPais = int.Parse(IdP);
            int IdEstado = int.Parse(IdE);

            IEnumerable<SelectListItem> Ciudades = ClasesVarias.GetCiudades(IdPais, IdEstado);

            return Json(new SelectList(Ciudades, "Value", "Text"));
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Edit(Guid? Id)
        {
            return View();
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Delete(Guid? Id)
        {
            return View();
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            return View();
        }
    }

}