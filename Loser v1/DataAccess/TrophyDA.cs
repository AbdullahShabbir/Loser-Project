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
     public class TrophyDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public SqlDataAdapter ShowAllTrophyDA()
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ShowAllTrophy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
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

          //public bool IsTrophyGivenDA(int ToId, int TrophyId)
          //{
          //     try
          //     {
          //          SqlCommand cmd = new SqlCommand("sp_IsTrophyGiven", con);

          //          cmd.CommandType = CommandType.StoredProcedure;
          //          cmd.Parameters.AddWithValue("@ToID", ToId);
          //          cmd.Parameters.AddWithValue("@TrophyID", TrophyId);

          //          con.Open();

          //          SqlDataReader da = cmd.ExecuteReader();
          //          da.Read();

          //          if (da.HasRows)
          //          {
          //               return true;
          //          }

          //          return false;
          //     }
          //     catch
          //     {
          //          throw;
          //     }
          //     finally
          //     {
          //          con.Close();
          //     }
          //}
     }
}
