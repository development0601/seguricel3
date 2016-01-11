using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguricel3;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class ContratoController : BaseController
    {
        private SeguricelEntities db = new SeguricelEntities();

        // GET: Contratos
        public ActionResult Index()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ContratosResource.PageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.HeaderPage;
            ViewBag.TableHeader = Resources.ContratosResource.TableHeader;
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.NewButton = Resources.ContratosResource.ButtonNewContent;

            List<Models.ContratoViewModel> contrato = new List<Models.ContratoViewModel>();

            using (db = new SeguricelEntities())
            {
                contrato = (from d in db.Contrato
                            select new Models.ContratoViewModel
                            {
                                AccesoDactilar = d.AccesoDactilar,
                                AccesoTelefonico = d.AccesoTelefonico,
                                Administradora = d.Contrato_Administradora.Nombre,
                                AlarmaSilente = d.AlarmaSilente,
                                AutoGestion_Aptos = d.AutoGestion_Aptos,
                                Ciudad = d.Pais_Estado_Ciudad.Nombre,
                                CodigoPostal = d.CodigoPostal,
                                CondominioVirtual = d.CondominioVirtual,
                                ContraseñaCorreoComunidad = d.ContraseñaCorreoComunidad,
                                ContraseñaCorreoJC = d.ContraseñaCorreoJC,
                                Contratante = d.Contratante,
                                ControlAscensores = d.ControlAscensores,
                                ControlEstacionamiento = d.ControlEstacionamiento,
                                CorreoElectronicoComunida = d.CorreoElectronicoComunida,
                                CorreoElectronicoJunta = d.CorreoElectronicoJunta,
                                DetieneSMS_Emergencia = d.DetieneSMS_Emergencia,
                                DetieneSMS_JC = d.DetieneSMS_JC,
                                Direccion = d.Direccion,
                                EmergenciaVecinal = d.EmergenciaVecinal,
                                Estado = d.Pais_Estado.Nombre,
                                EstadoContrato = d.EstadoContrato.Nombre,
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
                                MaximoInvitados = d.MaximoInvitados,
                                MaximoPuestosFijos = d.MaximoPuestosFijos,
                                MaximoPuestosVisitantes = d.MaximoPuestosVisitantes,
                                MaximoSecundarios = d.MaximoSecundarios,
                                MesCorte = d.DiaCorte,
                                NombreCompleto = d.NombreCompleto,
                                NroContrato = d.NroContrato,
                                Pais = d.Pais.Nombre,
                                RegistroFiscal = d.RegistroFiscal,
                                TipoContrato = d.TipoContrato.Nombre,
                                UbicacionGeografica = d.UbicacionGeografica,
                                Vigicel = d.Vigicel
                            }).ToList();
            }
            return View(contrato);
        }

        // GET: Contratos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            ViewBag.IdAdministradora = new SelectList(db.Contrato_Administradora, "IdAdministradora", "Nombre");
            ViewBag.IdEstadoContrato = new SelectList(db.EstadoContrato, "IdEstadoContrato", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            ViewBag.IdEstado = new SelectList(db.Pais_Estado, "IdPais", "Nombre");
            ViewBag.IdCiudad = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre");
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Nombre");
            ViewBag.Title = Resources.ContratosResource.CreatePageTitle;
            ViewBag.PageHeader = Resources.ContratosResource.CreateHeaderPage;
            return View();
        }

        // POST: Contratos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContrato,IdTipoContrato,NroContrato,Contratante,Direccion,IdPais,IdEstado,IdCiudad,CodigoPostal,FechaContrato,RegistroFiscal,NombreRespresentanteLegal,TelefonoRepresentanteLegal,NombreEncargadoServicios,TelefonoEncargadoServicios,NombreEncargadoSeguridad,TelefonoEncargadoSeguridad,IdAdministradora,AccesoTelefonico,AccesoDactilar,Vigicel,AlarmaSilente,CondominioVirtual,ControlAscensores,EmergenciaVecinal,MaximoSecundarios,MaximoInvitados,ControlEstacionamiento,MaximoPuestosVisitantes,MaximoPuestosFijos,CorreoElectronicoJunta,CorreoElectronicoComunida,PuertoPOPGeneral,PuertoSMTPGeneral,ServidorPOPGeneral,ServidorSMTPGeneral,PuertoPOPJC,PuertoSMTPJC,ServidorPOPJC,ServidorSMTPJC,UsuarioCorreoComunidad,ContraseñaCorreoComunidad,UsuarioCorreoJC,ContraseñaCorreoJC,NroRedesInstalacion,NombreCompleto,DetieneSMS_Emergencia,DetieneSMS_JC,MesCorte,AutoGestion_Aptos,ImagenEdificio,IdRedMiwi,IdEstadoContrato,UbicacionGeografica")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                contrato.IdContrato = Guid.NewGuid();
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAdministradora = new SelectList(db.Contrato_Administradora, "IdAdministradora", "Nombre", contrato.IdAdministradora);
            ViewBag.IdEstadoContrato = new SelectList(db.EstadoContrato, "IdEstadoContrato", "Nombre", contrato.IdEstadoContrato);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Nombre", contrato.IdTipoContrato);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAdministradora = new SelectList(db.Contrato_Administradora, "IdAdministradora", "Nombre", contrato.IdAdministradora);
            ViewBag.IdEstadoContrato = new SelectList(db.EstadoContrato, "IdEstadoContrato", "Nombre", contrato.IdEstadoContrato);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Nombre", contrato.IdTipoContrato);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContrato,IdTipoContrato,NroContrato,Contratante,Direccion,IdPais,IdEstado,IdCiudad,CodigoPostal,FechaContrato,RegistroFiscal,NombreRespresentanteLegal,TelefonoRepresentanteLegal,NombreEncargadoServicios,TelefonoEncargadoServicios,NombreEncargadoSeguridad,TelefonoEncargadoSeguridad,IdAdministradora,AccesoTelefonico,AccesoDactilar,Vigicel,AlarmaSilente,CondominioVirtual,ControlAscensores,EmergenciaVecinal,MaximoSecundarios,MaximoInvitados,ControlEstacionamiento,MaximoPuestosVisitantes,MaximoPuestosFijos,CorreoElectronicoJunta,CorreoElectronicoComunida,PuertoPOPGeneral,PuertoSMTPGeneral,ServidorPOPGeneral,ServidorSMTPGeneral,PuertoPOPJC,PuertoSMTPJC,ServidorPOPJC,ServidorSMTPJC,UsuarioCorreoComunidad,ContraseñaCorreoComunidad,UsuarioCorreoJC,ContraseñaCorreoJC,NroRedesInstalacion,NombreCompleto,DetieneSMS_Emergencia,DetieneSMS_JC,MesCorte,AutoGestion_Aptos,ImagenEdificio,IdRedMiwi,IdEstadoContrato,UbicacionGeografica")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAdministradora = new SelectList(db.Contrato_Administradora, "IdAdministradora", "Nombre", contrato.IdAdministradora);
            ViewBag.IdEstadoContrato = new SelectList(db.EstadoContrato, "IdEstadoContrato", "Nombre", contrato.IdEstadoContrato);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", contrato.IdPais);
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "Nombre", contrato.IdTipoContrato);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
