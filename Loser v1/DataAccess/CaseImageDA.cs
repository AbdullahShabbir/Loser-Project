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
     public class CaseImageDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int GetLastestCaseIDbySoulIdDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd_1 = new SqlCommand("sp_GetLastestCaseIDbySoulId", con);

                    cmd_1.CommandType = CommandType.StoredProcedure;
                    cmd_1.Parameters.AddWithValue("@SoulID", SoulId);

                    con.Open();

                    SqlDataReader dataReader = cmd_1.ExecuteReader();
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

          public int AddCaseImageDA(CaseImage myCaseImage)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_AddCaseImage", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", myCaseImage._CaseId);
                    cmd.Parameters.AddWithValue("@SoulID", myCaseImage._SoulId);
                    cmd.Parameters.AddWithValue("@Image", myCaseImage._Image);
                    
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

          public SqlDataAdapter ShowCaseImagebySoulIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCaseImagebySoulID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

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

          public SqlDataAdapter ShowOtherCaseImageDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetOtherCaseImage", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

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
