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
    public class AnamnesisController : ApiController
    {
        static List<AnamnesisModel> anamnesis = new List<AnamnesisModel>();

        [HttpGet]
        [Route("api/Anamnesis")]
        public async Task<HttpResponseMessage> GetAllAnamnesis()
        {
            AnamnesisService service = new AnamnesisService();

            anamnesis = await service.GetAllAnamnesis();

            if (anamnesis != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, anamnesis);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Anamnesis Not Found");
            }

        }
    }
}
