using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class DepartmentService
    {
        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {

            DepartmentRepository departmentRepository = new DepartmentRepository();
            return await departmentRepository.GetAllDepartmentsAsync();

        }

        public async Task<List<DepartmentModel>> GetDepartmentAsync(int id)
        {

            DepartmentRepository departmentRepository = new DepartmentRepository();
            return await departmentRepository.GetDepartmentAsync(id);

        }
    }
}
