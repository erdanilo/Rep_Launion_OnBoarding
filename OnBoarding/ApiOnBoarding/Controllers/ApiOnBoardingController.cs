using ApiOnBoarding.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace ApiOnBoarding.Controllers
{
    public class ApiOnBoardingController : ApiController
    {
        private BIOSALCTEMPEntities db = new BIOSALCTEMPEntities();

        /// <summary>
        /// Metodo que devuelve un recurso en base a su id en formato json
        /// </summary>
        /// <param name="id"></param>
        /// <returns>json</returns>
        [Route("api/OnBoarding/{id}")]
        [HttpGet]
        public IHttpActionResult ObtenerRecursoPorId(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("El id viene nulo");
                }

                var recurso = (from i in db.OBDTRecurso
                               where i.Activo && i.IdRecurso == id
                               select new
                               {
                                   i.IdRecurso,
                                   i.NombreRecurso,
                                   i.Reponsable
                               }).FirstOrDefault();

                if (recurso == null)
                {
                    return NotFound();
                }

                return Ok(recurso);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}