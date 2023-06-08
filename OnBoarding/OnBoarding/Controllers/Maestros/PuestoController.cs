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
    public class PuestoController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        // GET: Puesto
        public async Task<ActionResult> Index()
        {
            return View(await db.OBDTPuesto.ToListAsync());
        }

        // GET: Puesto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTPuesto oBDTPuesto = await db.OBDTPuesto.FindAsync(id);
            if (oBDTPuesto == null)
            {
                return HttpNotFound();
            }
            return View(oBDTPuesto);
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPuesto,CodigoPuesto,NombrePuesto,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTPuesto oBDTPuesto)
        {
            if (ModelState.IsValid)
            {
                db.OBDTPuesto.Add(oBDTPuesto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBDTPuesto);
        }

        // GET: Puesto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTPuesto oBDTPuesto = await db.OBDTPuesto.FindAsync(id);
            if (oBDTPuesto == null)
            {
                return HttpNotFound();
            }
            return View(oBDTPuesto);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPuesto,CodigoPuesto,NombrePuesto,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTPuesto oBDTPuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBDTPuesto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBDTPuesto);
        }

        // GET: Puesto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTPuesto oBDTPuesto = await db.OBDTPuesto.FindAsync(id);
            if (oBDTPuesto == null)
            {
                return HttpNotFound();
            }
            return View(oBDTPuesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBDTPuesto oBDTPuesto = await db.OBDTPuesto.FindAsync(id);
            db.OBDTPuesto.Remove(oBDTPuesto);
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
