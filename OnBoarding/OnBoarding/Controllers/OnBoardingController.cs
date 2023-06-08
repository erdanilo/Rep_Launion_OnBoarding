using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OnBoarding.Models;

namespace OnBoarding.Controllers
{
    public class OnBoardingController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();
        // GET: OnBoarding
        public ActionResult Index()
        {
            ViewBag.Recursos = new SelectList(db.OBDTRecurso, "IdRecurso", "NombreRecurso");
            return View();
        }


        public ActionResult ObtenerRecursoPorId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OBDTRecurso oBDTRecurso = db.OBDTRecurso.Find(id);
            if (oBDTRecurso == null)
            {
                return HttpNotFound();
            }

            return Json(oBDTRecurso, JsonRequestBehavior.AllowGet);            
        }

    }
}