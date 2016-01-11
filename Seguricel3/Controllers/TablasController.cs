using Newtonsoft.Json;
using Seguricel3.Helpers;
using Seguricel3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class TablasController : BaseController
    {

        [SessionExpireFilter]
        [HandleError]
        public ActionResult TiposAccion()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoAccion;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoAccionPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoAccionHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoAccionTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoAnuncio()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoAnuncio;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoAnuncioPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoAnuncioHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoAnuncioTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoBandeja()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoBandeja;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoBandejaPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoBandejaHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoBandejaTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoCartelera()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoCartelera;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoCarteleraPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoCarteleraHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoCarteleraTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoContacto()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoContacto;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoContactoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoContactoHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoContactoTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoDispositivo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoDispositivo;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoDispositivoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoDispositivoHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoDispositivoTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoMensaje()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoMensaje;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoMensajePageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoMensajeHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoMensajeTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoPersona()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoPersona;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoPersonaPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoPersonaHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoPersonaTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoPropuesta()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoPropuesta;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoPropuestaPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoPropuestaHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoPropuestaTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoTicket()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoTicket;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoTicketPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoTicketHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoTicketTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoUsuario()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoUsuario;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoUsuarioPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoUsuarioHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoUsuarioTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoVehiculo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.TipoTabla = eTipoTabla.TipoVehiculo;

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;

            ViewBag.Title = Resources.TablasResource.TipoVehiculoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.TipoVehiculoHeaderPage;
            ViewBag.TableHeader = Resources.TablasResource.TipoVehiculoTableHeader;

            return View("Index", model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index(int IdPais, eTipoTabla TipoTabla)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = TipoTabla;

            TablasViewModel model = new TablasViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.IdPais = IdPais;
            model.TipoTabla = TipoTabla;
            model.showDatos = true;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.TipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAccionHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAccionTableHeader;

                        model.DatosTabla = (from d in db.TipoAccion
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoAccion,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                            "Elementos de la tabla Tipo Acción",
                            190000006,
                            "Consultar");

                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.TipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAnuncioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAnuncioTableHeader;

                        model.DatosTabla = (from d in db.TipoAnuncio
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoAnuncio,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Anuncio",
                           190000007,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.TipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoBandejaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoBandejaTableHeader;

                        model.DatosTabla = (from d in db.TipoBandeja
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdBandeja,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Bandeja",
                           190000008,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.TipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoCarteleraHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoCarteleraTableHeader;

                        model.DatosTabla = (from d in db.TipoCartelera
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoCartelera,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Cartelera",
                           190000009,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.TipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContactoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContactoTableHeader;

                        model.DatosTabla = (from d in db.TipoContacto
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoContacto,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Contacto",
                           190000010,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.TipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContratoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContratoTableHeader;

                        model.DatosTabla = (from d in db.TipoContrato
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoContrato,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Contrato",
                           190000011,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.TipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoDispositivoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoDispositivoTableHeader;

                        model.DatosTabla = (from d in db.TipoDispositivo
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoDispositivo,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Dispositivo",
                           190000012,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.TipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoMensajeHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoMensajeTableHeader;

                        model.DatosTabla = (from d in db.TipoMensaje
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoMensaje,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Mensaje",
                           190000013,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.TipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPersonaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPersonaTableHeader;

                        model.DatosTabla = (from d in db.TipoPersona
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoPersona,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Persona",
                           190000014,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.TipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPropuestaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPropuestaTableHeader;

                        model.DatosTabla = (from d in db.TipoPropuesta
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoPropuesta,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Propuesta",
                           190000015,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.TipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoTicketHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoTicketTableHeader;

                        model.DatosTabla = (from d in db.TipoTicket
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoTicket,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Ticket",
                           190000016,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.TipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoUsuarioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoUsuarioTableHeader;

                        model.DatosTabla = (from d in db.TipoUsuario
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoUsuario,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Usuario",
                           190000017,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.TipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoVehiculoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoVehiculoTableHeader;

                        model.DatosTabla = (from d in db.TipoVehiculo
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoVehiculo,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Vehículo",
                           190000018,
                           "Consultar");

                        break;
                }
            }
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Index(TablasViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = model.TipoTabla;
            model.Paises = ClasesVarias.GetPaises();
            model.showDatos = true;


            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.TipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAccionHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAccionTableHeader;

                        model.DatosTabla = (from d in db.TipoAccion
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoAccion,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                            "Elementos de la tabla Tipo Acción",
                            190000006,
                            "Consultar");

                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.TipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAnuncioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAnuncioTableHeader;

                        model.DatosTabla = (from d in db.TipoAnuncio
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoAnuncio,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Anuncio",
                           190000007,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.TipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoBandejaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoBandejaTableHeader;

                        model.DatosTabla = (from d in db.TipoBandeja
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdBandeja,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Bandeja",
                           190000008,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.TipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoCarteleraHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoCarteleraTableHeader;

                        model.DatosTabla = (from d in db.TipoCartelera
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoCartelera,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Cartelera",
                           190000009,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.TipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContactoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContactoTableHeader;

                        model.DatosTabla = (from d in db.TipoContacto
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoContacto,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Contacto",
                           190000010,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.TipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContratoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContratoTableHeader;

                        model.DatosTabla = (from d in db.TipoContrato
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoContrato,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Contrato",
                           190000011,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.TipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoDispositivoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoDispositivoTableHeader;

                        model.DatosTabla = (from d in db.TipoDispositivo
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoDispositivo,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Dispositivo",
                           190000012,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.TipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoMensajeHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoMensajeTableHeader;

                        model.DatosTabla = (from d in db.TipoMensaje
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoMensaje,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Mensaje",
                           190000013,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.TipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPersonaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPersonaTableHeader;

                        model.DatosTabla = (from d in db.TipoPersona
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoPersona,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Persona",
                           190000014,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.TipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPropuestaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPropuestaTableHeader;

                        model.DatosTabla = (from d in db.TipoPropuesta
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoPropuesta,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Propuesta",
                           190000015,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.TipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoTicketHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoTicketTableHeader;

                        model.DatosTabla = (from d in db.TipoTicket
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoTicket,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Ticket",
                           190000016,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.TipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoUsuarioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoUsuarioTableHeader;

                        model.DatosTabla = (from d in db.TipoUsuario
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoUsuario,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Usuario",
                           190000017,
                           "Consultar");

                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.TipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoVehiculoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoVehiculoTableHeader;

                        model.DatosTabla = (from d in db.TipoVehiculo
                                            where d.Culture == _Culture
                                            select new TablaGeneralViewModel
                                            {
                                                Id = d.IdTipoVehiculo,
                                                Nombre = d.Nombre,
                                                TipoTabla = model.TipoTabla
                                            }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Elementos de la tabla Tipo Vehículo",
                           190000018,
                           "Consultar");

                        break;
                }
            }
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Create(eTipoTabla tipoTabla, int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablaGeneralViewModel model = new TablaGeneralViewModel();
            model.IdPais = IdPais;
            model.TipoTabla = tipoTabla;

            Nullable<int> NextId = null;

            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAccionHeaderPage;
                        NextId = (db.TipoAccion.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoAccion).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAnuncioHeaderPage;
                        NextId = (db.TipoAnuncio.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoAnuncio).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.CreateTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoBandejaHeaderPage;
                        NextId = (db.TipoBandeja.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdBandeja).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.CreateTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoCarteleraHeaderPage;
                        NextId = (db.TipoCartelera.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoCartelera).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContactoHeaderPage;
                        NextId = (db.TipoContacto.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoContacto).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContactoHeaderPage;
                        NextId = (db.TipoContrato.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoContrato).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoDispositivoHeaderPage;
                        NextId = (db.TipoDispositivo.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoDispositivo).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.CreateTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoMensajeHeaderPage;
                        NextId = (db.TipoMensaje.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoMensaje).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPersonaHeaderPage;
                        NextId = (db.TipoPersona.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoPersona).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPropuestaHeaderPage;
                        NextId = (db.TipoPropuesta.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoPropuesta).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.CreateTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoTicketHeaderPage;
                        NextId = (db.TipoTicket.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoTicket).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.CreateTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoUsuarioHeaderPage;
                        NextId = (db.TipoUsuario.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoUsuario).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoVehiculoHeaderPage;
                        NextId = (db.TipoVehiculo.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoVehiculo).Max() ?? 0);
                        break;
                }
            }

            if (NextId == null)
                NextId = 0;

            NextId += 1;

            model.Id = (int)NextId;

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Create(TablaGeneralViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAccionHeaderPage;
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAnuncioHeaderPage;
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.CreateTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoBandejaHeaderPage;
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.CreateTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoCarteleraHeaderPage;
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContactoHeaderPage;
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoDispositivoHeaderPage;
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.CreateTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoMensajeHeaderPage;
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPersonaHeaderPage;
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPropuestaHeaderPage;
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.CreateTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoTicketHeaderPage;
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.CreateTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoUsuarioHeaderPage;
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoVehiculoHeaderPage;
                        break;
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion TipoAccion = new TipoAccion
                        {
                            Culture = _Culture,
                            IdTipoAccion = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoAccion.Add(TipoAccion);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Acción",
                           190000006,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio TipoAnuncio = new TipoAnuncio
                        {
                            Culture = _Culture,
                            IdTipoAnuncio = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoAnuncio.Add(TipoAnuncio);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla tabla Tipo Anuncio",
                           190000007,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja TipoBandeja = new TipoBandeja
                        {
                            Culture = _Culture,
                            IdBandeja = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoBandeja.Add(TipoBandeja);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Bandeja",
                           190000008,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera TipoCartelera = new TipoCartelera
                        {
                            Culture = _Culture,
                            IdTipoCartelera = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoCartelera.Add(TipoCartelera);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Cartelera",
                           190000009,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoContacto:
                        TipoContacto TipoContacto = new TipoContacto
                        {
                            Culture = _Culture,
                            IdTipoContacto = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoContacto.Add(TipoContacto);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Contacto",
                           190000010,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoContrato:
                        TipoContrato TipoContrato = new TipoContrato
                        {
                            Culture = _Culture,
                            IdTipoContrato = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoContrato.Add(TipoContrato);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Contrato",
                           190000011,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo TipoDispositivo = new TipoDispositivo
                        {
                            Culture = _Culture,
                            IdTipoDispositivo = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoDispositivo.Add(TipoDispositivo);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en de la tabla Tipo Dispositivo",
                           190000012,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje TipoMensaje = new TipoMensaje
                        {
                            Culture = _Culture,
                            IdTipoMensaje = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoMensaje.Add(TipoMensaje);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                          model.Nombre + "en de la tabla Tipo Mensaje",
                           190000013,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoPersona:
                        TipoPersona TipoPersona = new TipoPersona
                        {
                            Culture = _Culture,
                            IdTipoPersona = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoPersona.Add(TipoPersona);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en de la tabla Tipo Persona",
                           190000014,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta TipoPropuesta = new TipoPropuesta
                        {
                            Culture = _Culture,
                            IdTipoPropuesta = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoPropuesta.Add(TipoPropuesta);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en de la tabla Tipo Propuesta",
                           190000015,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoTicket:
                        TipoTicket TipoTicket = new TipoTicket
                        {
                            Culture = _Culture,
                            IdTipoTicket = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoTicket.Add(TipoTicket);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                          model.Nombre + "en la tabla Tipo Ticket",
                           190000016,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario TipoUsuario = new TipoUsuario
                        {
                            Culture = _Culture,
                            IdTipoUsuario = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoUsuario.Add(TipoUsuario);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Usuario",
                           190000017,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo TipoVehiculo = new TipoVehiculo
                        {
                            Culture = _Culture,
                            IdTipoVehiculo = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoVehiculo.Add(TipoVehiculo);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Vehículo",
                           190000018,
                           "Agregar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    default:
                        return View(model);
                }
            }
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Edit(int Id, eTipoTabla tipoTabla, int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablaGeneralViewModel model = new TablaGeneralViewModel();
            model.IdPais = IdPais;
            model.TipoTabla = tipoTabla;

            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.EditTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoAccionHeaderPage;
                        model = (db.TipoAccion.Where(x => x.Culture == _Culture && x.IdTipoAccion == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAccion,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.EditTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoAnuncioHeaderPage;
                        model = (db.TipoAnuncio.Where(x => x.Culture == _Culture && x.IdTipoAnuncio == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAnuncio,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.EditTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoBandejaHeaderPage;
                        model = (db.TipoBandeja.Where(x => x.Culture == _Culture && x.IdBandeja == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdBandeja,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.EditTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoCarteleraHeaderPage;
                        model = (db.TipoAnuncio.Where(x => x.Culture == _Culture && x.IdTipoAnuncio == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAnuncio,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.EditTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoContactoHeaderPage;
                        model = (db.TipoContacto.Where(x => x.Culture == _Culture && x.IdTipoContacto == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoContacto,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.EditTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoDispositivoHeaderPage;
                        model = (db.TipoDispositivo.Where(x => x.Culture == _Culture && x.IdTipoDispositivo == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoDispositivo,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.EditTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoMensajeHeaderPage;
                        model = (db.TipoMensaje.Where(x => x.Culture == _Culture && x.IdTipoMensaje == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoMensaje,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.EditTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoPersonaHeaderPage;
                        model = (db.TipoPersona.Where(x => x.Culture == _Culture && x.IdTipoPersona == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoPersona,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.EditTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoPropuestaHeaderPage;
                        model = (db.TipoPropuesta.Where(x => x.Culture == _Culture && x.IdTipoPropuesta == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoPropuesta,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.EditTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoTicketHeaderPage;
                        model = (db.TipoTicket.Where(x => x.Culture == _Culture && x.IdTipoTicket == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoTicket,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.EditTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoUsuarioHeaderPage;
                        model = (db.TipoUsuario.Where(x => x.Culture == _Culture && x.IdTipoUsuario == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoUsuario,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.EditTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoVehiculoHeaderPage;
                        model = (db.TipoVehiculo.Where(x => x.Culture == _Culture && x.IdTipoVehiculo == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoVehiculo,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Edit(TablaGeneralViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAccionHeaderPage;
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAnuncioHeaderPage;
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.CreateTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoBandejaHeaderPage;
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.CreateTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoCarteleraHeaderPage;
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContactoHeaderPage;
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoDispositivoHeaderPage;
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.CreateTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoMensajeHeaderPage;
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPersonaHeaderPage;
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPropuestaHeaderPage;
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.CreateTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoTicketHeaderPage;
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.CreateTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoUsuarioHeaderPage;
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoVehiculoHeaderPage;
                        break;
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion regTipoAccion = (db.TipoAccion.Where(x => x.IdTipoAccion == model.Id).FirstOrDefault());
                        regTipoAccion.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Acción",
                           190000006,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio regTipoAnuncio = (db.TipoAnuncio.Where(x => x.IdTipoAnuncio == model.Id).FirstOrDefault());
                        regTipoAnuncio.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Anuncio",
                           190000007,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja regTipoBandeja = (db.TipoBandeja.Where(x => x.IdBandeja == model.Id).FirstOrDefault());
                        regTipoBandeja.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Bandeja",
                           190000008,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera regTipoCartelera = (db.TipoCartelera.Where(x => x.IdTipoCartelera == model.Id).FirstOrDefault());
                        regTipoCartelera.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Cartelera",
                           190000009,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoContacto:
                        TipoContacto regTipoContacto = (db.TipoContacto.Where(x => x.IdTipoContacto == model.Id).FirstOrDefault());
                        regTipoContacto.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Contacto",
                           190000010,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoContrato:
                        TipoContrato regTipoContrato = (db.TipoContrato.Where(x => x.IdTipoContrato == model.Id).FirstOrDefault());
                        regTipoContrato.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Contrato",
                           190000011,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo regTipoDispositivo = (db.TipoDispositivo.Where(x => x.IdTipoDispositivo == model.Id).FirstOrDefault());
                        regTipoDispositivo.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Dispositivo",
                           190000012,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje regTipoMensaje = (db.TipoMensaje.Where(x => x.IdTipoMensaje == model.Id).FirstOrDefault());
                        regTipoMensaje.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Mensaje",
                           190000013,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoPersona:
                        TipoPersona regTipoPersona = (db.TipoPersona.Where(x => x.IdTipoPersona == model.Id).FirstOrDefault());
                        regTipoPersona.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Persona",
                           190000014,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta regTipoPropuesta = (db.TipoPropuesta.Where(x => x.IdTipoPropuesta == model.Id).FirstOrDefault());
                        regTipoPropuesta.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Propuesta",
                           190000015,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoTicket:
                        TipoTicket regTipoTicket = (db.TipoTicket.Where(x => x.IdTipoTicket == model.Id).FirstOrDefault());
                        regTipoTicket.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Ticket",
                           190000016,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario regTipoUsuario = (db.TipoUsuario.Where(x => x.IdTipoUsuario == model.Id).FirstOrDefault());
                        regTipoUsuario.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Usuario",
                           190000017,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo regTipoVehiculo = (db.TipoVehiculo.Where(x => x.IdTipoVehiculo == model.Id).FirstOrDefault());
                        regTipoVehiculo.Nombre = model.Nombre;
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           model.Nombre + "en la tabla Tipo Vehículo",
                           190000018,
                           "Actualizar");

                        return RedirectToAction("Index", new { IdPais = model.IdPais, TipoTabla = model.TipoTabla });
                    default:
                        return View(model);
                }
            }

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Delete(int Id, eTipoTabla tipoTabla, int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            string Nombre;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion regTipoAccion = (db.TipoAccion.Where(x => x.Culture == _Culture && x.IdTipoAccion == Id).FirstOrDefault());
                        Nombre = regTipoAccion.Nombre;
                        db.TipoAccion.Remove(regTipoAccion);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Acción",
                           190000006,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio regTipoAnuncio = (db.TipoAnuncio.Where(x => x.Culture == _Culture && x.IdTipoAnuncio == Id).FirstOrDefault());
                        Nombre = regTipoAnuncio.Nombre;
                        db.TipoAnuncio.Remove(regTipoAnuncio);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Anuncio",
                           190000007,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja regTipoBandeja = (db.TipoBandeja.Where(x => x.Culture == _Culture && x.IdBandeja == Id).FirstOrDefault());
                        Nombre = regTipoBandeja.Nombre;
                        db.TipoBandeja.Remove(regTipoBandeja);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Bandeja",
                           190000008,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera regTipoCartelera = (db.TipoCartelera.Where(x => x.Culture == _Culture && x.IdTipoCartelera == Id).FirstOrDefault());
                        Nombre = regTipoCartelera.Nombre;
                        db.TipoCartelera.Remove(regTipoCartelera);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Cartelera",
                           190000009,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoContacto:
                        TipoContacto regTipoContacto = (db.TipoContacto.Where(x => x.Culture == _Culture && x.IdTipoContacto == Id).FirstOrDefault());
                        Nombre = regTipoContacto.Nombre;
                        db.TipoContacto.Remove(regTipoContacto);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Contacto",
                           190000010,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoContrato:
                        TipoContrato regTipoContrato = (db.TipoContrato.Where(x => x.Culture == _Culture && x.IdTipoContrato == Id).FirstOrDefault());
                        Nombre = regTipoContrato.Nombre;
                        db.TipoContrato.Remove(regTipoContrato);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Contrato",
                           190000011,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo regTipoDispositivo = (db.TipoDispositivo.Where(x => x.Culture == _Culture && x.IdTipoDispositivo == Id).FirstOrDefault());
                        Nombre = regTipoDispositivo.Nombre;
                        db.TipoDispositivo.Remove(regTipoDispositivo);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Dispositivo",
                           190000012,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje regTipoMensaje = (db.TipoMensaje.Where(x => x.Culture == _Culture && x.IdTipoMensaje == Id).FirstOrDefault());
                        Nombre = regTipoMensaje.Nombre;
                        db.TipoMensaje.Remove(regTipoMensaje);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Mensaje",
                           190000013,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoPersona:
                        TipoPersona regTipoPersona = (db.TipoPersona.Where(x => x.Culture == _Culture && x.IdTipoPersona == Id).FirstOrDefault());
                        Nombre = regTipoPersona.Nombre;
                        db.TipoPersona.Remove(regTipoPersona);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Persona",
                           190000014,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta regTipoPropuesta = (db.TipoPropuesta.Where(x => x.Culture == _Culture && x.IdTipoPropuesta == Id).FirstOrDefault());
                        Nombre = regTipoPropuesta.Nombre;
                        db.TipoPropuesta.Remove(regTipoPropuesta);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Propuesta",
                           190000015,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoTicket:
                        TipoTicket regTipoTicket = (db.TipoTicket.Where(x => x.Culture == _Culture && x.IdTipoTicket == Id).FirstOrDefault());
                        Nombre = regTipoTicket.Nombre;
                        db.TipoTicket.Remove(regTipoTicket);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Ticket",
                           190000016,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario regTipoUsuario = (db.TipoUsuario.Where(x => x.Culture == _Culture && x.IdTipoUsuario == Id).FirstOrDefault());
                        Nombre = regTipoUsuario.Nombre;
                        db.TipoUsuario.Remove(regTipoUsuario);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Usuario",
                           190000017,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo regTipoVehiculo = (db.TipoVehiculo.Where(x => x.Culture == _Culture && x.IdTipoVehiculo == Id).FirstOrDefault());
                        Nombre = regTipoVehiculo.Nombre;
                        db.TipoVehiculo.Remove(regTipoVehiculo);
                        db.SaveChanges();

                        ClasesVarias.AddBitacoraUsuario(db,
                           Nombre + "en la tabla Tipo Vehículo",
                           190000018,
                           "Eliminar");

                        return RedirectToAction("Index", new { IdPais, TipoTabla = tipoTabla });
                    default:
                        return RedirectToAction("Table");
                }
            }

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoContrato(int? IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TipoContratoResource.PageTitle;
            ViewBag.PageHeader = Resources.TipoContratoResource.HeaderPage;
            TiposContratoViewModel model = new TiposContratoViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.showTiposContrato = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.showTiposContrato = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                    model.TiposContrato = (from d in db.TipoContrato
                                           where d.Culture == _Culture
                                           select new TipoContratoViewModel
                                           {
                                               Id = d.IdTipoContrato,
                                               IdPais = (int)IdPais,
                                               Letra = d.LetraTipoContrato,
                                               Nombre = d.Nombre,
                                               UltimoNro = d.UltimoNroContrato
                                           }).ToList();
                }
            }


            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult TipoContrato(TiposContratoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TipoContratoResource.PageTitle;
            ViewBag.PageHeader = Resources.TipoContratoResource.HeaderPage;
            model.Paises = ClasesVarias.GetPaises();
            model.showTiposContrato = false;

            if (model.IdPais > 0)
            {
                model.showTiposContrato = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {

                    string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                    model.TiposContrato = (from d in db.TipoContrato
                                           where d.Culture == _Culture
                                           select new TipoContratoViewModel
                                           {
                                               Id = d.IdTipoContrato,
                                               IdPais = model.IdPais,
                                               Letra = d.LetraTipoContrato,
                                               Nombre = d.Nombre,
                                               UltimoNro = d.UltimoNroContrato
                                           }).ToList();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Tipos de Contrato del país " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       190000011,
                       "Consultar");
                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateTipoContrato(int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TipoContratoResource.CreateTipoContratoPageTitle;
            TipoContratoViewModel model = new TipoContratoViewModel();
            model.IdPais = IdPais;
            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TipoContratoResource.CreateTipoContratoHeaderPage,
                    (db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));

                model.Id = (db.TipoContrato.Where(x => x.Culture == _Culture).Select(x => (int?)x.IdTipoContrato).Max() ?? 0);
            }
            model.Id += 1;

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateTipoContrato(TipoContratoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TipoContratoResource.CreateTipoContratoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TipoContratoResource.CreateTipoContratoHeaderPage,
                        (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                TipoContrato TipoContrato = new TipoContrato
                {
                    Culture = _Culture,
                    IdTipoContrato = model.Id,
                    LetraTipoContrato = model.Letra,
                    UltimoNroContrato = 0,
                    Nombre = model.Nombre
                };

                db.TipoContrato.Add(TipoContrato);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Tipo de Contrato " + model.Nombre + "en " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000011,
                   "Agregar");

            }
            return RedirectToAction("TipoContrato", new { IdPais = model.IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditTipoContrato(int IdPais, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TipoContratoResource.EditTipoContratoPageTitle;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TipoContratoResource.EditTipoContratoHeaderPage,
                    (db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }
            TipoContratoViewModel model = new TipoContratoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                model = (db.TipoContrato.Where(x => x.Culture == _Culture && x.IdTipoContrato == Id)
                            .Select(x => new TipoContratoViewModel
                            {
                                Id = x.IdTipoContrato,
                                IdPais = IdPais,
                                Letra = x.LetraTipoContrato,
                                Nombre = x.Nombre
                            }).FirstOrDefault());
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditTipoContrato(TipoContratoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TipoContratoResource.EditTipoContratoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TipoContratoResource.EditTipoContratoHeaderPage,
                        (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                TipoContrato reg = (db.TipoContrato.Where(x => x.Culture == _Culture && x.IdTipoContrato == model.Id).FirstOrDefault());
                reg.Nombre = model.Nombre;
                reg.LetraTipoContrato = model.Letra;
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Tipo de Contrato " + model.Nombre + "en " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000011,
                   "Actualizar");


            }
            return RedirectToAction("TipoContrato", new { IdPais = model.IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteTipoContrato(int IdPais, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                TipoContrato reg = db.TipoContrato.Where(x => x.Culture == _Culture && x.IdTipoContrato == Id).FirstOrDefault();
                string Nombre = reg.Nombre;
                db.TipoContrato.Remove(reg);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "TipoContrato " + Nombre + "en el pais " + db.Pais.Where(x => x.IdPais == Id).Select(x => x.Nombre).FirstOrDefault(),
                   190000011,
                   "Eliminar");

            }
            return RedirectToAction("TipoContrato", new { IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Grupos(int? IdPais)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.GrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.GrupoHeaderPage;
            GruposViewModel model = new GruposViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.showDatos = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.showDatos = true;

                using (SeguricelEntities db = new SeguricelEntities())
                {
                    string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                    model.DatosTabla = (from d in db.Grupo
                                        where d.Culture == _Culture
                                        select new GrupoViewModel
                                        {
                                            Codigo = d.Codigo,
                                            Id = d.IdGrupo,
                                            IdPais = model.IdPais,
                                            Nombre = d.Nombre
                                        }).ToList();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Elementos en la tabla Grupos",
                       190000001,
                       "Consultar");

                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Grupos(GruposViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.GrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.GrupoHeaderPage;
            model.Paises = ClasesVarias.GetPaises();
            model.showDatos = true;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                model.DatosTabla = (from d in db.Grupo
                                    where d.Culture == _Culture
                                    select new GrupoViewModel
                                    {
                                        Codigo = d.Codigo,
                                        Id = d.IdGrupo,
                                        IdPais = model.IdPais,
                                        Nombre = d.Nombre
                                    }).ToList();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Elementos en la tabla Grupos",
                   190000001,
                   "Consultar");

            }
        
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateGrupo(int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.CreateGrupoPageTitle;
            GrupoViewModel model = new GrupoViewModel();
            model.IdPais = IdPais;

            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.CreateGrupoHeaderPage,
                    (db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));

            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateGrupo(GrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.CreateGrupoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TablasResource.CreateGrupoHeaderPage,
                        (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                Grupo grupo = new Grupo
                {
                    Codigo = model.Codigo,
                    Culture = _Culture,
                    IdGrupo = Guid.NewGuid(),
                    Nombre = model.Nombre
                };

                db.Grupo.Add(grupo);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   grupo.Nombre + " en la tabla Grupos",
                   190000001,
                   "Agregar");

            }

            return RedirectToAction("Grupos", new { IdPais = model.IdPais });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditGrupo(int IdPais, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal" || Id == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditGrupoPageTitle;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditGrupoHeaderPage,
                    (db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }
            GrupoViewModel model = new GrupoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                model = (db.Grupo.Where(x => x.Culture == _Culture && x.IdGrupo == Id)
                            .Select(x => new GrupoViewModel
                            {
                                Codigo = x.Codigo,
                                Culture = x.Culture,
                                Id = x.IdGrupo,
                                IdPais = IdPais,
                                Nombre = x.Nombre
                            }).FirstOrDefault());
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditGrupo(GrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.EditGrupoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TablasResource.EditGrupoHeaderPage,
                        (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                Grupo regGrupo = (db.Grupo.Where(x => x.Culture == _Culture && x.IdGrupo == model.Id).FirstOrDefault());
                regGrupo.Nombre = model.Nombre;
                regGrupo.Codigo = model.Codigo;
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   regGrupo.Nombre + " en la tabla Grupos",
                   190000001,
                   "Actualizar");

            }
            return RedirectToAction("Grupos", new { IdPais = model.IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteGrupo(int IdPais, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                Grupo regGrupo = db.Grupo.Where(x => x.Culture == _Culture && x.IdGrupo == Id).FirstOrDefault();
                string Nombre = regGrupo.Nombre;
                db.SubGrupo.RemoveRange(regGrupo.SubGrupo);
                db.Grupo.Remove(regGrupo);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Datos del Grupo " + Nombre + " y los SubGrupos",
                   190000001,
                   "Eliminar");

            }
            return RedirectToAction("Grupos", new { IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult SubGrupos(int? IdPais, Guid? IdGrupo)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.SubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.SubGrupoHeaderPage;

            SubgruposViewModel model = new SubgruposViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.Grupos = ClasesVarias.GetGrupos(0);
            model.showSubGrupo = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.Grupos = ClasesVarias.GetGrupos((int)IdPais);

                if (IdGrupo != null)
                {
                    model.GrupoID = (Guid)IdGrupo;
                    model.showSubGrupo = true;

                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                        model.SubGrupos = (from d in db.SubGrupo
                                           where d.Cuture == _Culture && d.IdGrupo == model.GrupoID
                                           select new SubGrupoViewModel
                                           {
                                               Codigo = d.Codigo,
                                               Id = d.IdSubGrupo,
                                               IdPais = (int)IdPais,
                                               Grupo = d.IdGrupo,
                                               Nombre = d.Nombre
                                           }).ToList();
                    }
                }
                else
                {
                    model.showSubGrupo = false;
                    model.Grupos = new SelectList(string.Empty, "Value", "Text");
                    model.SubGrupos = new List<SubGrupoViewModel>();
                }
            }

            return View(model);
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetGruposByPais(string Id)
        {
            if (Id != "")
            {
                int IdPais = int.Parse(Id);
                IEnumerable<SelectListItem> Grupos = ClasesVarias.GetGrupos(IdPais);

                return Json(new SelectList(Grupos, "Value", "Text"));
            }
            else
            {
                return Json(new SelectList("", "Value", "Text"));
            }
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult SubGrupos(SubgruposViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.SubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.SubGrupoHeaderPage;

            model.Grupos = ClasesVarias.GetGrupos(model.IdPais);
            model.Paises = ClasesVarias.GetPaises();

            model.showSubGrupo = false;

            if (model.IdPais > 0)
            {
                if (model.GrupoID != null)
                {
                    model.showSubGrupo = true;
                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                        model.SubGrupos = (from d in db.SubGrupo
                                           where d.Cuture == _Culture && d.IdGrupo == model.GrupoID
                                           select new SubGrupoViewModel
                                           {
                                               Codigo = d.Codigo,
                                               Id = d.IdSubGrupo,
                                               IdPais = model.IdPais,
                                               Grupo = d.IdGrupo,
                                               Nombre = d.Nombre
                                           }).ToList();

                        ClasesVarias.AddBitacoraUsuario(db,
                           "Datos de los Subgrupos del Grupo " + db.Grupo.Where(x => x.IdGrupo == model.GrupoID).Select(x => x.Nombre).FirstOrDefault(),
                           190000002,
                           "Consultar");

                    }
                }
                else
                {
                    model.showSubGrupo = false;
                    model.SubGrupos = new List<SubGrupoViewModel>();
                }
            }
            else
            {
                model.showSubGrupo = false;
                model.SubGrupos = new List<SubGrupoViewModel>();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateSubGrupo(int IdPais, Guid IdGrupo)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.CreateSubGrupoPageTitle;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.CreateSubGrupoHeaderPage,
                    (db.Grupo.Where(x => x.IdGrupo == IdGrupo).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }
            SubGrupoViewModel model = new SubGrupoViewModel();
            model.Grupo = IdGrupo;
            model.IdPais = IdPais;

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateSubGrupo(SubGrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.CreateSubGrupoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TablasResource.CreateSubGrupoHeaderPage,
                        (db.Grupo.Where(x => x.IdGrupo == model.Grupo).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }

            }

            using (SeguricelEntities db = new SeguricelEntities())
            {

                string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;

                SubGrupo SubGrupo = new SubGrupo
                {
                    Codigo = model.Codigo,
                    Cuture = _Culture,
                    IdGrupo = model.Grupo,
                    IdSubGrupo = Guid.NewGuid(),
                    Nombre = model.Nombre
                };

                db.SubGrupo.Add(SubGrupo);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Subgrupo " + model.Nombre + "en el grupo " + db.Grupo.Where(x => x.IdGrupo == model.Grupo).Select(x => x.Nombre).FirstOrDefault(),
                   190000002,
                   "Agregar");

            }
            return RedirectToAction("SubGrupos", new { IdPais = model.IdPais, IdGrupo = model.Grupo });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditSubGrupo(int IdPais, Guid IdGrupo, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditSubGrupoPageTitle;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditSubGrupoHeaderPage,
                    (db.Grupo.Where(x => x.IdGrupo == IdGrupo).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }
            SubGrupoViewModel model = new SubGrupoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.SubGrupo.Where(x => x.IdGrupo == IdGrupo && x.IdSubGrupo == Id)
                            .Select(x => new SubGrupoViewModel
                            {
                                Codigo = x.Codigo,
                                Id = x.IdSubGrupo,
                                IdPais = IdPais,
                                Grupo = IdGrupo,
                                Nombre = x.Nombre
                            }).FirstOrDefault());
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditSubGrupo(SubGrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.EditSubGrupoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TablasResource.EditSubGrupoHeaderPage,
                        (db.Grupo.Where(x => x.IdGrupo == model.Grupo).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                SubGrupo regSubGrupo = (db.SubGrupo.Where(x => x.IdGrupo == model.Grupo && x.IdSubGrupo == model.Id).FirstOrDefault());
                regSubGrupo.Nombre = model.Nombre;
                regSubGrupo.Codigo = model.Codigo;
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Subgrupo " + model.Nombre + "en el grupo " + db.Grupo.Where(x => x.IdGrupo == model.Grupo).Select(x => x.Nombre).FirstOrDefault(),
                   190000002,
                   "Actualizar");

            }
            return RedirectToAction("SubGrupos", new { IdPais = model.IdPais, IdGrupo = model.Grupo });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteSubGrupo(int IdPais, Guid IdGrupo, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                SubGrupo regSubGrupo = db.SubGrupo.Where(x => x.IdGrupo == IdGrupo && x.IdSubGrupo == Id).FirstOrDefault();
                string Nombre = regSubGrupo.Nombre;
                db.SubGrupo.Remove(regSubGrupo);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Subgrupo " + Nombre + "en el grupo " + db.Grupo.Where(x => x.IdGrupo == IdGrupo).Select(x => x.Nombre).FirstOrDefault(),
                   190000002,
                   "Eliminar");

            }
            return RedirectToAction("SubGrupos", new { IdPais, IdGrupo });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Pais()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.PaisPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.PaisHeaderPage;
            List<PaisViewModel> data = new List<PaisViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Pais
                        select new PaisViewModel
                        {
                            Activo = d.Activo,
                            Id = d.IdPais,
                            Nombre = d.Nombre,
                            Latitud = d.Ubicacion.Latitude.ToString(),
                            Longitud = d.Ubicacion.Longitude.ToString()
                        }).ToList();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Relación de Países",
                   190000003,
                   "Consultar");

            }
            return View(data);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreatePais()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            Nullable<int> NextId = null;

            ViewBag.Title = Resources.TablasResource.CreatePaisPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreatePaisHeaderPage;
            PaisViewModel model = new PaisViewModel();
            model.Longitud = User.Longitd.ToString();
            model.Latitud = User.Latitud.ToString();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                NextId = (db.Pais.Select(x => (int?)x.IdPais).Max() ?? 0);
            }

            if (NextId == null)
                NextId = 0;

            NextId += 1;

            model.Id = (int)NextId;

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreatePais(PaisViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.CreatePaisPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreatePaisHeaderPage;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Pais Pais = new Pais
                    {
                        IdPais = model.Id,
                        Activo = model.Activo,
                        Nombre = model.Nombre,
                        Culture = model.Culture,
                        Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud))
                    };

                    db.Pais.Add(Pais);
                    db.SaveChanges();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "País " + model.Nombre + " en condición de " + (model.Activo ? "Activo" : "Inactivo"),
                       190000003,
                       "Agregar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Pais");

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditPais(int? Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal" || Id == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditPaisPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EditPaisHeaderPage;
            PaisViewModel model = new PaisViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.Pais.Where(x => x.IdPais == Id)
                            .Select(x => new PaisViewModel
                            {
                                Activo = x.Activo,
                                Id = x.IdPais,
                                Nombre = x.Nombre,
                                Culture = x.Culture,
                                Latitud = x.Ubicacion.Latitude.ToString(),
                                Longitud = x.Ubicacion.Longitude.ToString()
                            }).FirstOrDefault());
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditPais(PaisViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.EditPaisPageTitle;
                ViewBag.PageHeader = Resources.TablasResource.EditPaisHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais regPais = (db.Pais.Where(x => x.IdPais == model.Id).FirstOrDefault());
                regPais.Nombre = model.Nombre;
                regPais.Activo = model.Activo;
                regPais.Culture = model.Culture;
                regPais.Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud));
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "País " + model.Nombre + " en condición de " + (model.Activo ? "Activo" : "Inactivo"),
                   190000003,
                   "Editar");

            }
            return RedirectToAction("Pais");
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeletePais(int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais regPais = db.Pais.Where(x => x.IdPais == Id).FirstOrDefault();

                string Nombre = regPais.Nombre;
                bool Activo = regPais.Activo;

                db.Pais_Estado_Ciudad.RemoveRange(regPais.Pais_Estado_Ciudad);
                db.Pais_Estado.RemoveRange(regPais.Pais_Estado);
                db.Pais.Remove(regPais);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "País " + Nombre + " en condición de " + (Activo ? "Activo" : "Inactivo"),
                   190000003,
                   "Eliminar");

            }
            return RedirectToAction("Pais");
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Estados(int? IdPais)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.EstadoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EstadoHeaderPage;
            PaisesViewModel model = new PaisesViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.showEstados = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.showEstados = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Estados = (from d in db.Pais_Estado
                                     where d.IdPais == model.IdPais
                                     select new EstadoViewModel
                                     {
                                         Activo = d.Activo,
                                         Id = d.IdEstado,
                                         IdPais = d.IdPais,
                                         Nombre = d.Nombre,
                                         Latitud = d.Ubicacion.Latitude.ToString(),
                                         Longitud = d.Ubicacion.Longitude.ToString()
                                     }).ToList();
                }
            }
            else
            {
                model.showEstados = false;
                model.Estados = new List<EstadoViewModel>();
            }
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Estados(PaisesViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.EstadoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EstadoHeaderPage;
            model.Paises = ClasesVarias.GetPaises();
            model.showEstados = false;
            if (model.IdPais > 0)
            {
                model.showEstados = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Estados = (from d in db.Pais_Estado
                                     where d.IdPais == model.IdPais
                                     select new EstadoViewModel
                                     {
                                         Activo = d.Activo,
                                         Id = d.IdEstado,
                                         IdPais = d.IdPais,
                                         Nombre = d.Nombre,
                                         Latitud = d.Ubicacion.Latitude.ToString(),
                                         Longitud = d.Ubicacion.Longitude.ToString()
                                     }).ToList();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Estados del País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       190000004,
                       "Consultar");

                }
            }
            else
            {
                model.showEstados = false;
                model.Estados = new List<EstadoViewModel>();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateEstado(int IdPais)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            Nullable<int> NextId = null;
            DbGeography _paisLocation;
            string NombrePais = string.Empty;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais _pais = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault();

                _paisLocation = _pais.Ubicacion;
                NombrePais = _pais.Nombre;

                ViewBag.Title = Resources.TablasResource.CreateEstadoPageTitle;
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.CreateEstadoHeaderPage,
                    _pais.Nombre);

                NextId = (db.Pais_Estado.Where(x => x.IdPais == IdPais).Select(x => (int?)x.IdEstado).Max() ?? 0);
            }
            if (NextId == null)
                NextId = 0;

            NextId += 1;

            EstadoViewModel model = new EstadoViewModel();
            model.IdPais = IdPais;
            model.Id = (int)NextId;
            model.Latitud = _paisLocation.Latitude.ToString();
            model.Longitud = _paisLocation.Longitude.ToString();
            model.PaisEstado = NombrePais;

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateEstado(EstadoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.CreateEstadoPageTitle;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    ViewBag.PageHeader = string.Format("{0} {1}",
                        Resources.TablasResource.CreateEstadoHeaderPage,
                        (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
                }

            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado Pais_Estado = new Pais_Estado
                {
                    Activo = model.Activo,
                    IdEstado = model.Id,
                    IdPais = model.IdPais,
                    Nombre = model.Nombre,
                    Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud))
                };

                db.Pais_Estado.Add(Pais_Estado);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Estado " + model.Nombre + " al País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000004,
                   "Agregar");

            }
            return RedirectToAction("Estados", new { IdPais = model.IdPais });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditEstado(int IdPais, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditEstadoPageTitle;

            string _NombrePais = string.Empty;
            using (SeguricelEntities db = new SeguricelEntities())
            {

                Pais _pais = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault();
                _NombrePais = _pais.Nombre;

                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditEstadoHeaderPage,
                    _NombrePais);

            }
            EstadoViewModel model = new EstadoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == Id)
                            .Select(x => new EstadoViewModel
                            {
                                Activo = x.Activo,
                                Id = x.IdEstado,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                Latitud = x.Ubicacion.Latitude.ToString(),
                                Longitud = x.Ubicacion.Longitude.ToString(),
                                PaisEstado = _NombrePais
                            }).FirstOrDefault());

                if (string.IsNullOrEmpty(model.Longitud))
                    model.Longitud = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Ubicacion.Longitude.ToString();
                if (string.IsNullOrEmpty(model.Latitud))
                    model.Latitud = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Ubicacion.Latitude.ToString();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditEstado(EstadoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.EditEstadoPageTitle;
                ViewBag.PageHeader = Resources.TablasResource.EditEstadoHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditEstadoHeaderPage,
                    (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado regPais_Estado = (db.Pais_Estado.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.Id).FirstOrDefault());
                regPais_Estado.Activo = model.Activo;
                regPais_Estado.Nombre = model.Nombre;
                regPais_Estado.Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud));
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Estado " + regPais_Estado.Nombre + " del País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000004,
                   "Actcualizar");

            }

            return RedirectToAction("Estados", new { IdPais = model.IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteEstado(int IdPais, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado regPais_Estado = db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == Id).FirstOrDefault();
                string Nombre = regPais_Estado.Nombre;
                db.Pais_Estado_Ciudad.RemoveRange(regPais_Estado.Pais_Estado_Ciudad);
                db.Pais_Estado.Remove(regPais_Estado);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Estado " + Nombre + " del País " + db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000004,
                   "Eliminar");

            }
            return RedirectToAction("Estados", new { IdPais });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Ciudades(int? IdPais, int? IdEstado)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.CiudadPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CiudadHeaderPage;
            EstadosViewModel model = new EstadosViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.Estados = ClasesVarias.GetEstados(0);
            model.Ciudades = new List<CiudadViewModel>();
            model.showCiudades = false;
            if (IdPais != null)
                model.IdPais = (int)IdPais;
            if (IdEstado != null)
                model.IdEstado = (int)IdEstado;

            if (model.IdPais > 0)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Estados = (from d in db.Pais_Estado
                                     where d.IdPais == model.IdPais
                                     select new SelectListItem
                                     {
                                         Value = d.IdEstado.ToString(),
                                         Text = d.Nombre
                                     }).ToList();
                }
            }

            if (model.IdEstado > 0)
            {
                model.showCiudades = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Ciudades = (from d in db.Pais_Estado_Ciudad
                                      where d.IdPais == model.IdPais && d.IdEstado == model.IdEstado
                                      select new CiudadViewModel
                                      {
                                          Activo = d.Activo,
                                          Id = d.IdCiudad,
                                          IdEstado = d.IdEstado,
                                          IdPais = d.IdPais,
                                          Nombre = d.Nombre,
                                          Latitud = d.Ubicacion.Latitude.ToString(),
                                          Longitud = d.Ubicacion.Longitude.ToString()
                                      }).ToList();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Ciudades del Estado " + db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).Select(x => x.Nombre).FirstOrDefault() + " del País " + db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       190000005,
                       "Consultar");

                }
            }
            return View(model);
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetEstadosByPais(string Id)
        {
            if (Id != "")
            {
                int IdPais = int.Parse(Id);
                IEnumerable<SelectListItem> Estados = ClasesVarias.GetEstados(IdPais);

                return Json(new SelectList(Estados, "Value", "Text"));
            }
            else
            {
                return Json(new SelectList("", "Value", "Text"));
            }
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Ciudades(EstadosViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.CiudadPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CiudadHeaderPage;

            model.Paises = ClasesVarias.GetPaises();
            model.Estados = new List<SelectListItem>();
            model.Ciudades = new List<CiudadViewModel>();
            model.showCiudades = false;

            if (model.IdPais > 0)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Estados = (from d in db.Pais_Estado
                                     where d.IdPais == model.IdPais
                                     select new SelectListItem
                                     {
                                         Value = d.IdEstado.ToString(),
                                         Text = d.Nombre
                                     }).ToList();
                }
            }

            if (model.IdEstado > 0)
            {
                model.showCiudades = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Ciudades = (from d in db.Pais_Estado_Ciudad
                                      where d.IdPais == model.IdPais && d.IdEstado == model.IdEstado
                                      select new CiudadViewModel
                                      {
                                          Activo = d.Activo,
                                          Id = d.IdCiudad,
                                          IdEstado = d.IdEstado,
                                          IdPais = d.IdPais,
                                          Nombre = d.Nombre,
                                          Latitud = d.Ubicacion.Latitude.ToString(),
                                          Longitud = d.Ubicacion.Longitude.ToString()
                                      }).ToList();

                    ClasesVarias.AddBitacoraUsuario(db,
                       "Ciudades del Estado " + db.Pais_Estado.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Nombre).FirstOrDefault() + " del País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                       190000005,
                       "Consultar");

                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateCiudad(int IdPais, int IdEstado)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            Nullable<int> NextId = null;

            ViewBag.Title = Resources.TablasResource.CreateCiudadPageTitle;
            string _NombreEstado = string.Empty;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais _pais = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault();
                Pais_Estado _estado = db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).FirstOrDefault();

                _NombreEstado = string.Format("{0}, {1}", _pais.Nombre, _estado.Nombre);

                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.CreateCiudadHeaderPage,
                    (db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));

                NextId = (db.Pais_Estado_Ciudad.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).Select(x => (int?)x.IdCiudad).Max() ?? 0);
            }
            if (NextId == null)
                NextId = 0;

            NextId += 1;

            CiudadViewModel model = new CiudadViewModel();
            model.IdPais = IdPais;
            model.IdEstado = IdEstado;
            model.Id = (int)NextId;
            model.PaisEstadoCiudad = _NombreEstado;
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateCiudad(CiudadViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.CreateCiudadPageTitle;
                ViewBag.PageHeader = Resources.TablasResource.CreateCiudadHeaderPage;
                return View(model);
            }

            ViewBag.Title = Resources.TablasResource.CreateCiudadPageTitle;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.CreateCiudadHeaderPage,
                    (db.Pais_Estado_Ciudad.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado_Ciudad Pais_Estado_Ciudad = new Pais_Estado_Ciudad
                {
                    Activo = model.Activo,
                    IdCiudad = model.Id,
                    IdEstado = model.IdEstado,
                    IdPais = model.IdPais,
                    Nombre = model.Nombre,
                    Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud))
                };

                db.Pais_Estado_Ciudad.Add(Pais_Estado_Ciudad);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Ciudad " + model.Nombre + " del Estado " + db.Pais_Estado.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Nombre).FirstOrDefault() + " del País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000005,
                   "Agregar");

            }
            return RedirectToAction("Ciudades", new { IdPais = model.IdPais, IdEstado = model.IdEstado });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditCiudad(int IdPais, int IdEstado, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditCiudadPageTitle;
            string _NombreEstado = string.Empty;
            Pais_Estado _estado;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais _pais = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault();
                _estado = db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).FirstOrDefault();

                _NombreEstado = string.Format("{0}, {1}", _pais.Nombre, _estado.Nombre);
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditCiudadHeaderPage,
                    (db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }
            CiudadViewModel model = new CiudadViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.Pais_Estado_Ciudad.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado && x.IdCiudad == Id)
                            .Select(x => new CiudadViewModel
                            {
                                Activo = x.Activo,
                                Id = x.IdCiudad,
                                IdEstado = x.IdEstado,
                                IdPais = IdPais,
                                Nombre = x.Nombre,
                                Latitud = _estado.Ubicacion.Latitude.ToString(),
                                Longitud = _estado.Ubicacion.Longitude.ToString(),
                                PaisEstadoCiudad = _NombreEstado
                            }).FirstOrDefault());

                if (string.IsNullOrEmpty(model.Longitud))
                    model.Longitud = (db.Pais_Estado_Ciudad.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Ubicacion.Longitude.ToString()).FirstOrDefault() ?? db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Ubicacion.Longitude.ToString()).FirstOrDefault());
                if (string.IsNullOrEmpty(model.Latitud))
                    model.Latitud = (db.Pais_Estado_Ciudad.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Ubicacion.Latitude.ToString()).FirstOrDefault() ?? db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Ubicacion.Latitude.ToString()).FirstOrDefault());
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult EditCiudad(CiudadViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.TablasResource.EditCiudadPageTitle;
                ViewBag.PageHeader = Resources.TablasResource.EditCiudadHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                ViewBag.PageHeader = string.Format("{0} {1}",
                    Resources.TablasResource.EditCiudadHeaderPage,
                    (db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault() ?? string.Empty));
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado_Ciudad regPais_Ciudad = (db.Pais_Estado_Ciudad.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado && x.IdCiudad == model.Id).FirstOrDefault());
                regPais_Ciudad.Activo = model.Activo;
                regPais_Ciudad.Nombre = model.Nombre;
                regPais_Ciudad.Ubicacion = DbGeography.FromText(string.Format("POINT({0} {1})", model.Longitud, model.Latitud));
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Ciudad " + model.Nombre + " del Estado " + db.Pais_Estado.Where(x => x.IdPais == model.IdPais && x.IdEstado == model.IdEstado).Select(x => x.Nombre).FirstOrDefault() + " del País " + db.Pais.Where(x => x.IdPais == model.IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000005,
                   "Actualizar");

            }
            return RedirectToAction("Ciudades", new { IdPais = model.IdPais, IdEstado = model.IdEstado });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteCiudad(int IdPais, int IdEstado, int Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Pais_Estado_Ciudad regPais_Estado_Ciudad = db.Pais_Estado_Ciudad.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado && x.IdCiudad == Id).FirstOrDefault();
                string Nombre = regPais_Estado_Ciudad.Nombre;
                db.Pais_Estado_Ciudad.Remove(regPais_Estado_Ciudad);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Ciudad " + Nombre + " del Estado " + db.Pais_Estado.Where(x => x.IdPais == IdPais && x.IdEstado == IdEstado).Select(x => x.Nombre).FirstOrDefault() + " del País " + db.Pais.Where(x => x.IdPais == IdPais).Select(x => x.Nombre).FirstOrDefault(),
                   190000005,
                   "Eliminar");

            }
            return RedirectToAction("Ciudades", new { IdPais, IdEstado });
        }

    }
}