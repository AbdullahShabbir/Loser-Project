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
     public class CaseVideoDA
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

           public int AddCaseVideoDA(CaseVideo myCaseVideo)
           {
                try
                {
                     SqlCommand cmd = new SqlCommand("sp_AddCaseVideo", con);

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@CaseID", myCaseVideo._CaseId);
                     cmd.Parameters.AddWithValue("@SoulID", myCaseVideo._SoulId);
                     cmd.Parameters.AddWithValue("@Name", myCaseVideo._Name);
                     cmd.Parameters.AddWithValue("@ContentType", myCaseVideo._ContentType);
                     cmd.Parameters.AddWithValue("@Data", myCaseVideo._Data);

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

           public SqlDataAdapter ShowCaseVideobySoulIDDA(int SoulId)
           {
                try
                {
                     SqlCommand cmd = new SqlCommand("sp_GetCaseVideobySoulID", con);

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

           public SqlDataAdapter ShowOtherCaseVideoDA(int SoulId)
           {
                try
                {
                     SqlCommand cmd = new SqlCommand("sp_GetOtherCaseVideo", con);

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
