using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DoctorModel
    {

        public Guid DoctorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public string DoctorPassword { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid DepartmentID { get; set; }

    }
}
