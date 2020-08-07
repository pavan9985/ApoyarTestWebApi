using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class LoginGet
    {
        public OuputModel Getlogin(InputModel inputModel)
        {
            OuputModel ouputModel = null;

            ouputModel = DataAccessLogic(inputModel);

            return ouputModel;
        }

        private OuputModel DataAccessLogic(InputModel inputModel)
        {
            OuputModel ouputModel = null;
            using (SqlConnection sqlCon = new SqlConnection("Server=awsdatabase-1.cklc9dvnkg9x.ap-south-1.rds.amazonaws.com,1433;User Id=MainUser;pwd=V4wearefour;Database=Assignment"))
            {
                sqlCon.Open();

                using (SqlCommand commad = new SqlCommand("usp_GetPassword", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;

                    commad.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                    commad.Parameters["@Email"].Value = inputModel.Login.UserName.ToString();

                    using (IDataReader reader = commad.ExecuteReader())
                    {
                        ouputModel = new OuputModel();
                        
                        if (reader.Read())
                        {
                            ouputModel.loginModel = new LoginModel()
                            {
                                UserPassword = reader.IsDBNull(reader.GetOrdinal("Password")) ? "" : reader[reader.GetOrdinal("Password")].ToString(),
                            };

                        }
                    }
                }
            }
            return ouputModel;
        }
    }
}
