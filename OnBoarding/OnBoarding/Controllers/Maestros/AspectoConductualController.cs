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
    public class AspectoConductualController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        // GET: AspectoConductual
        public async Task<ActionResult> Index()
        {
            var oBDTAspectoConductual = db.OBDTAspectoConductual.Include(o => o.OBDTObjetivoAprendizaje);
            return View(await oBDTAspectoConductual.ToListAsync());
        }

        // GET: AspectoConductual/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoConductual oBDTAspectoConductual = await db.OBDTAspectoConductual.FindAsync(id);
            if (oBDTAspectoConductual == null)
            {
                return HttpNotFound();
            }
            return View(oBDTAspectoConductual);
        }

        // GET: AspectoConductual/Create
        public ActionResult Create()
        {
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje");
            return View();
        }

        // POST: AspectoConductual/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdAspectoConductual,CodigoAspectoConductual,NombreAspectoConductual,IdObjetivoAprendizaje,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTAspectoConductual oBDTAspectoConductual)
        {
            if (ModelState.IsValid)
            {
                db.OBDTAspectoConductual.Add(oBDTAspectoConductual);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoConductual.IdObjetivoAprendizaje);
            return View(oBDTAspectoConductual);
        }

        // GET: AspectoConductual/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoConductual oBDTAspectoConductual = await db.OBDTAspectoConductual.FindAsync(id);
            if (oBDTAspectoConductual == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoConductual.IdObjetivoAprendizaje);
            return View(oBDTAspectoConductual);
        }

        // POST: AspectoConductual/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdAspectoConductual,CodigoAspectoConductual,NombreAspectoConductual,IdObjetivoAprendizaje,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTAspectoConductual oBDTAspectoConductual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBDTAspectoConductual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdObjetivoAprendizaje = new SelectList(db.OBDTObjetivoAprendizaje, "IdObjetivoAprendizaje", "NombreObjetivoAprendizaje", oBDTAspectoConductual.IdObjetivoAprendizaje);
            return View(oBDTAspectoConductual);
        }

        // GET: AspectoConductual/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTAspectoConductual oBDTAspectoConductual = await db.OBDTAspectoConductual.FindAsync(id);
            if (oBDTAspectoConductual == null)
            {
                return HttpNotFound();
            }
            return View(oBDTAspectoConductual);
        }

        // POST: AspectoConductual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBDTAspectoConductual oBDTAspectoConductual = await db.OBDTAspectoConductual.FindAsync(id);
            db.OBDTAspectoConductual.Remove(oBDTAspectoConductual);
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
