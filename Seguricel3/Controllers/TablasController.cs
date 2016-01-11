using Newtonsoft.Json;
using Seguricel3.Helpers;
using Seguricel3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoAccion });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoAnuncio()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoAnuncio });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoBandeja()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoBandeja });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoCartelera()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoCartelera });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoContacto()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoContacto });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoContrato()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoContrato });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoDispositivo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoAccion });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoMensaje()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoMensaje });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoPersona()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoPersona });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoPropuesta()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoPropuesta });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoTicket()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoTicket });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoUsuario()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoUsuario });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult TipoVehiculo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { tipoTabla = eTipoTabla.TipoVehiculo });
        }

        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index(eTipoTabla tipoTabla)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.TipoTabla = tipoTabla;

            List<TablaGeneralViewModel> data = new List<TablaGeneralViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.TipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAccionHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAccionTableHeader;

                        data = (from d in db.TipoAccion
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoAccion,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.TipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoAnuncioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoAnuncioTableHeader;

                        data = (from d in db.TipoAnuncio
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoAnuncio,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.TipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoBandejaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoBandejaTableHeader;

                        data = (from d in db.TipoBandeja
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdBandeja,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.TipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoCarteleraHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoCarteleraTableHeader;

                        data = (from d in db.TipoCartelera
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoCartelera,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.TipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContactoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContactoTableHeader;

                        data = (from d in db.TipoContacto
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoContacto,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.TipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoContratoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoContratoTableHeader;

                        data = (from d in db.TipoContrato
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoContrato,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.TipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoDispositivoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoDispositivoTableHeader;

                        data = (from d in db.TipoDispositivo
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoDispositivo,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.TipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoMensajeHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoMensajeTableHeader;

                        data = (from d in db.TipoMensaje
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoMensaje,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.TipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPersonaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPersonaTableHeader;

                        data = (from d in db.TipoPersona
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoPersona,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.TipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoPropuestaHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoPropuestaTableHeader;

                        data = (from d in db.TipoPropuesta
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoPropuesta,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.TipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoTicketHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoTicketTableHeader;

                        data = (from d in db.TipoTicket
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoTicket,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.TipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoUsuarioHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoUsuarioTableHeader;

                        data = (from d in db.TipoUsuario
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoUsuario,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.TipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.TipoVehiculoHeaderPage;
                        ViewBag.TableHeader = Resources.TablasResource.TipoVehiculoTableHeader;

                        data = (from d in db.TipoVehiculo
                                select new TablaGeneralViewModel
                                {
                                    Id = d.IdTipoVehiculo,
                                    Nombre = d.Nombre,
                                    TipoTabla = tipoTabla
                                }).ToList();

                        break;
                }
            }
            return View(data);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Create(eTipoTabla tipoTabla)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablaGeneralViewModel model = new TablaGeneralViewModel();
            model.TipoTabla = tipoTabla;
            Nullable<int> NextId = null;

            using (SeguricelEntities db = new SeguricelEntities())
            {

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAccionHeaderPage;
                        NextId = (db.TipoAccion.Select(x => (int?)x.IdTipoAccion).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.CreateTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoAnuncioHeaderPage;
                        NextId = (db.TipoAnuncio.Select(x => (int?)x.IdTipoAnuncio).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.CreateTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoBandejaHeaderPage;
                        NextId = (db.TipoBandeja.Select(x => (int?)x.IdBandeja).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.CreateTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoCarteleraHeaderPage;
                        NextId = (db.TipoCartelera.Select(x => (int?)x.IdTipoCartelera).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContactoHeaderPage;
                        NextId = (db.TipoContacto.Select(x => (int?)x.IdTipoContacto).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContratoHeaderPage;
                        NextId = (db.TipoContrato.Select(x => (int?)x.IdTipoContrato).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoDispositivoHeaderPage;
                        NextId = (db.TipoDispositivo.Select(x => (int?)x.IdTipoDispositivo).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.CreateTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoMensajeHeaderPage;
                        NextId = (db.TipoMensaje.Select(x => (int?)x.IdTipoMensaje).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPersonaHeaderPage;
                        NextId = (db.TipoPersona.Select(x => (int?)x.IdTipoPersona).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.CreateTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoPropuestaHeaderPage;
                        NextId = (db.TipoPropuesta.Select(x => (int?)x.IdTipoPropuesta).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.CreateTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoTicketHeaderPage;
                        NextId = (db.TipoTicket.Select(x => (int?)x.IdTipoTicket).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.CreateTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoUsuarioHeaderPage;
                        NextId = (db.TipoUsuario.Select(x => (int?)x.IdTipoUsuario).Max() ?? 0);
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.CreateTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoVehiculoHeaderPage;
                        NextId = (db.TipoVehiculo.Select(x => (int?)x.IdTipoVehiculo).Max() ?? 0);
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
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContratoHeaderPage;
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
                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion TipoAccion = new TipoAccion
                        {
                            IdTipoAccion = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoAccion.Add(TipoAccion);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio TipoAnuncio = new TipoAnuncio
                        {
                            IdTipoAnuncio = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoAnuncio.Add(TipoAnuncio);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja TipoBandeja = new TipoBandeja
                        {
                            IdBandeja = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoBandeja.Add(TipoBandeja);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera TipoCartelera = new TipoCartelera
                        {
                            IdTipoCartelera = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoCartelera.Add(TipoCartelera);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContacto:
                        TipoContacto TipoContacto = new TipoContacto
                        {
                            IdTipoContacto = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoContacto.Add(TipoContacto);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContrato:
                        TipoContrato TipoContrato = new TipoContrato
                        {
                            IdTipoContrato = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoContrato.Add(TipoContrato);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo TipoDispositivo = new TipoDispositivo
                        {
                            IdTipoDispositivo = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoDispositivo.Add(TipoDispositivo);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje TipoMensaje = new TipoMensaje
                        {
                            IdTipoMensaje = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoMensaje.Add(TipoMensaje);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPersona:
                        TipoPersona TipoPersona = new TipoPersona
                        {
                            IdTipoPersona = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoPersona.Add(TipoPersona);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta TipoPropuesta = new TipoPropuesta
                        {
                            IdTipoPropuesta = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoPropuesta.Add(TipoPropuesta);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoTicket:
                        TipoTicket TipoTicket = new TipoTicket
                        {
                            IdTipoTicket = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoTicket.Add(TipoTicket);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoUsuario.Add(TipoUsuario);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo TipoVehiculo = new TipoVehiculo
                        {
                            IdTipoVehiculo = model.Id,
                            Nombre = model.Nombre
                        };
                        db.TipoVehiculo.Add(TipoVehiculo);
                        db.SaveChanges();
                        break;
                    default:
                        return RedirectToAction("Table");
                }
            }
            return RedirectToAction("Index", new { tipoTabla = model.TipoTabla });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Edit(int Id, eTipoTabla tipoTabla)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            TablaGeneralViewModel model = new TablaGeneralViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {

                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        ViewBag.Title = Resources.TablasResource.EditTipoAccionPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoAccionHeaderPage;
                        model = (db.TipoAccion.Where(x => x.IdTipoAccion == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAccion,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoAnuncio:
                        ViewBag.Title = Resources.TablasResource.EditTipoAnuncioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoAnuncioHeaderPage;
                        model = (db.TipoAnuncio.Where(x => x.IdTipoAnuncio == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAnuncio,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoBandeja:
                        ViewBag.Title = Resources.TablasResource.EditTipoBandejaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoBandejaHeaderPage;
                        model = (db.TipoBandeja.Where(x => x.IdBandeja == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdBandeja,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoCartelera:
                        ViewBag.Title = Resources.TablasResource.EditTipoCarteleraPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoCarteleraHeaderPage;
                        model = (db.TipoAnuncio.Where(x => x.IdTipoAnuncio == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoAnuncio,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoContacto:
                        ViewBag.Title = Resources.TablasResource.EditTipoContactoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoContactoHeaderPage;
                        model = (db.TipoContacto.Where(x => x.IdTipoContacto == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoContacto,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.EditTipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoContratoHeaderPage;
                        model = (db.TipoContrato.Where(x => x.IdTipoContrato == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoContrato,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoDispositivo:
                        ViewBag.Title = Resources.TablasResource.EditTipoDispositivoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoDispositivoHeaderPage;
                        model = (db.TipoDispositivo.Where(x => x.IdTipoDispositivo == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoDispositivo,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoMensaje:
                        ViewBag.Title = Resources.TablasResource.EditTipoMensajePageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoMensajeHeaderPage;
                        model = (db.TipoMensaje.Where(x => x.IdTipoMensaje == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoMensaje,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoPersona:
                        ViewBag.Title = Resources.TablasResource.EditTipoPersonaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoPersonaHeaderPage;
                        model = (db.TipoPersona.Where(x => x.IdTipoPersona == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoPersona,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoPropuesta:
                        ViewBag.Title = Resources.TablasResource.EditTipoPropuestaPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoPropuestaHeaderPage;
                        model = (db.TipoPropuesta.Where(x => x.IdTipoPropuesta == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoPropuesta,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoTicket:
                        ViewBag.Title = Resources.TablasResource.EditTipoTicketPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoTicketHeaderPage;
                        model = (db.TipoTicket.Where(x => x.IdTipoTicket == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoTicket,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoUsuario:
                        ViewBag.Title = Resources.TablasResource.EditTipoUsuarioPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoUsuarioHeaderPage;
                        model = (db.TipoUsuario.Where(x => x.IdTipoUsuario == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoUsuario,
                                Nombre = x.Nombre,
                                TipoTabla = tipoTabla
                            }).FirstOrDefault());
                        break;
                    case eTipoTabla.TipoVehiculo:
                        ViewBag.Title = Resources.TablasResource.EditTipoVehiculoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.EditTipoVehiculoHeaderPage;
                        model = (db.TipoVehiculo.Where(x => x.IdTipoVehiculo == Id)
                            .Select(x => new TablaGeneralViewModel
                            {
                                Id = x.IdTipoVehiculo,
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
                    case eTipoTabla.TipoContrato:
                        ViewBag.Title = Resources.TablasResource.CreateTipoContratoPageTitle;
                        ViewBag.PageHeader = Resources.TablasResource.CreateTipoContratoHeaderPage;
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
                switch (model.TipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion regTipoAccion = (db.TipoAccion.Where(x => x.IdTipoAccion == model.Id).FirstOrDefault());
                        regTipoAccion.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio regTipoAnuncio = (db.TipoAnuncio.Where(x => x.IdTipoAnuncio == model.Id).FirstOrDefault());
                        regTipoAnuncio.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja regTipoBandeja = (db.TipoBandeja.Where(x => x.IdBandeja == model.Id).FirstOrDefault());
                        regTipoBandeja.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera regTipoCartelera = (db.TipoCartelera.Where(x => x.IdTipoCartelera == model.Id).FirstOrDefault());
                        regTipoCartelera.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContacto:
                        TipoContacto regTipoContacto = (db.TipoContacto.Where(x => x.IdTipoContacto == model.Id).FirstOrDefault());
                        regTipoContacto.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContrato:
                        TipoContrato regTipoContrato = (db.TipoContrato.Where(x => x.IdTipoContrato == model.Id).FirstOrDefault());
                        regTipoContrato.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo regTipoDispositivo = (db.TipoDispositivo.Where(x => x.IdTipoDispositivo == model.Id).FirstOrDefault());
                        regTipoDispositivo.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje regTipoMensaje = (db.TipoMensaje.Where(x => x.IdTipoMensaje == model.Id).FirstOrDefault());
                        regTipoMensaje.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPersona:
                        TipoPersona regTipoPersona = (db.TipoPersona.Where(x => x.IdTipoPersona == model.Id).FirstOrDefault());
                        regTipoPersona.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta regTipoPropuesta = (db.TipoPropuesta.Where(x => x.IdTipoPropuesta == model.Id).FirstOrDefault());
                        regTipoPropuesta.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoTicket:
                        TipoTicket regTipoTicket = (db.TipoTicket.Where(x => x.IdTipoTicket == model.Id).FirstOrDefault());
                        regTipoTicket.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario regTipoUsuario = (db.TipoUsuario.Where(x => x.IdTipoUsuario == model.Id).FirstOrDefault());
                        regTipoUsuario.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo regTipoVehiculo = (db.TipoVehiculo.Where(x => x.IdTipoVehiculo == model.Id).FirstOrDefault());
                        regTipoVehiculo.Nombre = model.Nombre;
                        db.SaveChanges();
                        break;
                    default:
                        return RedirectToAction("Table");
                }
            }
            return RedirectToAction("Index", new { tipoTabla = model.TipoTabla });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Delete(int Id, eTipoTabla tipoTabla)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                switch (tipoTabla)
                {
                    case eTipoTabla.TipoAccion:
                        TipoAccion regTipoAccion = (db.TipoAccion.Where(x => x.IdTipoAccion == Id).FirstOrDefault());
                        db.TipoAccion.Remove(regTipoAccion);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoAnuncio:
                        TipoAnuncio regTipoAnuncio = (db.TipoAnuncio.Where(x => x.IdTipoAnuncio == Id).FirstOrDefault());
                        db.TipoAnuncio.Remove(regTipoAnuncio);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoBandeja:
                        TipoBandeja regTipoBandeja = (db.TipoBandeja.Where(x => x.IdBandeja == Id).FirstOrDefault());
                        db.TipoBandeja.Remove(regTipoBandeja);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoCartelera:
                        TipoCartelera regTipoCartelera = (db.TipoCartelera.Where(x => x.IdTipoCartelera == Id).FirstOrDefault());
                        db.TipoCartelera.Remove(regTipoCartelera);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContacto:
                        TipoContacto regTipoContacto = (db.TipoContacto.Where(x => x.IdTipoContacto == Id).FirstOrDefault());
                        db.TipoContacto.Remove(regTipoContacto);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoContrato:
                        TipoContrato regTipoContrato = (db.TipoContrato.Where(x => x.IdTipoContrato == Id).FirstOrDefault());
                        db.TipoContrato.Remove(regTipoContrato);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoDispositivo:
                        TipoDispositivo regTipoDispositivo = (db.TipoDispositivo.Where(x => x.IdTipoDispositivo == Id).FirstOrDefault());
                        db.TipoDispositivo.Remove(regTipoDispositivo);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoMensaje:
                        TipoMensaje regTipoMensaje = (db.TipoMensaje.Where(x => x.IdTipoMensaje == Id).FirstOrDefault());
                        db.TipoMensaje.Remove(regTipoMensaje);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPersona:
                        TipoPersona regTipoPersona = (db.TipoPersona.Where(x => x.IdTipoPersona == Id).FirstOrDefault());
                        db.TipoPersona.Remove(regTipoPersona);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoPropuesta:
                        TipoPropuesta regTipoPropuesta = (db.TipoPropuesta.Where(x => x.IdTipoPropuesta == Id).FirstOrDefault());
                        db.TipoPropuesta.Remove(regTipoPropuesta);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoTicket:
                        TipoTicket regTipoTicket = (db.TipoTicket.Where(x => x.IdTipoTicket == Id).FirstOrDefault());
                        db.TipoTicket.Remove(regTipoTicket);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoUsuario:
                        TipoUsuario regTipoUsuario = (db.TipoUsuario.Where(x => x.IdTipoUsuario == Id).FirstOrDefault());
                        db.TipoUsuario.Remove(regTipoUsuario);
                        db.SaveChanges();
                        break;
                    case eTipoTabla.TipoVehiculo:
                        TipoVehiculo regTipoVehiculo = (db.TipoVehiculo.Where(x => x.IdTipoVehiculo == Id).FirstOrDefault());
                        db.TipoVehiculo.Remove(regTipoVehiculo);
                        db.SaveChanges();
                        break;
                    default:
                        return RedirectToAction("Table");
                }
            }
            return RedirectToAction("Index", new { tipoTabla = tipoTabla });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Grupos()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.GrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.GrupoHeaderPage;
            List<GrupoViewModel> data = new List<GrupoViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Grupo
                        select new GrupoViewModel
                        {
                            Codigo = d.Codigo,
                            Id = d.IdGrupo,
                            Nombre = d.Nombre
                        }).ToList();
            }
            return View(data);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateGrupo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.CreateGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreateGrupoHeaderPage;
            GrupoViewModel model = new GrupoViewModel();
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateGrupo(GrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");


            ViewBag.Title = Resources.TablasResource.CreateGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreateGrupoHeaderPage;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Grupo grupo = new Grupo
                {
                    Codigo = model.Codigo,
                    IdGrupo = Guid.NewGuid(),
                    Nombre = model.Nombre
                };

                db.Grupo.Add(grupo);
                db.SaveChanges();
            }
            return RedirectToAction("Grupos");

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditGrupo(Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal" || Id == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EditGrupoHeaderPage;
            GrupoViewModel model = new GrupoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.Grupo.Where(x => x.IdGrupo == Id)
                            .Select(x => new GrupoViewModel
                            {
                                Codigo = x.Codigo,
                                Id = x.IdGrupo,
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

            ViewBag.Title = Resources.TablasResource.EditGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EditGrupoHeaderPage;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Grupo regGrupo = (db.Grupo.Where(x => x.IdGrupo == model.Id).FirstOrDefault());
                regGrupo.Nombre = model.Nombre;
                regGrupo.Codigo = model.Codigo;
                db.SaveChanges();

            }
            return RedirectToAction("Grupos");
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteGrupo(Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Grupo regGrupo = db.Grupo.Where(x => x.IdGrupo == Id).FirstOrDefault();
                db.SubGrupo.RemoveRange(regGrupo.SubGrupo);
                db.Grupo.Remove(regGrupo);
                db.SaveChanges();
            }
            return RedirectToAction("Grupos");
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult SubGrupos()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.SubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.SubGrupoHeaderPage;
            ViewBag.Grupos = ClasesVarias.GetGrupos();

            return View();
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult ShowSubGrupos(Guid IdGrupo)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.TablasResource.SubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.SubGrupoHeaderPage;
            ViewBag.Grupos = ClasesVarias.GetGrupos();

            List<SubGrupoViewModel> data = new List<SubGrupoViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.SubGrupo
                        where d.IdGrupo == IdGrupo
                        select new SubGrupoViewModel
                        {
                            Codigo = d.Codigo,
                            Id = d.IdSubGrupo,
                            Nombre = d.Nombre
                        }).ToList();
            }
            return View("SubGrupos", data);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateSubGrupo(Guid IdGrupo)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.CreateSubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreateSubGrupoHeaderPage;
            SubGrupoViewModel model = new SubGrupoViewModel();
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult CreateSubGrupo(SubGrupoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");


            ViewBag.Title = Resources.TablasResource.CreateSubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.CreateSubGrupoHeaderPage;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                SubGrupo SubGrupo = new SubGrupo
                {
                    Codigo = model.Codigo,
                    IdGrupo = model.Grupo,
                    IdSubGrupo = new Guid(),
                    Nombre = model.Nombre
                };

                db.SubGrupo.Add(SubGrupo);
                db.SaveChanges();
            }
            return RedirectToAction("SubGrupos", new { model.Grupo });

        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditSubGrupo(Guid IdGrupo, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.TablasResource.EditSubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EditSubGrupoHeaderPage;
            SubGrupoViewModel model = new SubGrupoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                model = (db.SubGrupo.Where(x => x.IdGrupo == IdGrupo && x.IdSubGrupo == Id)
                            .Select(x => new SubGrupoViewModel
                            {
                                Codigo = x.Codigo,
                                Id = x.IdSubGrupo,
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

            ViewBag.Title = Resources.TablasResource.EditSubGrupoPageTitle;
            ViewBag.PageHeader = Resources.TablasResource.EditSubGrupoHeaderPage;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                SubGrupo regSubGrupo = (db.SubGrupo.Where(x => x.IdGrupo == model.Grupo && x.IdSubGrupo == model.Id).FirstOrDefault());
                regSubGrupo.Nombre = model.Nombre;
                regSubGrupo.Codigo = model.Codigo;
                db.SaveChanges();

            }
            return RedirectToAction("SubGrupos", new { model.Grupo });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteSubGrupo(Guid IdGrupo, Guid Id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            using (SeguricelEntities db = new SeguricelEntities())
            {
                SubGrupo regSubGrupo = db.SubGrupo.Where(x => x.IdGrupo == IdGrupo && x.IdSubGrupo == Id).FirstOrDefault();
                db.SubGrupo.Remove(regSubGrupo);
                db.SaveChanges();
            }
            return RedirectToAction("SubGrupos", new { IdGrupo });
        }

    }
}