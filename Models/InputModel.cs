using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InputModel
    {
        public CommonModels.ActionType actionType { get; set; }

        public EmployeeModel employeeModel { get; set; }

        public DepatmentModel depatmentModel { get; set; }

        public LoginModel Login { get; set; }
    }
}
