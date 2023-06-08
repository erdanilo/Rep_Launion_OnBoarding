using OnBoarding.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnBoarding.Controllers
{
    public class OnBoardingController : Controller
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();
        
        /// <summary>
        /// Devuelve la vista para crear un plan de OnBoarding asociado a un Puesto
        /// </summary>
        /// <returns>Vista</returns>
        public ActionResult Index()
        {
            ViewBag.Recursos = new SelectList(db.OBDTRecurso, "IdRecurso", "NombreRecurso");
            return View();
        }

        /// <summary>
        /// Metodo que devuelve un recurso en base a su id en formato json
        /// </summary>
        /// <param name="id"></param>
        /// <returns>json</returns>
        public async Task<ActionResult> ObtenerRecursoPorId(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:1304/")
                };
                HttpResponseMessage respuesta = await client.GetAsync($"api/OnBoarding/{id}");
                respuesta.EnsureSuccessStatusCode();
                
                var recurso = await respuesta.Content.ReadAsAsync<OBDTRecurso>();              

                return Json(recurso, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

    }
}