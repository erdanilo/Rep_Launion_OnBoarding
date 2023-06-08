using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnBoarding.Models;

namespace OnBoarding.Controllers.Maestros
{
    public class AspectoTecnicoController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        // GET: AspectoTecnico
        public async Task<ActionResult> Index()
        {
            var oBDTAspectoTecnico = db.OBDTAspectoTecnico.Include(o => o.OBDTObjetivoAprendizaje);
            return View(await oBDTAspectoTecnico.ToListAsync());
        }

        // GET: AspectoTecnico/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoTecnico oBDTAspectoTecnico = await db.OBDTAspectoTecnico.FindAsync(id);
            if (oBDTAspectoTecnico == null)
            {
                return HttpNotFound();
            }
            return View(oBDTAspectoTecnico);
        }

        // GET: AspectoTecnico/Create
        public ActionResult Create()
        {
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje");
            return View();
        }

        // POST: AspectoTecnico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdAspectoTecnico,CodigoAspectoTecnico,NombreAspectoTecnico,IdObjetivoAprendizaje,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTAspectoTecnico oBDTAspectoTecnico)
        {
            if (ModelState.IsValid)
            {
                db.OBDTAspectoTecnico.Add(oBDTAspectoTecnico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoTecnico.IdObjetivoAprendizaje);
            return View(oBDTAspectoTecnico);
        }

        // GET: AspectoTecnico/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoTecnico oBDTAspectoTecnico = await db.OBDTAspectoTecnico.FindAsync(id);
            if (oBDTAspectoTecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoTecnico.IdObjetivoAprendizaje);
            return View(oBDTAspectoTecnico);
        }

        // POST: AspectoTecnico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdAspectoTecnico,CodigoAspectoTecnico,NombreAspectoTecnico,IdObjetivoAprendizaje,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTAspectoTecnico oBDTAspectoTecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBDTAspectoTecnico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoTecnico.IdObjetivoAprendizaje);
            return View(oBDTAspectoTecnico);
        }

        // GET: AspectoTecnico/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoTecnico oBDTAspectoTecnico = await db.OBDTAspectoTecnico.FindAsync(id);
            if (oBDTAspectoTecnico == null)
            {
                return HttpNotFound();
            }
            return View(oBDTAspectoTecnico);
        }

        // POST: AspectoTecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBDTAspectoTecnico oBDTAspectoTecnico = await db.OBDTAspectoTecnico.FindAsync(id);
            db.OBDTAspectoTecnico.Remove(oBDTAspectoTecnico);
            await db.SaveChangesAsync();
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
