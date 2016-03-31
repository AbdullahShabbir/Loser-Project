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
     public class FollowDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public bool IsFollowerDA(Follow myFollow)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_IsFollower", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myFollow._SoulId);
                    cmd.Parameters.AddWithValue("@FollowerID", myFollow._FriendSoulId);

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

          public int FollowUserDA(Follow myFollow)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_FollowUser", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myFollow._SoulId);
                    cmd.Parameters.AddWithValue("@FriendID", myFollow._FriendSoulId);

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

          public int UnFollowUserDA(Follow myFollow)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UnFollowUser", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myFollow._SoulId);
                    cmd.Parameters.AddWithValue("@FriendID", myFollow._FriendSoulId);

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
