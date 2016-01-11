using Seguricel3.Helpers;
using Seguricel3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class AccesoController : Controller
    {
        // GET: Acceso
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index(int? IdPais, Guid? IdContrato)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoAccesoResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoAccesoResource.HeaderPage;

            AccesosViewModel model = new AccesosViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais((IdPais == null ? 0 : (int)IdPais));
            model.showAccesos = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.Contratos = ClasesVarias.GetContratosByPais((int)IdPais);

                if (IdContrato != null)
                {
                    model.IdContrato = (Guid)IdContrato;
                    model.showAccesos = true;

                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;
                        model.Accesos = new List<AccesoViewModel>();

                        List<Contrato_Acceso> Accesos = (from d in db.Contrato_Acceso
                                                          where d.IdContrato == model.IdContrato
                                                          select d).ToList();

                        foreach (Contrato_Acceso d in Accesos)
                        {
                            model.Accesos.Add(new AccesoViewModel
                            {
                                CantidadSecundarios = d.CantidadSecundarios,
                                Entrada = d.Entrada,
                                IdContrato = d.IdContrato,
                                IdPais = (int)IdPais,
                                IdAcceso = d.IdAcceso,
                                JuntaCondominio = d.JuntaCondominio,
                                Nombre = d.Nombre,
                                NroPersonas = d.NroPersonas,
                                Peatonal = d.Peatonal,
                                Personal = d.Personal,
                                PlantillasEmergencia = d.Plantillas_Emergencia,
                                PlantillasPersona = d.Plantillas_X_Persona,
                                Principales = d.Principales,
                                Secundarios = (bool)d.Secundarios,
                                RFID = d.RFID,
                                Salida = d.Salida,
                                Servicio = d.Servicio,
                                Vehicular = d.Vehicular,
                                Visitante = d.Visitante
                            });
                        }
                    }
                }
                else
                {
                    model.showAccesos = false;
                    model.Contratos = new SelectList(string.Empty, "Value", "Text");
                    model.Accesos = new List<AccesoViewModel>();
                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Index(AccesosViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoAccesoResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoAccesoResource.HeaderPage;

            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais(model.IdPais);

            model.showAccesos = false;

            if (model.IdPais > 0)
            {
                if (model.IdContrato != null && model.IdContrato != new Guid())
                {
                    model.showAccesos = true;
                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;
                        model.Accesos = new List<AccesoViewModel>();

                        List<Contrato_Acceso> Accesos = (from d in db.Contrato_Acceso
                                                          where d.IdContrato == model.IdContrato
                                                          select d).ToList();

                        foreach (Contrato_Acceso d in Accesos)
                        {
                            model.Accesos.Add(new AccesoViewModel
                            {
                                CantidadSecundarios = d.CantidadSecundarios,
                                Entrada = d.Entrada,
                                IdContrato = d.IdContrato,
                                IdPais = model.IdPais,
                                IdAcceso = d.IdAcceso,
                                JuntaCondominio = d.JuntaCondominio,
                                Nombre = d.Nombre,
                                NroPersonas = d.NroPersonas,
                                Peatonal = d.Peatonal,
                                Personal = d.Personal,
                                PlantillasEmergencia = d.Plantillas_Emergencia,
                                PlantillasPersona = d.Plantillas_X_Persona,
                                Principales = d.Principales,
                                Secundarios = (bool)d.Secundarios,
                                RFID = d.RFID,
                                Salida = d.Salida,
                                Servicio = d.Servicio,
                                Vehicular = d.Vehicular,
                                Visitante = d.Visitante
                            });
                        }
                    }
                }
                else
                {
                    model.showAccesos = false;
                    model.Contratos = new SelectList(string.Empty, "Value", "Text");
                    model.Accesos = new List<AccesoViewModel>();
                }
            }
            else
            {
                model.showAccesos = false;
                model.Contratos = new SelectList(string.Empty, "Value", "Text");
                model.Accesos = new List<AccesoViewModel>();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateAcceso(int IdPais, Guid IdContrato)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoAccesoResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratoAccesoResource.CreateHeaderPage;

            AccesoViewModel Model = new AccesoViewModel();

            Model.CantidadSecundarios = 0;
            Model.Entrada = false;
            Model.IdContrato = IdContrato;
            Model.IdPais = (int)IdPais;
            Model.Principales = false;
            Model.Secundarios = false;
            Model.JuntaCondominio = false;
            Model.Nombre = string.Empty;
            Model.NroPersonas = 0;
            Model.Peatonal = false;
            Model.Personal = false;
            Model.PlantillasEmergencia = 0;
            Model.PlantillasPersona = 0;
            Model.RFID = false;
            Model.Salida = false;
            Model.Servicio = false;
            Model.Vehicular = false;
            Model.Visitante = false;

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateAcceso(AccesoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Acceso dataAcceso = new Contrato_Acceso
                    {
                        CantidadSecundarios = model.CantidadSecundarios,
                        Entrada = model.Entrada,
                        IdContrato = model.IdContrato,
                        IdAcceso = Guid.NewGuid(),
                        JuntaCondominio = model.JuntaCondominio,
                        Nombre = model.Nombre,
                        NroPersonas = model.NroPersonas,
                        Peatonal = model.Peatonal,
                        Personal = model.Personal,
                        Plantillas_Emergencia = model.PlantillasEmergencia,
                        Plantillas_X_Persona = model.PlantillasPersona,
                        Principales = model.Principales,
                        Secundarios = model.Secundarios,
                        RFID = model.RFID,
                        Salida = model.Salida,
                        Servicio = model.Servicio,
                        Vehicular = model.Vehicular,
                        Visitante = model.Visitante
                    };

                    db.Contrato_Acceso.Add(dataAcceso);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Index", "Acceso", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditAcceso(int IdPais, Guid IdContrato, Guid IdAcceso)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoAccesoResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratoAccesoResource.EditHeaderPage;

            AccesoViewModel Model = new AccesoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Acceso Acceso = (from d in db.Contrato_Acceso
                                          where d.IdContrato == IdContrato && d.IdAcceso == IdAcceso
                                          select d).FirstOrDefault();

                if (Acceso != null)
                {
                    Model = new AccesoViewModel
                    {
                        CantidadSecundarios = Acceso.CantidadSecundarios,
                        Entrada = Acceso.Entrada,
                        IdContrato = Acceso.IdContrato,
                        IdPais = (int)IdPais,
                        IdAcceso = Acceso.IdAcceso,
                        JuntaCondominio = Acceso.JuntaCondominio,
                        Nombre = Acceso.Nombre,
                        NroPersonas = Acceso.NroPersonas,
                        Peatonal = Acceso.Peatonal,
                        Personal = Acceso.Personal,
                        PlantillasEmergencia = Acceso.Plantillas_Emergencia,
                        PlantillasPersona = Acceso.Plantillas_X_Persona,
                        Principales = Acceso.Principales,
                        Secundarios = (bool)Acceso.Secundarios,
                        RFID = Acceso.RFID,
                        Salida = Acceso.Salida,
                        Servicio = Acceso.Servicio,
                        Vehicular = Acceso.Vehicular,
                        Visitante = Acceso.Visitante
                    };
                }
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditAcceso(AccesoViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.EditHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {

                    Contrato_Acceso Acceso = (from d in db.Contrato_Acceso
                                              where d.IdContrato == model.IdContrato && d.IdAcceso == model.IdAcceso
                                              select d).FirstOrDefault();

                    Acceso.CantidadSecundarios = model.CantidadSecundarios;
                    Acceso.Entrada = model.Entrada;
                    Acceso.IdContrato = model.IdContrato;
                    Acceso.IdAcceso = Guid.NewGuid();
                    Acceso.JuntaCondominio = model.JuntaCondominio;
                    Acceso.Nombre = model.Nombre;
                    Acceso.NroPersonas = model.NroPersonas;
                    Acceso.Peatonal = model.Peatonal;
                    Acceso.Personal = model.Personal;
                    Acceso.Plantillas_Emergencia = model.PlantillasEmergencia;
                    Acceso.Plantillas_X_Persona = model.PlantillasPersona;
                    Acceso.Principales = model.Principales;
                    Acceso.Secundarios = model.Secundarios;
                    Acceso.RFID = model.RFID;
                    Acceso.Salida = model.Salida;
                    Acceso.Servicio = model.Servicio;
                    Acceso.Vehicular = model.Vehicular;
                    Acceso.Visitante = model.Visitante;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Index", "Acceso", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteAcceso(int IdPais, Guid IdContrato, Guid IdAcceso)
        {

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Acceso Acceso = (from d in db.Contrato_Acceso
                                          where d.IdContrato == IdContrato && d.IdAcceso == IdAcceso
                                          select d).FirstOrDefault();

                try
                {
                    db.Contrato_Acceso.Remove(Acceso);
                    db.SaveChanges();
                }
                catch
                {
                    string Message = Resources.ContratoAccesoResource.DeleteErrorMessage;
                    ModelState.AddModelError("", Message);
                }
            }

            return RedirectToAction("Index", "Acceso", new { IdPais, IdContrato });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult ShowAcceso(int IdPais, Guid IdContrato, Guid IdAcceso)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoAccesoResource.ShowPageTitle;
            ViewBag.PageHeader = Resources.ContratoAccesoResource.ShowHeaderPage;

            AccesoViewModel Model = new AccesoViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Acceso Acceso = (from d in db.Contrato_Acceso
                                          where d.IdContrato == IdContrato && d.IdAcceso == IdAcceso
                                          select d).FirstOrDefault();

                if (Acceso != null)
                {
                    Model = new AccesoViewModel
                    {
                        CantidadSecundarios = Acceso.CantidadSecundarios,
                        Entrada = Acceso.Entrada,
                        IdContrato = Acceso.IdContrato,
                        IdPais = (int)IdPais,
                        IdAcceso = Acceso.IdAcceso,
                        JuntaCondominio = Acceso.JuntaCondominio,
                        Nombre = Acceso.Nombre,
                        NroPersonas = Acceso.NroPersonas,
                        Peatonal = Acceso.Peatonal,
                        Personal = Acceso.Personal,
                        PlantillasEmergencia = Acceso.Plantillas_Emergencia,
                        PlantillasPersona = Acceso.Plantillas_X_Persona,
                        Principales = Acceso.Principales,
                        Secundarios = (bool)Acceso.Secundarios,
                        RFID = Acceso.RFID,
                        Salida = Acceso.Salida,
                        Servicio = Acceso.Servicio,
                        Vehicular = Acceso.Vehicular,
                        Visitante = Acceso.Visitante
                    };
                }
            }

            return View(Model);
        }
    }
}