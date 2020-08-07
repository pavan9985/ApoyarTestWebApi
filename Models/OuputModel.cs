using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OuputModel
    {
        public List<EmployeeModel> employeeList { get; set; }

        public List<DepatmentModel> DepatmentList { get; set; }

        public LoginModel loginModel { get; set; }

        public bool status { get; set; }

    }
}
