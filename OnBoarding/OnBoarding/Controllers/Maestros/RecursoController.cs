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

namespace OnBoarding.Controllers
{
    public class RecursoController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        // GET: OBDTRecurso
        public async Task<ActionResult> Index()
        {
            return View(await db.OBDTRecurso.ToListAsync());
        }

        // GET: OBDTRecurso/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTRecurso oBDTRecurso = await db.OBDTRecurso.FindAsync(id);
            if (oBDTRecurso == null)
            {
                return HttpNotFound();
            }
            return View(oBDTRecurso);
        }

        // GET: OBDTRecurso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OBDTRecurso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRecurso,CodigoRecurso,NombreRecurso,Reponsable,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTRecurso oBDTRecurso)
        {
            if (ModelState.IsValid)
            {
                db.OBDTRecurso.Add(oBDTRecurso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBDTRecurso);
        }

        // GET: OBDTRecurso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTRecurso oBDTRecurso = await db.OBDTRecurso.FindAsync(id);
            if (oBDTRecurso == null)
            {
                return HttpNotFound();
            }
            return View(oBDTRecurso);
        }

        // POST: OBDTRecurso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRecurso,CodigoRecurso,NombreRecurso,Reponsable,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTRecurso oBDTRecurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBDTRecurso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBDTRecurso);
        }

        // GET: OBDTRecurso/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTRecurso oBDTRecurso = await db.OBDTRecurso.FindAsync(id);
            if (oBDTRecurso == null)
            {
                return HttpNotFound();
            }
            return View(oBDTRecurso);
        }

        // POST: OBDTRecurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBDTRecurso oBDTRecurso = await db.OBDTRecurso.FindAsync(id);
            db.OBDTRecurso.Remove(oBDTRecurso);
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
