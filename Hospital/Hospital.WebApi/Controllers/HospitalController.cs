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
    public class HospitalController : ApiController
    {
        static List<HospitalModel> hospital = new List<HospitalModel>();

        [HttpGet]
        [Route("api/ShowHospital")]
        public async Task<HttpResponseMessage> ShowHospital()
        {
            HospitalService service = new HospitalService();

            hospital = await service.ShowHospital();

            if (hospital != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, hospital);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Hospital Not Found");
            }

        }
    }
}
