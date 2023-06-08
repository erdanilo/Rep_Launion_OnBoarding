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
    public class EmpleadoController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        // GET: OBDTEmpleadoes
        public async Task<ActionResult> Index()
        {
            return View(await db.OBDTEmpleado.ToListAsync());
        }

        // GET: OBDTEmpleadoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTEmpleado oBDTEmpleado = await db.OBDTEmpleado.FindAsync(id);
            if (oBDTEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(oBDTEmpleado);
        }

        // GET: OBDTEmpleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OBDTEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEmpleado,CodigoEmpleado,NombreEmpleado,ApellidoEmpleado,FechaIngreso,Gerencia,Proceso,Departamento,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTEmpleado oBDTEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.OBDTEmpleado.Add(oBDTEmpleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oBDTEmpleado);
        }

        // GET: OBDTEmpleadoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTEmpleado oBDTEmpleado = await db.OBDTEmpleado.FindAsync(id);
            if (oBDTEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(oBDTEmpleado);
        }

        // POST: OBDTEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEmpleado,CodigoEmpleado,NombreEmpleado,ApellidoEmpleado,FechaIngreso,Gerencia,Proceso,Departamento,Activo,UsuarioInserto,FechaInserto,UsuarioModifico,FechaModifico")] OBDTEmpleado oBDTEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oBDTEmpleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oBDTEmpleado);
        }

        // GET: OBDTEmpleadoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTEmpleado oBDTEmpleado = await db.OBDTEmpleado.FindAsync(id);
            if (oBDTEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(oBDTEmpleado);
        }

        // POST: OBDTEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OBDTEmpleado oBDTEmpleado = await db.OBDTEmpleado.FindAsync(id);
            db.OBDTEmpleado.Remove(oBDTEmpleado);
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
