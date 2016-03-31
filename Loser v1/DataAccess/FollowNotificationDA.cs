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
     public class FollowNotificationDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int SendFollowNotificationDA(FollowNotification myFollowNotification)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_SendFollowNotification", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NotificationType", myFollowNotification._NotificationType);
                    cmd.Parameters.AddWithValue("@FromID", myFollowNotification._FromID);
                    cmd.Parameters.AddWithValue("@ToID", myFollowNotification._ToID);
                    cmd.Parameters.AddWithValue("@GivenDate", myFollowNotification._GivenDate);
                    cmd.Parameters.AddWithValue("@GivenTime", myFollowNotification._GivenTime);
                    cmd.Parameters.AddWithValue("@IsReaded", myFollowNotification._IsReaded);

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

          public int GetFollowNotificationCountbySoulIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetFollowNotificationCountbySoulID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulID);

                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    return int.Parse(dataReader[0].ToString());
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

          public SqlDataAdapter GetFollowNotificationbySoulIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetFollowNotificationbySoulID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulID);

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

          public int SetFollowMarkAsReadbyIDDA(int FollowNotificationID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_SetFollowMarkAsReadbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FollowNotificationID", FollowNotificationID);

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
