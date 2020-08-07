using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace BusinessLogic
{
    public class GetDepatmentList
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
            DepatmentModel depatmentModel= null;
            using (SqlConnection sqlCon = new SqlConnection("Server=awsdatabase-1.cklc9dvnkg9x.ap-south-1.rds.amazonaws.com,1433;User Id=MainUser;pwd=V4wearefour;Database=Assignment"))
            {
                sqlCon.Open();

                using (SqlCommand commad = new SqlCommand("usp_getDept", sqlCon))
                {
                    commad.CommandType = System.Data.CommandType.StoredProcedure;


                    using (IDataReader reader = commad.ExecuteReader())
                    {
                        ouputModel = new OuputModel();
                        ouputModel.DepatmentList = new List<DepatmentModel>();
                        while (reader.Read())
                        {
                            depatmentModel = new DepatmentModel()
                            {
                                pkdeptid = reader.IsDBNull(reader.GetOrdinal("pkdeptid")) ? -1 : Convert.ToInt32(reader[reader.GetOrdinal("pkdeptid")]),
                                deptname = reader.IsDBNull(reader.GetOrdinal("deptname")) ? "" : reader[reader.GetOrdinal("deptname")].ToString(),
                                Isactive = reader.IsDBNull(reader.GetOrdinal("Isactive")) ? false : Convert.ToBoolean(reader[reader.GetOrdinal("Isactive")]),
                            };

                            ouputModel.DepatmentList.Add(depatmentModel);
                        }
                    }
                }
            }
            return ouputModel;
        }
    }
}
