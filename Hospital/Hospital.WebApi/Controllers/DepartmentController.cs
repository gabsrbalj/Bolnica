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
        public async Task<HttpResponseMessage> GetAllDepartmentsAsync()
        {
            DepartmentService service = new DepartmentService();

            department = await service.GetAllDepartmentsAsync();

            if (department != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
            }

        }



        [HttpGet]
        [Route("api/Departmentsid")]
        public async Task<HttpResponseMessage> GetDepartmentAsync(int id)
        {
            DepartmentService service = new DepartmentService();

            department = await service.GetDepartmentAsync(id);

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
