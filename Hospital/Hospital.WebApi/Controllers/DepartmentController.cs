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
    public class DepartmentController : ApiController
    {
        static List<DepartmentModel> department = new List<DepartmentModel>();

        [HttpGet]
        [Route("api/Departments")]
        public async Task<HttpResponseMessage> GetAllDepartments()
        {
            DepartmentService service = new DepartmentService();

            department = await service.GetAllDepartments();

            if (department != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
            }

        }
    }
}
