using Seguricel3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    public class GeneralController : BaseController
    {
        // GET: General
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
        [HttpPost]
        public JsonResult GetContratosByPais(string Id)
        {
            if (Id != "")
            {
                int IdPais = int.Parse(Id);
                IEnumerable<SelectListItem> Contratos = ClasesVarias.GetContratosByPais(IdPais);

                return Json(new SelectList(Contratos, "Value", "Text"));
            }
            else
            {
                return Json(new SelectList("", "Value", "Text"));
            }
        }
    }
}