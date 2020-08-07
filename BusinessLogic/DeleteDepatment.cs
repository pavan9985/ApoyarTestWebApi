using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class DeleteDepatment
    {
        public OuputModel Delete(InputModel inputModel)
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

                using (SqlCommand commad = new SqlCommand("usp_deleteDept", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;


                    commad.Parameters.Add(new SqlParameter("@pkdeptid", SqlDbType.Int));
                    commad.Parameters["@pkdeptid"].Value = inputModel.depatmentModel.pkdeptid.ToString();

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
