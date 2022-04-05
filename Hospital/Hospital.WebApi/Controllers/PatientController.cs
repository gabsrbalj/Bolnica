using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hospital.WebApi.Controllers
{
    public class PatientController : ApiController
    {

        static List<PatientModel> patient = new List<PatientModel>();

        [HttpGet]
        [Route("api/ShowAllPatients")]
        public async Task<HttpResponseMessage> GetAllPatients()
        {
            PatientService service = new PatientService();
            
            patient = await service.GetAllPatientsAsync();

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }
           
        }


        [HttpGet]
        [Route("api/getbyid")]
        public async Task<HttpResponseMessage> GetPatientAsync(int id)
        {
            PatientService service = new PatientService();

            patient = await service.GetPatientAsync(id);

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }

        }

        // POST: api/Patient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }
    }
}
