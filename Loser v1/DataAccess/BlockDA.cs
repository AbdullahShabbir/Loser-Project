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
     public class BlockDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public bool IsBlockDA(Block myBlock)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_IsBlocked", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myBlock._SoulId);
                    cmd.Parameters.AddWithValue("@BlockID", myBlock._BlockedSoulId);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader();
                    da.Read();

                    if (da.HasRows)
                    {
                         return true;
                    }

                    return false;
               }
               catch
               {
                    throw;
               }
               finally
               {
                    con.Close();
               }
          }

          public int BlockUserDA(Block myBlock)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_BlockUser", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myBlock._SoulId);
                    cmd.Parameters.AddWithValue("@BlockID", myBlock._BlockedSoulId);

                    con.Open();

                    int Result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return Result;
               }
               catch
               {
                    throw;
               }
               finally
               {
                    con.Close();
               }
          }

          public int UnBlockUserDA(Block myBlock)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UnBlockUser", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myBlock._SoulId);
                    cmd.Parameters.AddWithValue("@BlockID", myBlock._BlockedSoulId);

                    con.Open();

                    int Result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return Result;
               }
               catch
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
