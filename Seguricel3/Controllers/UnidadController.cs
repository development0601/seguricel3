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
    public class UnidadController : Controller
    {
        // GET: Unidad
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Index(int? IdPais, Guid? IdContrato)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoUnidadResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoUnidadResource.HeaderPage;

            UnidadesViewModel model = new UnidadesViewModel();
            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais((IdPais == null ? 0 : (int)IdPais));
            model.showUnidades = false;

            if (IdPais != null)
            {
                model.IdPais = (int)IdPais;
                model.Contratos = ClasesVarias.GetContratosByPais((int)IdPais);

                if (IdContrato != null)
                {
                    model.IdContrato = (Guid)IdContrato;
                    model.showUnidades = true;

                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;
                        model.Unidades = new List<UnidadViewModel>();

                        List<Contrato_Unidad> unidades = (from d in db.Contrato_Unidad
                                                          where d.IdContrato == model.IdContrato
                                                          select d).ToList();

                        foreach (Contrato_Unidad d in unidades)
                        {
                            string strUnidadMaestra = string.Empty;

                            Contrato_Unidad unidadMaestra = (db.Contrato_Unidad.Where(x => x.IdContrato == model.IdContrato && x.IdUnidad == d.IdUnidadMaestra).FirstOrDefault());
                            if (unidadMaestra != null)
                                strUnidadMaestra = unidadMaestra.Nombre;

                            model.Unidades.Add(new UnidadViewModel
                            {
                                AceptaInvitados = d.AceptaInvitados,
                                AceptaSecundarios = d.AceptaSecundarios,
                                Activa = d.Activa,
                                CodigoAutorizacion = d.CodigoAutorizacionAcceso,
                                CodigoIdentificacionVigilancia = d.CodigoIdentificacionVigilancia,
                                IdContrato = d.IdContrato,
                                IdPais = (int)IdPais,
                                IdUnidad = d.IdUnidad,
                                IdUnidadMaestra = d.IdUnidadMaestra,
                                Imagen = d.Image,
                                JuntaCondominio = d.JuntaCondominio,
                                Nombre = d.Nombre,
                                Piso = d.Piso,
                                Seguridad = d.Seguridad,
                                Torre = d.Torre,
                                UnidadMaestra = strUnidadMaestra,
                                Vacaciones = d.ModoVacaciones
                            });
                        }
                    }
                }
                else
                {
                    model.showUnidades = false;
                    model.Contratos = new SelectList(string.Empty, "Value", "Text");
                    model.Unidades = new List<UnidadViewModel>();
                }
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Index(UnidadesViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ContratoUnidadResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratoUnidadResource.HeaderPage;

            model.Paises = ClasesVarias.GetPaises();
            model.Contratos = ClasesVarias.GetContratosByPais(model.IdPais);

            model.showUnidades = false;

            if (model.IdPais > 0)
            {
                if (model.IdContrato != null && model.IdContrato != new Guid())
                {
                    model.showUnidades = true;
                    using (SeguricelEntities db = new SeguricelEntities())
                    {
                        string _Culture = db.Pais.Where(x => x.IdPais == model.IdPais).FirstOrDefault().Culture;
                        model.Unidades = new List<UnidadViewModel>();

                        List<Contrato_Unidad> unidades = (from d in db.Contrato_Unidad
                                                          where d.IdContrato == model.IdContrato
                                                          select d).ToList();

                        foreach (Contrato_Unidad d in unidades)
                        {
                            string strUnidadMaestra = string.Empty;

                            Contrato_Unidad unidadMaestra = (db.Contrato_Unidad.Where(x => x.IdContrato == model.IdContrato && x.IdUnidad == d.IdUnidadMaestra).FirstOrDefault());
                            if (unidadMaestra != null)
                                strUnidadMaestra = unidadMaestra.Nombre;

                            model.Unidades.Add(new UnidadViewModel
                            {
                                AceptaInvitados = d.AceptaInvitados,
                                AceptaSecundarios = d.AceptaSecundarios,
                                Activa = d.Activa,
                                CodigoAutorizacion = d.CodigoAutorizacionAcceso,
                                CodigoIdentificacionVigilancia = d.CodigoIdentificacionVigilancia,
                                IdContrato = d.IdContrato,
                                IdPais = model.IdPais,
                                IdUnidad = d.IdUnidad,
                                IdUnidadMaestra = d.IdUnidadMaestra,
                                Imagen = d.Image,
                                JuntaCondominio = d.JuntaCondominio,
                                Nombre = d.Nombre,
                                Piso = d.Piso,
                                Seguridad = d.Seguridad,
                                Torre = d.Torre,
                                UnidadMaestra = strUnidadMaestra,
                                Vacaciones = d.ModoVacaciones
                            });
                        }
                    }
                }
                else
                {
                    model.showUnidades = false;
                    model.Contratos = new SelectList(string.Empty, "Value", "Text");
                    model.Unidades = new List<UnidadViewModel>();
                }
            }
            else
            {
                model.showUnidades = false;
                model.Contratos = new SelectList(string.Empty, "Value", "Text");
                model.Unidades = new List<UnidadViewModel>();
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateUnidad(int IdPais, Guid IdContrato)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoUnidadResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratoUnidadResource.CreateHeaderPage;

            UnidadViewModel Model = new UnidadViewModel();

            Model.AceptaInvitados = true;
            Model.AceptaSecundarios = true;
            Model.Activa = false;
            Model.CodigoAutorizacion = 0;
            Model.CodigoIdentificacionVigilancia = 0;
            Model.IdContrato = IdContrato;
            Model.JuntaCondominio = false;
            Model.IdPais = IdPais;
            Model.Nombre = string.Empty;
            Model.IdUnidad = new Guid();
            Model.UnidadesContrato = ClasesVarias.getUnidadesMaestrasContrato(IdContrato, null);
            Model.Imagen = new byte[] { };
            Model.Nombre = string.Empty;
            Model.Piso = string.Empty;
            Model.Seguridad = true;
            Model.Torre = string.Empty;
            Model.UnidadMaestra = string.Empty;
            Model.Vacaciones = false;

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult CreateUnidad(UnidadViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Unidad dataUnidad = new Contrato_Unidad
                    {
                        AceptaInvitados = model.AceptaInvitados,
                        AceptaSecundarios = model.AceptaSecundarios,
                        Activa = model.Activa,
                        CodigoAutorizacionAcceso = model.CodigoAutorizacion,
                        CodigoIdentificacionVigilancia = model.CodigoIdentificacionVigilancia,
                        IdContrato = model.IdContrato,
                        IdUnidad = Guid.NewGuid(),
                        IdUnidadMaestra = model.IdUnidadMaestra,
                        Image = model.Imagen,
                        JuntaCondominio = model.JuntaCondominio,
                        Nombre = model.Nombre,
                        ModoVacaciones = model.Vacaciones,
                        Piso = model.Piso,
                        Seguridad = model.Seguridad,
                        Torre = model.Torre
                    };

                    db.Contrato_Unidad.Add(dataUnidad);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Index", "Unidad", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            model.UnidadesContrato = ClasesVarias.getUnidadesMaestrasContrato(model.IdContrato, model.IdUnidad);
            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditUnidad(int IdPais, Guid IdContrato, Guid IdUnidad)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoUnidadResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratoUnidadResource.EditHeaderPage;

            UnidadViewModel Model = new UnidadViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Unidad Unidad = (from d in db.Contrato_Unidad
                                          where d.IdContrato == IdContrato && d.IdUnidad == IdUnidad
                                          select d).FirstOrDefault();

                if (Unidad != null)
                {
                    string strUnidadMaestra = string.Empty;

                    Contrato_Unidad unidadMaestra = (db.Contrato_Unidad.Where(x => x.IdContrato == Unidad.IdContrato && x.IdUnidad == Unidad.IdUnidadMaestra).FirstOrDefault());
                    if (unidadMaestra != null)
                        strUnidadMaestra = unidadMaestra.Nombre;

                    Model = new UnidadViewModel
                    {
                        AceptaInvitados = Unidad.AceptaInvitados,
                        AceptaSecundarios = Unidad.AceptaSecundarios,
                        Activa = Unidad.Activa,
                        CodigoAutorizacion = Unidad.CodigoAutorizacionAcceso,
                        CodigoIdentificacionVigilancia = Unidad.CodigoIdentificacionVigilancia,
                        IdContrato = Unidad.IdContrato,
                        IdPais = IdPais,
                        IdUnidad = Unidad.IdUnidad,
                        IdUnidadMaestra = Unidad.IdUnidadMaestra,
                        JuntaCondominio = Unidad.JuntaCondominio,
                        Nombre = Unidad.Nombre,
                        Piso = Unidad.Piso,
                        Seguridad = Unidad.Seguridad,
                        Torre = Unidad.Torre,
                        UnidadMaestra = strUnidadMaestra,
                        Vacaciones = Unidad.ModoVacaciones
                    };
                }
            }
            Model.UnidadesContrato = ClasesVarias.getUnidadesMaestrasContrato(IdContrato, Model.IdUnidad);

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionExpireFilter]
        [HandleError]
        public ActionResult EditUnidad(UnidadViewModel model)
        {
            ViewBag.Title = Resources.ContratosResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.EditHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {

                    Contrato_Unidad Unidad = (from d in db.Contrato_Unidad
                                              where d.IdContrato == model.IdContrato && d.IdUnidad == model.IdUnidad
                                              select d).FirstOrDefault();

                    string strUnidadMaestra = string.Empty;

                    Contrato_Unidad unidadMaestra = (db.Contrato_Unidad.Where(x => x.IdContrato == model.IdContrato && x.IdUnidad == model.IdUnidadMaestra).FirstOrDefault());
                    if (unidadMaestra != null)
                        strUnidadMaestra = unidadMaestra.Nombre;

                    Unidad.AceptaInvitados = model.AceptaInvitados;
                    Unidad.AceptaSecundarios = model.AceptaSecundarios;
                    Unidad.Activa = model.Activa;
                    Unidad.CodigoAutorizacionAcceso = model.CodigoAutorizacion;
                    Unidad.CodigoIdentificacionVigilancia = model.CodigoIdentificacionVigilancia;
                    Unidad.IdUnidadMaestra = model.IdUnidadMaestra;
                    Unidad.Image = model.Imagen;
                    Unidad.JuntaCondominio = model.JuntaCondominio;
                    Unidad.Nombre = model.Nombre;
                    Unidad.Piso = model.Piso;
                    Unidad.Seguridad = model.Seguridad;
                    Unidad.Torre = model.Torre;
                    Unidad.ModoVacaciones = model.Vacaciones;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return RedirectToAction("Index", "Unidad", new { IdPais = model.IdPais, IdContrato = model.IdContrato });
            }

            return View(model);
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult DeleteUnidad(int IdPais, Guid IdContrato, Guid IdUnidad)
        {

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Unidad Unidad = (from d in db.Contrato_Unidad
                                          where d.IdContrato == IdContrato && d.IdUnidad == IdUnidad
                                          select d).FirstOrDefault();

                try
                {
                    db.Contrato_Unidad.Remove(Unidad);
                    db.SaveChanges();
                }
                catch
                {
                    string Message = Resources.ContratoUnidadResource.DeleteErrorMessage;
                    ModelState.AddModelError("", Message);
                }
            }

            return RedirectToAction("Index", "Unidad", new { IdPais, IdContrato });
        }
        [SessionExpireFilter]
        [HandleError]
        public ActionResult ShowUnidad(int IdPais, Guid IdContrato, Guid IdUnidad)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratoUnidadResource.EditPageTitle;
            ViewBag.PageHeader = Resources.ContratoUnidadResource.EditHeaderPage;

            UnidadViewModel Model = new UnidadViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contrato_Unidad Unidad = (from d in db.Contrato_Unidad
                                          where d.IdContrato == IdContrato && d.IdUnidad == IdUnidad
                                          select d).FirstOrDefault();

                if (Unidad != null)
                {
                    string strUnidadMaestra = string.Empty;

                    Contrato_Unidad unidadMaestra = (db.Contrato_Unidad.Where(x => x.IdContrato == Unidad.IdContrato && x.IdUnidad == Unidad.IdUnidadMaestra).FirstOrDefault());
                    if (unidadMaestra != null)
                        strUnidadMaestra = unidadMaestra.Nombre;

                    Model = new UnidadViewModel
                    {
                        AceptaInvitados = Unidad.AceptaInvitados,
                        AceptaSecundarios = Unidad.AceptaSecundarios,
                        Activa = Unidad.Activa,
                        CodigoAutorizacion = Unidad.CodigoAutorizacionAcceso,
                        CodigoIdentificacionVigilancia = Unidad.CodigoIdentificacionVigilancia,
                        IdContrato = Unidad.IdContrato,
                        IdPais = IdPais,
                        IdUnidad = Unidad.IdUnidad,
                        IdUnidadMaestra = Unidad.IdUnidadMaestra,
                        JuntaCondominio = Unidad.JuntaCondominio,
                        Nombre = Unidad.Nombre,
                        Piso = Unidad.Piso,
                        Seguridad = Unidad.Seguridad,
                        Torre = Unidad.Torre,
                        UnidadMaestra = strUnidadMaestra,
                        Vacaciones = Unidad.ModoVacaciones
                    };
                }
            }
            Model.UnidadesContrato = ClasesVarias.getUnidadesMaestrasContrato(IdContrato, Model.IdUnidad);

            return View(Model);
        }
    }
}