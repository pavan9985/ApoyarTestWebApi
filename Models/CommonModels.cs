using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CommonModels
    {
        public enum ActionType
        {
            AddEmployee = 1,
            EditEmployee = 2,
            DeleteEmployee = 3,
            
            AddDept = 4,
            EditDept = 5,
            DeleteDept = 6,
            Login = 7,
            ForgotPassword = 8,
            GetEmployee = 9,
            GetDept = 10
        }
    }
}
