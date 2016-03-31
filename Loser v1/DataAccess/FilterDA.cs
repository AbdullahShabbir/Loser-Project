using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Model;

namespace DataAccess
{
     public class FilterDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public SqlDataAdapter FilterCaseDA(Filter myFilter)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_FilterCase", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", myFilter._SoulId);
                    cmd.Parameters.AddWithValue("@Category", myFilter._Category);
                    cmd.Parameters.AddWithValue("@Security", myFilter._Security);

                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    return sda;
               }
               catch (Exception)
               {
                    throw;
               }
               finally
               {
                    con.Close();
               }
          }
     }
}
