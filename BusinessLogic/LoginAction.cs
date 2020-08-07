using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class LoginAction
    {
        public OuputModel login(InputModel inputModel)
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

                using (SqlCommand commad = new SqlCommand("usp_Login", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;


                    commad.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                    commad.Parameters["@Email"].Value = inputModel.Login.UserName.ToString();

                    commad.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                    commad.Parameters["@Password"].Value = inputModel.Login.UserPassword.ToString();

                    using (IDataReader reader = commad.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ouputModel = new OuputModel()
                            {
                                status = reader.IsDBNull(reader.GetOrdinal("Status")) ? false : Convert.ToBoolean(reader[reader.GetOrdinal("Status")]),
                            };
                        }
                    }

                    return ouputModel;
                }
            }

        }
    }
}
