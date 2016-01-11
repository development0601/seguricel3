using Seguricel3.Helpers;
using Seguricel3.Models;
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
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Administradoras(int? IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.AdministradorasResources.PageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.HeaderPage;
            AdministradorasViewModel model = new AdministradorasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.showAdministradoras = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.showAdministradoras = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Administradoras = (from d in db.Contrato_Administradora
                                           where d.IdPais == IdPais
                                           select new AdministradoraViewModel
                                           {
                                               CodigoPostal = d.CodigoPostal,
                                               CorreoAdministradora = d.CorreoElectronicoAdministradora,
                                               CorreoContacto = d.CorreoElectronicoContacto,
                                               Direccion = d.Direccion,
                                               Id = d.IdAdministradora,
                                               IdCiudad = d.IdCiudad,
                                               IdEstado = d.IdEstado,
                                               IdPais = d.IdPais,
                                               Nombre = d.Nombre,
                                               NombreContacto = d.NombreContacto,
                                               Rif = d.Rif,
                                               TelefonoCelular1 = d.TelefonoCelular1,
                                               TelefonoCelular2 = d.TelefonoCelular2,
                                               TelefonoFax = d.TelefonoFax,
                                               TelefonoOficina = d.TelefonoOficina
                                           }).ToList();
                }
            }
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Administradoras(AdministradorasViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.AdministradorasResources.PageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.HeaderPage;
            model.Paises = ClasesVarias.GetPaises();
            model.showAdministradoras = false;

            if (model.IdPais > 0)
            {
                model.showAdministradoras = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Administradoras = (from d in db.Contrato_Administradora
                                             where d.IdPais == model.IdPais
                                             select new AdministradoraViewModel
                                             {
                                                 CodigoPostal = d.CodigoPostal,
                                                 CorreoAdministradora = d.CorreoElectronicoAdministradora,
                                                 CorreoContacto = d.CorreoElectronicoContacto,
                                                 Direccion = d.Direccion,
                                                 Id = d.IdAdministradora,
                                                 IdCiudad = d.IdCiudad,
                                                 IdEstado = d.IdEstado,
                                                 IdPais = d.IdPais,
                                                 Nombre = d.Nombre,
                                                 NombreContacto = d.NombreContacto,
                                                 Rif = d.Rif,
                                                 TelefonoCelular1 = d.TelefonoCelular1,
                                                 TelefonoCelular2 = d.TelefonoCelular2,
                                                 TelefonoFax = d.TelefonoFax,
                                                 TelefonoOficina = d.TelefonoOficina
                                             }).ToList();
                }
            }
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateAdministradora(int IdPais)
        {
            ViewBag.Title = Resources.AdministradorasResources.CreatePageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.CreateHeaderPage;
            AdministradoraViewModel Model = new AdministradoraViewModel();
            Model.EstadosDisponibles = ClasesVarias.GetEstados(IdPais);
            Model.IdPais = IdPais;
            if (Model.IdEstado > 0)
                Model.Ciudades = ClasesVarias.GetCiudades(Model.IdPais, Model.IdEstado);
            else
                Model.Ciudades = new SelectList(string.Empty, "Value", "Text");

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateAdministradora(AdministradoraViewModel model)
        {
            ViewBag.Title = Resources.AdministradorasResources.CreatePageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Administradora record = new Contrato_Administradora
                    {
                        CodigoPostal = model.CodigoPostal,
                        CorreoElectronicoAdministradora = model.CorreoAdministradora,
                        CorreoElectronicoContacto = model.CorreoContacto,
                        Direccion = model.Direccion,
                        IdCiudad = model.IdCiudad,
                        IdEstado = model.IdEstado,
                        IdPais = model.IdPais,
                        IdAdministradora = Guid.NewGuid(),
                        Nombre = model.Nombre,
                        NombreContacto = model.NombreContacto,
                        Rif = model.Rif,
                        TelefonoCelular1 = model.TelefonoCelular1,
                        TelefonoCelular2 = (model.TelefonoCelular2 == null ? string.Empty : model.TelefonoCelular2),
                        TelefonoFax = (model.TelefonoFax == null ? string.Empty : model.TelefonoFax),
                        TelefonoOficina = model.TelefonoOficina
                    };
                    db.Contrato_Administradora.Add(record);
                    db.SaveChanges();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Administradora " + model.Nombre + "en " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       102000001,
                       "Agregar");

                }
                return RedirectToAction("Administradoras", new { IdPais = model.IdPais});
            }

            model.EstadosDisponibles = ClasesVarias.GetEstados(model.IdPais);
            if (model.IdEstado > 0)
                model.Ciudades = ClasesVarias.GetCiudades(model.IdPais, model.IdEstado);
            else
                model.Ciudades = new SelectList(string.Empty, "Value", "Text");

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditAdministradora(int IdPais, Guid Id)
        {
            ViewBag.Title = Resources.AdministradorasResources.CreatePageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.CreateHeaderPage;
            AdministradoraViewModel model = new AdministradoraViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (from d in db.Contrato_Administradora
                         where d.IdPais == IdPais && d.IdAdministradora == Id
                         select new AdministradoraViewModel
                         {
                             CodigoPostal = d.CodigoPostal,
                             CorreoAdministradora = d.CorreoElectronicoAdministradora,
                             CorreoContacto = d.CorreoElectronicoContacto,
                             Direccion = d.Direccion,
                             Id = d.IdAdministradora,
                             IdCiudad = d.IdCiudad,
                             IdEstado = d.IdEstado,
                             IdPais = d.IdPais,
                             Nombre = d.Nombre,
                             NombreContacto = d.NombreContacto,
                             Rif = d.Rif,
                             TelefonoCelular1 = d.TelefonoCelular1,
                             TelefonoCelular2 = (d.TelefonoCelular2 == null ? string.Empty : d.TelefonoCelular2),
                             TelefonoFax = (d.TelefonoFax == null ? string.Empty : d.TelefonoFax),
                             TelefonoOficina = d.TelefonoOficina
                         }).FirstOrDefault();
            }
            model.EstadosDisponibles = ClasesVarias.GetEstados(model.IdPais);
            if (model.IdEstado > 0)
                model.Ciudades = ClasesVarias.GetCiudades(model.IdPais, model.IdEstado);
            else
                model.Ciudades = new SelectList(string.Empty, "Value", "Text");


            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditAdministradora(AdministradoraViewModel model)
        {
            ViewBag.Title = Resources.AdministradorasResources.CreatePageTitle;
            ViewBag.PageHeader = Resources.AdministradorasResources.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Administradora Administradora = (from d in db.Contrato_Administradora
                                                              where d.IdPais == model.IdPais && d.IdAdministradora == model.Id
                                                              select d).FirstOrDefault();

                    Administradora.CodigoPostal = model.CodigoPostal;
                    Administradora.CorreoElectronicoAdministradora = model.CorreoAdministradora;
                    Administradora.CorreoElectronicoContacto = model.CorreoContacto;
                    Administradora.Direccion = model.Direccion;
                    Administradora.IdCiudad = model.IdCiudad;
                    Administradora.IdEstado = model.IdEstado;
                    Administradora.Nombre = model.Nombre;
                    Administradora.NombreContacto = model.NombreContacto;
                    Administradora.Rif = model.Rif;
                    Administradora.TelefonoCelular1 = model.TelefonoCelular1;
                    Administradora.TelefonoCelular2 = (model.TelefonoCelular2 == null ? string.Empty : model.TelefonoCelular2);
                    Administradora.TelefonoFax = (model.TelefonoFax == null ? string.Empty : model.TelefonoFax);
                    Administradora.TelefonoOficina = model.TelefonoOficina;

                    db.SaveChanges();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Administradora " + model.Nombre + "en " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       102000001,
                       "Actualizar");

                }
                return RedirectToAction("Administradoras", new { IdPais = model.IdPais });
            }

            model.EstadosDisponibles = ClasesVarias.GetEstados(model.IdPais);
            if (model.IdEstado > 0)
                model.Ciudades = ClasesVarias.GetCiudades(model.IdPais, model.IdEstado);
            else
                model.Ciudades = new SelectList(string.Empty, "Value", "Text");

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteAdministradora(int IdPais, Guid Id)
        {

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Administradora Administradora = (from d in db.Contrato_Administradora
                                                          where d.IdPais == IdPais && d.IdAdministradora == Id
                                                          select d).FirstOrDefault();
                string Nombre = Administradora.Nombre;
                db.Contrato_Administradora.Remove(Administradora);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Administradora " + Nombre + "en " + db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   102000001,
                   "Eliminar");

            }

            return RedirectToAction("Administradoras", new { IdPais });
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetEstadosContrato(string Id)
        {
            int IdPais = int.Parse(Id);
            IEnumerable<SelectListItem> EstadosContrato = ClasesVarias.GetEstadosContrato(IdPais);

            return Json(new SelectList(EstadosContrato, "Value", "Text"));
        }
        
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Firmware(int? IdTipoDispositivo)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.FirmResource.PageTitle;
            ViewBag.PageHeader = Resources.FirmResource.HeaderPage;
            FirmwaresViewModel model = new FirmwaresViewModel();
            model.TipoDispositivo = ClasesVarias.GetDispositivos();
            model.showFirmware = false;

            if (IdTipoDispositivo != null)
            {
                model.IdTipoDispositivo = (int)IdTipoDispositivo;
                model.showFirmware = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Firmwares = (from d in db.Firmware
                                             where d.IdTipoDispositivo == IdTipoDispositivo
                                             select new FirmwareViewModel
                                             {
                                                 Version = d.Version,
                                                 Descripcion = d.Descripcion,
                                                 Firmware = d.Firmware1,
                                                 FechaPubilcacion = d.FechaPubilcacion
                                             }).ToList();
                }
            }
            return View(model);
        }

        // GET: Contratos/Create
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateFirmware(int IdTipoDispositivo)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.FirmResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.FirmResource.CreateHeaderPage;
            FirmwareViewModel Model = new FirmwareViewModel();
            Model.IdTipoDispositivo = IdTipoDispositivo;
            /*Model.Estados = new SelectList(string.Empty, "Value", "Text");
            Model.Ciudades = new SelectList(string.Empty, "Value", "Text");
            Model.EstadosContrato = new SelectList(string.Empty, "Value", "Text");
            Model.Administradoras = new SelectList(string.Empty, "Value", "Text");
            Model.TiposContrato = new SelectList(string.Empty, "Value", "Text");
            Model.MaximoInvitados = 0;
            Model.MaximoSecundarios = 99;
            Model.MaximoPuestosFijos = 0;
            Model.MaximoPuestosVisitantes = 0;
            Model.FechaContrato = DateTime.UtcNow.AddHours(User.HoursTimeZone).AddMinutes(User.MinutesTimeZone);
            */
            return View(Model);
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Create(ContratoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato dataContrato = new Contrato
                    {
                        IdContrato = Guid.NewGuid(),
                        AccesoDactilar = model.AccesoDactilar,
                        AccesoTelefonico = model.AccesoTelefonico,
                        AlarmaSilente = model.AlarmaSilente,
                        AutoGestion_Aptos = model.AutoGestion,
                        CodigoPostal = model.CodigoPostal,
                        ContraseñaCorreoComunidad = string.Empty,
                        ContraseñaCorreoJC = string.Empty,
                        CorreoElectronicoComunida = string.Empty,
                        CorreoElectronicoJunta = string.Empty,
                        DiaCorte = 0,
                        CondominioVirtual = model.CondominioVirtual,
                        Contratante = model.Contratante,
                        ControlAscensores = model.ControlAscensores,
                        ControlEstacionamiento = model.ControlEstacionamiento,
                        Direccion = model.Direccion,
                        EmergenciaVecinal = model.EmergenciaVecinal,
                        FechaContrato = model.FechaContrato,
                        IdAdministradora = model.IdAdministradora,
                        IdCiudad = model.IdCiudad,
                        IdEstado = model.IdEstado,
                        IdEstadoContrato = model.IdEstadoContrato,
                        IdPais = model.IdPais,
                        IdRedMiwi = new byte[] { 0 },
                        IdTipoContrato = model.IdTipoContrato,
                        ImagenEdificio = model.ImagenEdificio,
                        MaximoInvitados = model.MaximoInvitados,
                        MaximoPuestosFijos = model.MaximoPuestosFijos,
                        MaximoPuestosVisitantes = model.MaximoPuestosVisitantes,
                        MaximoSecundarios = model.MaximoSecundarios,
                        NombreCompleto = model.NombreCompleto,
                        NroContrato = model.NroContrato,
                        NroRedesInstalacion = 1,
                        RegistroFiscal = model.RegistroFiscal,
                        UbicacionGeografica = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud)),
                        Vigicel = model.Vigicel
                    };

                    db.Contrato.Add(dataContrato);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Index");
            }

            model.PaisesDisponibles = ClasesVarias.GetPaises();
            if (model.IdPais > 0)
            {
                string _Culture = ClasesVarias.GetPaisCulture(model.IdPais);
                model.Estados = ClasesVarias.GetEstados(model.IdPais);
                model.TiposContrato = ClasesVarias.GetTiposContrato(_Culture);
                model.Administradoras = ClasesVarias.GetAdministradoras(model.IdPais);
                model.EstadosContrato = ClasesVarias.GetEstadosContrato(model.IdPais);
            }
            else
            {
                model.Estados = new SelectList(string.Empty, "Value", "Text");
                model.TiposContrato = new SelectList(string.Empty, "Value", "Text");
                model.Administradoras = new SelectList(string.Empty, "Value", "Text");
                model.EstadosContrato = new SelectList(string.Empty, "Value", "Text");
            }

            if (model.IdEstado > 0)
                model.Ciudades = ClasesVarias.GetCiudades(model.IdPais, model.IdEstado);
            else
                model.Ciudades = new SelectList(string.Empty, "Value", "Text");

            return View(model);
        }*/

    }
}