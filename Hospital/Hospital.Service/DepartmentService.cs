﻿using Hospital.Model;
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
        public async Task<List<DepartmentModel>> GetAllDepartments()
        {

            DepartmentRepository departmentRepository = new DepartmentRepository();
            return await departmentRepository.GetAllDepartments();

        }
    }
}