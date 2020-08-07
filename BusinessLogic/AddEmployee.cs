using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class AddEmployee
    {
        public OuputModel Add(InputModel inputModel)
        {
            OuputModel ouputModel = null;

            ouputModel = DataAccessLogic(inputModel);

            return ouputModel;
        }

        private OuputModel DataAccessLogic(InputModel inputModel)
        {
            using (SqlConnection sqlCon = new SqlConnection("Server=awsdatabase-1.cklc9dvnkg9x.ap-south-1.rds.amazonaws.com,1433;User Id=MainUser;pwd=V4wearefour;Database=Assignment"))
            {
                sqlCon.Open();

                using (SqlCommand commad = new SqlCommand("usp_addEmployee", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;


                    //commad.Parameters.Add(new SqlParameter("", SqlDbType.Int));
                    //commad.Parameters[""].Value = inputModel.employeeModel.Pkempid.ToString();

                    
                    commad.Parameters.Add(new SqlParameter("@Empname", SqlDbType.VarChar));
                    commad.Parameters["@Empname"].Value = inputModel.employeeModel.Empname.ToString();

                    commad.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                    commad.Parameters["@Email"].Value = inputModel.employeeModel.Email.ToString();

                    commad.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                    commad.Parameters["@Password"].Value = inputModel.employeeModel.Password.ToString();

                    commad.Parameters.Add(new SqlParameter("@Salary", SqlDbType.Decimal));
                    commad.Parameters["@Salary"].Value = inputModel.employeeModel.Salary.ToString();

                    commad.Parameters.Add(new SqlParameter("@Isactive", SqlDbType.Bit));
                    commad.Parameters["@Isactive"].Value = inputModel.employeeModel.Isactive.ToString();

                    commad.Parameters.Add(new SqlParameter("@Fkdeptid", SqlDbType.Int));
                    commad.Parameters["@Fkdeptid"].Value = inputModel.employeeModel.Fkdeptid.ToString();

                    commad.ExecuteNonQuery();

                    return new OuputModel()
                    {
                        status = true
                    };
                }
            }

        }
    }
}
