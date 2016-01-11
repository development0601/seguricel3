using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguricel3;
using Seguricel3.Helpers;
using Seguricel3.Models;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class DispositivosController : Controller
    {
        // GET: Dispositivos
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index()
        {
            // esto valida si hay una sesion iniciada, de no ser así redirecciona a la página de inicio
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");
            //Coloca el titulo en el navegador
            ViewBag.Title = Resources.AdminIndexResource.PageTitle;
            //coloca el titulo del menú seleccionado
            //ViewBag.PageHeader = Resources.DispositivoResource.DispositivoHeaderPage;
            //carga el menú segun el perfil del usuario
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            //carga los contratos en el dropdownlist 
            ViewBag.SelectContratos = ClasesVarias.GetContratos();

            List<DispositivoViewModels> data = new List<DispositivoViewModels>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Contrato_Dispositivo
                        select new DispositivoViewModels
                        {
                            Serial = d.Serial,
                            TipoDispositivo = d.IdTipoDispositivo.ToString(),
                            Firmware = d.IdFirmwareActivo.ToString()
                        }).ToList();
            }

            return View(data);
        }

        //POST: Dispositivo
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Create()
        {
            // esto valida si hay una sesion iniciada, de no ser así redirecciona a la página de inicio
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");
            //Coloca el titulo en el navegador
            ViewBag.Title = Resources.AdminIndexResource.PageTitle;
            //coloca el titulo del menú seleccionado
            ViewBag.PageHeader = Resources.DispositivoResource.createDispositivoHeaderPage;


            return View();
        }
    }
}