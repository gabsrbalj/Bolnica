using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DoctorModelRest
    {
        public Guid doctorID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string telephoneNumber { get; set; }

        public string email { get; set; }

        public Guid departmentID { get; set; }
    }
}
