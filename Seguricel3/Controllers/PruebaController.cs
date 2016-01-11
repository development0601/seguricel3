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
    public class PruebaController : Controller
    {
        private SeguricelEntities db = new SeguricelEntities();

        // GET: Prueba
        public ActionResult Index()
        {
            var cotizacion = db.Cotizacion.Include(c => c.Contrato).Include(c => c.EstadoPropuesta).Include(c => c.Pais).Include(c => c.Pais_Estado).Include(c => c.Pais_Estado_Ciudad).Include(c => c.TipoPropuesta).Include(c => c.Vendedor);
            return View(cotizacion.ToList());
        }

        // GET: Prueba/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: Prueba/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "Contratante");
            ViewBag.IdEstadoPropuesta = new SelectList(db.EstadoPropuesta, "IdEstadoPropuesta", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre");
            ViewBag.IdTipoPropuesta = new SelectList(db.TipoPropuesta, "IdTipoPropuesta", "Nombre");
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nombre");
            return View();
        }

        // POST: Prueba/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCotizacion,Nombre,Direccion,IdVendedor,IdContrato,IdPais,IdEstado,IdCiudad,IdTipoPropuesta,IdEstadoPropuesta,FechaEstadoPropuesta,TotalTorres,NroResidenciasXTorre,TotalResidencias,NroLocalesComerciales,DescripcionAccesoActual,AccesoTelefonico,AccesoBiometrico,AlarmaSilente,ControlVigilancia,AccesoRFID,VigilanciaContratada,NombreEmpresaVigilancia")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                cotizacion.IdCotizacion = Guid.NewGuid();
                db.Cotizacion.Add(cotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "Contratante", cotizacion.IdContrato);
            ViewBag.IdEstadoPropuesta = new SelectList(db.EstadoPropuesta, "IdEstadoPropuesta", "Nombre", cotizacion.IdEstadoPropuesta);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdTipoPropuesta = new SelectList(db.TipoPropuesta, "IdTipoPropuesta", "Nombre", cotizacion.IdTipoPropuesta);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nombre", cotizacion.IdVendedor);
            return View(cotizacion);
        }

        // GET: Prueba/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "Contratante", cotizacion.IdContrato);
            ViewBag.IdEstadoPropuesta = new SelectList(db.EstadoPropuesta, "IdEstadoPropuesta", "Nombre", cotizacion.IdEstadoPropuesta);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdTipoPropuesta = new SelectList(db.TipoPropuesta, "IdTipoPropuesta", "Nombre", cotizacion.IdTipoPropuesta);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nombre", cotizacion.IdVendedor);
            return View(cotizacion);
        }

        // POST: Prueba/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCotizacion,Nombre,Direccion,IdVendedor,IdContrato,IdPais,IdEstado,IdCiudad,IdTipoPropuesta,IdEstadoPropuesta,FechaEstadoPropuesta,TotalTorres,NroResidenciasXTorre,TotalResidencias,NroLocalesComerciales,DescripcionAccesoActual,AccesoTelefonico,AccesoBiometrico,AlarmaSilente,ControlVigilancia,AccesoRFID,VigilanciaContratada,NombreEmpresaVigilancia")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "Contratante", cotizacion.IdContrato);
            ViewBag.IdEstadoPropuesta = new SelectList(db.EstadoPropuesta, "IdEstadoPropuesta", "Nombre", cotizacion.IdEstadoPropuesta);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdPais = new SelectList(db.Pais_Estado_Ciudad, "IdPais", "Nombre", cotizacion.IdPais);
            ViewBag.IdTipoPropuesta = new SelectList(db.TipoPropuesta, "IdTipoPropuesta", "Nombre", cotizacion.IdTipoPropuesta);
            ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "Nombre", cotizacion.IdVendedor);
            return View(cotizacion);
        }

        // GET: Prueba/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: Prueba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            db.Cotizacion.Remove(cotizacion);
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
