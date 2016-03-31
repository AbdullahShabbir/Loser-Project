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
     public class AchievementDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int GiveTrophyDA(Achievement myAchievement)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GiveTrophy", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ToID", myAchievement._ToID);
                    cmd.Parameters.AddWithValue("@FromID", myAchievement._FromID);
                    cmd.Parameters.AddWithValue("@TrophyID", myAchievement._TrophyID);
                    cmd.Parameters.AddWithValue("@GivenDate", myAchievement._GivenDate);
                    cmd.Parameters.AddWithValue("@GivenTime", myAchievement._GivenTime);
                    
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

          public SqlDataAdapter GetUserAchievementDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetUserAchievement", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulId);

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

          public bool IsAchievementGivenDA(int ToId, int FromId, int TrophyId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_IsAchievementGiven", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ToID", ToId);
                    cmd.Parameters.AddWithValue("@FromID", FromId);
                    cmd.Parameters.AddWithValue("@TrophyID", TrophyId);

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
     }
}
