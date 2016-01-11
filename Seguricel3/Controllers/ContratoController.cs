using Seguricel3.Helpers;
using Seguricel3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{

    public struct resultCreateAdmistadora
    {
        public bool success { get; set; }
        public Guid IdAdministradora { get; set; }
        public IEnumerable<SelectListItem> Administradoras { get; set; }
    }

    [CustomAuthorize]
    public class ContratoController : BaseController
    {
        struct returnTipoCargoJunta
        {
            public IEnumerable<SelectListItem> TiposCargoJunta { get; set; }
            public string newID { get; set; }
        };

        // GET: Contratos
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratosResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.HeaderPage;
            ViewBag.TableHeader = Resources.ContratosResource.TableHeader;
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();

            List<Models.ContratoViewModel> contratos = new List<Models.ContratoViewModel>();
            string _Culture = Thread.CurrentThread.CurrentCulture.ToString();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                contratos = (from d in db.Contrato
                             select new Models.ContratoViewModel
                             {
                                 CodigoPostal = d.CodigoPostal,
                                 Contratante = d.Contratante,
                                 Direccion = d.Direccion,
                                 EstadoContrato = db.EstadoContrato.Where(x => x.Culture == _Culture && x.IdEstadoContrato == d.IdEstadoContrato).FirstOrDefault().Nombre,
                                 FechaContrato = d.FechaContrato,
                                 IdAdministradora = d.IdAdministradora,
                                 IdCiudad = d.IdCiudad,
                                 IdContrato = d.IdContrato,
                                 IdEstado = d.IdEstado,
                                 IdEstadoContrato = d.IdEstadoContrato,
                                 IdPais = d.IdPais,
                                 IdTipoContrato = d.IdTipoContrato,
                                 NombreCompleto = d.NombreCompleto,
                                 NroContrato = d.NroContrato.ToString(),
                                 RegistroFiscal = d.RegistroFiscal,
                                 TipoContrato = db.TipoContrato.Where(x => x.Culture == _Culture && x.IdTipoContrato == d.IdTipoContrato).FirstOrDefault().Nombre,
                                 UbicacionGeografica = d.UbicacionGeografica
                             }).ToList();
            }
            return View(contratos);
        }

        // GET: Contratos/Create
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Create()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;
            ContratoViewModel Model = new ContratoViewModel();
            Model.PaisesDisponibles = ClasesVarias.GetPaises();
            Model.Estados = new SelectList(string.Empty, "Value", "Text");
            Model.Ciudades = new SelectList(string.Empty, "Value", "Text");
            Model.EstadosContrato = new SelectList(string.Empty, "Value", "Text");
            Model.Administradoras = new SelectList(string.Empty, "Value", "Text");
            Model.TiposContrato = new SelectList(string.Empty, "Value", "Text");
            Model.MaximoInvitados = 0;
            Model.MaximoSecundarios = 99;
            Model.MaximoPuestosFijos = 0;
            Model.MaximoPuestosVisitantes = 0;
            Model.FechaContrato = DateTime.UtcNow.AddHours(User.HoursTimeZone).AddMinutes(User.MinutesTimeZone);

            return View(Model);
        }
        [HttpPost]
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
                    try {
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
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetNroContrato(string IdP, string IdTC)
        {
            int IdPais = int.Parse(IdP);
            int IdTipoContrato = int.Parse(IdTC);

            string nroContrato = ClasesVarias.GetNroContrato(IdPais, IdTipoContrato);

            return Json(nroContrato);
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
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetTiposContrato(string IdP)
        {
            int IdPais = int.Parse(IdP);

            string _Culture = ClasesVarias.GetPaisCulture(IdPais);
            IEnumerable<SelectListItem> TiposContrato = ClasesVarias.GetTiposContrato(_Culture);

            return Json(new SelectList(TiposContrato, "Value", "Text"));
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetAdministradoras(string IdP)
        {
            int IdPais = int.Parse(IdP);

            IEnumerable<SelectListItem> Administradoras = ClasesVarias.GetAdministradoras(IdPais);

            return Json(new SelectList(Administradoras, "Value", "Text"));
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetEstadosContrato(string IdP)
        {
            int IdPais = int.Parse(IdP);

            IEnumerable<SelectListItem> EstadosContrato = ClasesVarias.GetEstadosContrato(IdPais);

            return Json(new SelectList(EstadosContrato, "Value", "Text"));
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Edit(Guid IdContrato)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratosResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.EditHeaderPage;
            ContratoViewModel Model = new ContratoViewModel();

            string Culture = Session["Culture"].ToString();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Model = (from d in db.Contrato
                         where d.IdContrato == IdContrato
                         select new ContratoViewModel
                         {
                             AccesoDactilar = d.AccesoDactilar,
                             AccesoTelefonico = d.AccesoTelefonico,
                             AlarmaSilente = d.AlarmaSilente,
                             AutoGestion = d.AutoGestion_Aptos,
                             CodigoPostal = d.CodigoPostal,
                             CondominioVirtual = d.CondominioVirtual,
                             ContraseñaCorreoComunidad = d.ContraseñaCorreoComunidad,
                             Contratante = d.Contratante,
                             ContraseñaCorreoJC = d.ContraseñaCorreoJC,
                             ControlAscensores = d.ControlAscensores,
                             ControlEstacionamiento = d.ControlEstacionamiento,
                             CorreoElectronicoComunida = d.CorreoElectronicoComunida,
                             CorreoElectronicoJunta = d.CorreoElectronicoJunta,
                             Direccion = d.Direccion,
                             EmergenciaVecinal = d.EmergenciaVecinal,
                             FechaContrato = d.FechaContrato,
                             IdAdministradora = d.IdAdministradora,
                             IdCiudad = d.IdCiudad,
                             IdContrato = d.IdContrato,
                             IdEstado = d.IdEstado,
                             IdEstadoContrato = d.IdEstadoContrato,
                             IdPais = d.IdPais,
                             IdRedMiwi = d.IdRedMiwi,
                             IdTipoContrato = d.IdTipoContrato,
                             ImagenEdificio = d.ImagenEdificio,
                             Latitud = d.UbicacionGeografica.Latitude.ToString(),
                             Longitud = d.UbicacionGeografica.Longitude.ToString(),
                             MaximoInvitados = d.MaximoInvitados,
                             MaximoPuestosFijos = d.MaximoPuestosFijos,
                             MaximoPuestosVisitantes = d.MaximoPuestosVisitantes,
                             MaximoSecundarios = d.MaximoSecundarios,
                             NombreCompleto = d.NombreCompleto,
                             NroContrato = d.NroContrato,
                             PuertoPOPGeneral = d.PuertoPOPGeneral,
                             PuertoPOPJC = d.PuertoPOPJC,
                             PuertoSMTPGeneral = d.PuertoSMTPGeneral,
                             PuertoSMTPJC = d.PuertoSMTPJC,
                             RegistroFiscal = d.RegistroFiscal,
                             ServidorPOPGeneral = d.ServidorPOPGeneral,
                             ServidorSMTPGeneral = d.ServidorSMTPGeneral,
                             ServidorPOPJC = d.ServidorPOPJC,
                             ServidorSMTPJC = d.ServidorSMTPJC,
                             UbicacionGeografica = d.UbicacionGeografica
                         }).FirstOrDefault();
            }
            Model.PaisesDisponibles = ClasesVarias.GetPaises();
            Model.Estados = ClasesVarias.GetEstados(Model.IdPais);
            Model.Ciudades = ClasesVarias.GetCiudades(Model.IdPais, Model.IdEstado);
            Model.EstadosContrato = ClasesVarias.GetEstadosContrato(Model.IdPais);
            Model.Administradoras = ClasesVarias.GetAdministradoras(Model.IdPais);
            Model.TiposContrato = ClasesVarias.GetTiposContrato(Culture);

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Edit(ContratoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.EditHeaderPage;

            if (ModelState.IsValid)
            {

                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato dataContrato = db.Contrato.Where(x => x.IdContrato == model.IdContrato).FirstOrDefault();
                    dataContrato.AccesoDactilar = model.AccesoDactilar;
                    dataContrato.AccesoTelefonico = model.AccesoTelefonico;
                    dataContrato.AlarmaSilente = model.AlarmaSilente;
                    dataContrato.AutoGestion_Aptos = model.AutoGestion;
                    dataContrato.CodigoPostal = model.CodigoPostal;
                    dataContrato.ContraseñaCorreoComunidad = string.Empty;
                    dataContrato.ContraseñaCorreoJC = string.Empty;
                    dataContrato.CorreoElectronicoComunida = string.Empty;
                    dataContrato.CorreoElectronicoJunta = string.Empty;
                    dataContrato.CondominioVirtual = model.CondominioVirtual;
                    dataContrato.Contratante = model.Contratante;
                    dataContrato.ControlAscensores = model.ControlAscensores;
                    dataContrato.ControlEstacionamiento = model.ControlEstacionamiento;
                    dataContrato.Direccion = model.Direccion;
                    dataContrato.EmergenciaVecinal = model.EmergenciaVecinal;
                    dataContrato.FechaContrato = model.FechaContrato;
                    dataContrato.IdAdministradora = model.IdAdministradora;
                    dataContrato.IdCiudad = model.IdCiudad;
                    dataContrato.IdEstado = model.IdEstado;
                    dataContrato.IdEstadoContrato = model.IdEstadoContrato;
                    dataContrato.IdPais = model.IdPais;
                    dataContrato.IdTipoContrato = model.IdTipoContrato;
                    dataContrato.ImagenEdificio = model.ImagenEdificio;
                    dataContrato.MaximoInvitados = model.MaximoInvitados;
                    dataContrato.MaximoPuestosFijos = model.MaximoPuestosFijos;
                    dataContrato.MaximoPuestosVisitantes = model.MaximoPuestosVisitantes;
                    dataContrato.MaximoSecundarios = model.MaximoSecundarios;
                    dataContrato.NombreCompleto = model.NombreCompleto;
                    dataContrato.NroContrato = model.NroContrato;
                    dataContrato.NroRedesInstalacion = 1;
                    dataContrato.RegistroFiscal = model.RegistroFiscal;
                    dataContrato.UbicacionGeografica = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud));
                    dataContrato.Vigicel = model.Vigicel;

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
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Delete(Guid IdContrato)
        {

            ContratoViewModel Model = new ContratoViewModel();

            string Culture = Session["Culture"].ToString();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato contrato = (from d in db.Contrato
                                     where d.IdContrato == IdContrato
                                     select d).FirstOrDefault();

                db.Contrato.Remove(contrato);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Show(Guid IdContrato)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratosResource.ShowPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.ShowHeaderPage;
            ContratoViewModel Model = new ContratoViewModel();

            string Culture = Session["Culture"].ToString();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Model = (from d in db.Contrato
                         where d.IdContrato == IdContrato
                         select new ContratoViewModel
                         {
                             AccesoDactilar = d.AccesoDactilar,
                             AccesoTelefonico = d.AccesoTelefonico,
                             AlarmaSilente = d.AlarmaSilente,
                             AutoGestion = d.AutoGestion_Aptos,
                             CodigoPostal = d.CodigoPostal,
                             CondominioVirtual = d.CondominioVirtual,
                             ContraseñaCorreoComunidad = d.ContraseñaCorreoComunidad,
                             Contratante = d.Contratante,
                             ContraseñaCorreoJC = d.ContraseñaCorreoJC,
                             ControlAscensores = d.ControlAscensores,
                             ControlEstacionamiento = d.ControlEstacionamiento,
                             CorreoElectronicoComunida = d.CorreoElectronicoComunida,
                             CorreoElectronicoJunta = d.CorreoElectronicoJunta,
                             Direccion = d.Direccion,
                             EmergenciaVecinal = d.EmergenciaVecinal,
                             FechaContrato = d.FechaContrato,
                             IdAdministradora = d.IdAdministradora,
                             IdCiudad = d.IdCiudad,
                             IdContrato = d.IdContrato,
                             IdEstado = d.IdEstado,
                             IdEstadoContrato = d.IdEstadoContrato,
                             IdPais = d.IdPais,
                             IdRedMiwi = d.IdRedMiwi,
                             IdTipoContrato = d.IdTipoContrato,
                             ImagenEdificio = d.ImagenEdificio,
                             Latitud = d.UbicacionGeografica.Latitude.ToString(),
                             Longitud = d.UbicacionGeografica.Longitude.ToString(),
                             MaximoInvitados = d.MaximoInvitados,
                             MaximoPuestosFijos = d.MaximoPuestosFijos,
                             MaximoPuestosVisitantes = d.MaximoPuestosVisitantes,
                             MaximoSecundarios = d.MaximoSecundarios,
                             NombreCompleto = d.NombreCompleto,
                             NroContrato = d.NroContrato,
                             PuertoPOPGeneral = d.PuertoPOPGeneral,
                             PuertoPOPJC = d.PuertoPOPJC,
                             PuertoSMTPGeneral = d.PuertoSMTPGeneral,
                             PuertoSMTPJC = d.PuertoSMTPJC,
                             RegistroFiscal = d.RegistroFiscal,
                             ServidorPOPGeneral = d.ServidorPOPGeneral,
                             ServidorSMTPGeneral = d.ServidorSMTPGeneral,
                             ServidorPOPJC = d.ServidorPOPJC,
                             ServidorSMTPJC = d.ServidorSMTPJC,
                             UbicacionGeografica = d.UbicacionGeografica
                         }).FirstOrDefault();
            }
            Model.PaisesDisponibles = ClasesVarias.GetPaises();
            Model.Estados = ClasesVarias.GetEstados(Model.IdPais);
            Model.Ciudades = ClasesVarias.GetCiudades(Model.IdPais, Model.IdEstado);
            Model.EstadosContrato = ClasesVarias.GetEstadosContrato(Model.IdPais);
            Model.Administradoras = ClasesVarias.GetAdministradoras(Model.IdPais);
            Model.TiposContrato = ClasesVarias.GetTiposContrato(Culture);

            return View(Model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Contactos(int? IdPais, Guid? IdContrato)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoContactoResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoContactoResource.HeaderPage;

            ContactosViewModel model = new ContactosViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais((IdPais == null ? 0 : (int)IdPais));
            model.showContactos = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.Contratos = ClasesVarias.GetContratosByPais((int)IdPais);

                if (IdContrato != null)
                {
                    model.IdContrato = (Guid)IdContrato;
                    model.showContactos = true;

                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;
                        model.Contactos = new List<ContactoViewModel>();

                        List<Contrato_Contacto> contactos = (from d in db.Contrato_Contacto
                                                             where d.IdContrato == model.IdContrato
                                                             select d).ToList();

                        foreach (Contrato_Contacto d in contactos)
                        {
                            model.Contactos.Add(new ContactoViewModel
                            {
                                CargoJunta = (db.TipoCargoJuntaCondominio.Where(x => x.Culture == _Culture && x.IdCargoJunta == d.IdCargoJunta).FirstOrDefault().Nombre ?? db.TipoCargoJuntaCondominio.Where(x => x.Culture == "en-US" && x.IdCargoJunta == d.IdCargoJunta).FirstOrDefault().Nombre),
                                IdCargoJunta = d.IdCargoJunta,
                                IdContacto = d.IdPersonaContacto,
                                IdContrato = d.IdContrato,
                                IdPais = model.IdPais,
                                Nombre = d.Nombre,
                                TelefonoFijo = int.Parse(d.TelefonoFijo),
                                TelefonoMovil = int.Parse(d.TelefonoMovil)
                            });
                        }
                    }
                }
                else
                {
                    model.showContactos = false;
                    model.Contratos = new SelectList(string.Empty, "Value", "Text");
                    model.Contactos = new List<ContactoViewModel>();
                }
            }

            return View(model);
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
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Contactos(ContactosViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoContactoResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoContactoResource.HeaderPage;

            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais(model.IdPais);

            model.showContactos = false;

            if (model.IdPais > 0)
            {
                if (model.IdContrato != null && model.IdContrato != new Guid())
                {
                    model.showContactos = true;
                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;
                        model.Contactos = new List<ContactoViewModel>();

                        List<Contrato_Contacto> contactos = (from d in db.Contrato_Contacto
                                           where d.IdContrato == model.IdContrato
                                           select d).ToList();

                        foreach (Contrato_Contacto d in contactos) {
                            model.Contactos.Add(new ContactoViewModel
                            {
                                CargoJunta = (db.TipoCargoJuntaCondominio.Where(x => x.Culture == _Culture && x.IdCargoJunta == d.IdCargoJunta).FirstOrDefault().Nombre ?? db.TipoCargoJuntaCondominio.Where(x => x.Culture == "en-US" && x.IdCargoJunta == d.IdCargoJunta).FirstOrDefault().Nombre),
                                IdCargoJunta = d.IdCargoJunta,
                                IdContacto = d.IdPersonaContacto,
                                IdContrato = d.IdContrato,
                                IdPais = model.IdPais,
                                Nombre = d.Nombre,
                                TelefonoFijo = int.Parse(d.TelefonoFijo),
                                TelefonoMovil = int.Parse(d.TelefonoMovil)
                            });
                        }
                    }
                }
                else
                {
                    model.showContactos = false;
                    model.Contactos = new List<ContactoViewModel>();
                }
            }
            else
            {
                model.showContactos = false;
                model.Contactos = new List<ContactoViewModel>();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateContacto(int IdPais, Guid IdContrato)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoContactoResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratoContactoResource.CreateHeaderPage;

            ContactoViewModel Model = new ContactoViewModel();

            Model.CargosJunta = ClasesVarias.GetCargosJunta();
            Model.IdCargoJunta = 0;
            Model.IdContacto = new Guid();
            Model.IdContrato = IdContrato;
            Model.IdPais = IdPais;
            Model.Nombre = string.Empty;
            Model.TelefonoFijo = 0;
            Model.TelefonoMovil = 0;

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateContacto(ContactoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Contacto dataContacto = new Contrato_Contacto
                    {
                        IdContrato = model.IdContrato,
                        IdCargoJunta = model.IdCargoJunta,
                        IdPersonaContacto = Guid.NewGuid(),
                        Nombre = model.Nombre,
                        TelefonoFijo = model.TelefonoFijo.ToString(),
                        TelefonoMovil = model.TelefonoMovil.ToString()
                    };

                    db.Contrato_Contacto.Add(dataContacto);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Contactos", "Contrato", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditContacto(int IdPais, Guid IdContrato, Guid IdContacto)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoContactoResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratoContactoResource.EditHeaderPage;

            ContactoViewModel Model = new ContactoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Contacto contacto = (from d in db.Contrato_Contacto
                                              where d.IdContrato == IdContrato && d.IdPersonaContacto == IdContacto
                                              select d).FirstOrDefault();

                if (contacto != null) {
                    Model = new ContactoViewModel
                    {
                        IdCargoJunta = contacto.IdCargoJunta,
                        IdContacto = contacto.IdPersonaContacto,
                        IdContrato = contacto.IdContrato,
                        Nombre = contacto.Nombre,
                        IdPais = IdPais,
                        TelefonoFijo = int.Parse(contacto.TelefonoFijo),
                        TelefonoMovil = int.Parse(contacto.TelefonoMovil)
                    };
                }
            }
            Model.CargosJunta = ClasesVarias.GetCargosJunta();

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditContacto(ContactoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.EditHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {

                    Contrato_Contacto dataContacto = db.Contrato_Contacto.Where(x => x.IdContrato == model.IdContrato && x.IdPersonaContacto == model.IdContacto).FirstOrDefault();
                    dataContacto.IdCargoJunta = model.IdCargoJunta;
                    dataContacto.Nombre = model.Nombre;
                    dataContacto.TelefonoFijo = model.TelefonoFijo.ToString();
                    dataContacto.TelefonoMovil = model.TelefonoMovil.ToString();

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Contactos", "Contrato", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteContacto(int IdPais, Guid IdContrato, Guid IdContacto)
        {

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Contacto contacto = (from d in db.Contrato_Contacto
                                              where d.IdContrato == IdContrato && d.IdPersonaContacto == IdContacto
                                              select d).FirstOrDefault();

                db.Contrato_Contacto.Remove(contacto);
                db.SaveChanges();
            }

            return RedirectToAction("Contactos", "Contrato", new { IdPais = IdPais, IdContrato = IdContrato });
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public JsonResult GetUltimoNroTipoCargoJunta()
        {
            int NextId = 0;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _culture = Session["Culture"].ToString();
                NextId = (db.TipoCargoJuntaCondominio.Where(x => x.Culture == _culture).Select(x => (int?)x.IdCargoJunta).Max() ?? 0);
            }

            NextId += 1;
            return Json(NextId.ToString());
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public JsonResult AddAdministradora(string Nombre, string strIdPais, string strIdEstado, string strIdCiudad)
        {
            string newGuid = string.Empty;
            int IdPais = int.Parse(strIdPais);
            int IdEstado = int.Parse(strIdEstado);
            int IdCiudad = int.Parse(strIdCiudad);

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Administradora Administradora = new Contrato_Administradora()
                {
                    CodigoPostal = string.Empty,
                    CorreoElectronicoAdministradora = string.Empty,
                    CorreoElectronicoContacto = string.Empty,
                    Direccion = string.Empty,
                    IdAdministradora = Guid.NewGuid(),
                    IdCiudad = IdCiudad,
                    IdEstado = IdEstado,
                    IdPais = IdPais,
                    Nombre = Nombre,
                    NombreContacto = string.Empty,
                    Rif = string.Empty,
                    TelefonoCelular1 = string.Empty,
                    TelefonoCelular2 = string.Empty,
                    TelefonoFax = string.Empty,
                    TelefonoOficina = string.Empty,
                };

                db.Contrato_Administradora.Add(Administradora);
                db.SaveChanges();

            }

            IEnumerable<SelectListItem> Administradoras = ClasesVarias.GetAdministradoras(IdPais);

            return Json(new SelectList(Administradoras, "Value", "Text"));
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public JsonResult AddCargo(string Nombre, string strIdPais)
        {
            int IdPais = int.Parse(strIdPais);

            using (SeguricelEntities db = new SeguricelEntities())
            {
                int NextId = 0;
                NextId = (db.TipoCargoJuntaCondominio.Where(x => x.Culture == User.Culture).Select(x => (int?)x.IdCargoJunta).Max() ?? 0);

                NextId += 1;

                TipoCargoJuntaCondominio tipoCargo = new TipoCargoJuntaCondominio()
                {
                    Culture = User.Culture,
                    IdPais = IdPais,
                    IdCargoJunta = NextId,
                    Nombre = Nombre
                };

                db.TipoCargoJuntaCondominio.Add(tipoCargo);
                db.SaveChanges();

            }

            IEnumerable<SelectListItem> CargosJunta = ClasesVarias.GetCargosJunta();

            return Json(new SelectList(CargosJunta, "Value", "Text"));
        }

    }
}