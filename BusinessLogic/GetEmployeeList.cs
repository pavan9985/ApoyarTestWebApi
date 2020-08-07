using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class GetEmployeeList
    {
        public OuputModel Get(InputModel inputModel)
        {
            OuputModel ouputModel = null;

            ouputModel = DataAccessLogic(inputModel);

            return ouputModel;
        }

        private OuputModel DataAccessLogic(InputModel inputModel)
        {
            OuputModel ouputModel = null;
            EmployeeModel employeeList = null;
            using (SqlConnection sqlCon = new SqlConnection("Server=awsdatabase-1.cklc9dvnkg9x.ap-south-1.rds.amazonaws.com,1433;User Id=MainUser;pwd=V4wearefour;Database=Assignment"))
            {
                sqlCon.Open();

                using (SqlCommand commad = new SqlCommand("usp_getEmployee", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;

                    using (IDataReader reader = commad.ExecuteReader())
                    {
                        ouputModel = new OuputModel();
                        ouputModel.employeeList = new List<EmployeeModel>();
                        while (reader.Read())
                        {
                            employeeList = new EmployeeModel()
                            {
                                Pkempid = reader.IsDBNull(reader.GetOrdinal("Pkempid")) ? -1 : Convert.ToInt32(reader[reader.GetOrdinal("Pkempid")]),
                                Empname = reader.IsDBNull(reader.GetOrdinal("Empname")) ? "" : reader[reader.GetOrdinal("Empname")].ToString(),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader[reader.GetOrdinal("Email")].ToString(),
                                Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? "" : reader[reader.GetOrdinal("Password")].ToString(),
                                Salary = reader.IsDBNull(reader.GetOrdinal("Salary")) ? -1 : Convert.ToDouble(reader[reader.GetOrdinal("Salary")]),
                                Isactive = reader.IsDBNull(reader.GetOrdinal("Isactive")) ? false : Convert.ToBoolean(reader[reader.GetOrdinal("Isactive")]),
                                Fkdeptid = reader.IsDBNull(reader.GetOrdinal("Fkdeptid")) ? -1 : Convert.ToInt32(reader[reader.GetOrdinal("Fkdeptid")]),
                                pkdeptid = reader.IsDBNull(reader.GetOrdinal("pkdeptid")) ? -1 : Convert.ToInt32(reader[reader.GetOrdinal("pkdeptid")]),
                                deptname = reader.IsDBNull(reader.GetOrdinal("deptname")) ? "" : reader[reader.GetOrdinal("deptname")].ToString(),
                            };

                            ouputModel.employeeList.Add(employeeList);
                        }
                    }
                }
            }
            return ouputModel;
        }
    }

}
