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
     public class CaseNotificationDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int SendCaseNotificationDA(CaseNotification myCaseNotification)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_SendCaseNotification", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NotificationType", myCaseNotification._NotificationType);
                    cmd.Parameters.AddWithValue("@FromID", myCaseNotification._FromID);
                    cmd.Parameters.AddWithValue("@ToID", myCaseNotification._ToID);
                    cmd.Parameters.AddWithValue("@CaseID", myCaseNotification._CaseId);
                    cmd.Parameters.AddWithValue("@GivenDate", myCaseNotification._GivenDate);
                    cmd.Parameters.AddWithValue("@GivenTime", myCaseNotification._GivenTime);
                    cmd.Parameters.AddWithValue("@IsReaded", myCaseNotification._IsReaded);

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

          public int GetCaseNotificationCountbySoulIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCaseNotificationCountbySoulID", con);

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

          public SqlDataAdapter GetCaseNotificationbySoulIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCaseNotificationbySoulID", con);

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

          public int SetCaseMarkAsReadbyIDDA(int CaseNotificationID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_SetCaseMarkAsReadbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseNotificationID", CaseNotificationID);
                    
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
