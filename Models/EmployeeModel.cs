using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmployeeModel
    {
        public int Pkempid { get; set; }

        public string Empname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public double Salary { get; set; }

        public bool Isactive { get; set; }

        public int Fkdeptid { get; set; }



        public int pkdeptid { get; set; }

        public string deptname { get; set; }
    }
}
