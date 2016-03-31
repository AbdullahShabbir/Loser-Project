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
     public class CaseDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int AddCaseDA(Case myCase)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_AddCase", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", myCase._Title);
                    cmd.Parameters.AddWithValue("@Description", myCase._Description);
                    cmd.Parameters.AddWithValue("@Category", myCase._Category );
                    cmd.Parameters.AddWithValue("@PostDate", myCase._PostDate );
                    cmd.Parameters.AddWithValue("@PostTime", myCase._PostTime);
                    cmd.Parameters.AddWithValue("@SoulId", myCase._SoulId);
                    cmd.Parameters.AddWithValue("@Security",myCase._Security);

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

          public SqlDataAdapter ShowCaseDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ShowCase", con);

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

          public SqlDataAdapter GetPublicCasebyIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ShowPublicCaseByID", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SoulID", SoulID);

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

          public SqlDataAdapter GetCasebyCategoryDA(string Category, string SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCasebyCategory", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Category", Category);
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

          public String[] GetCasebyIDDA(int CaseID)
          {
               String[] myData = new String[12];

               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCasebyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);

                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                         myData[i] = dataReader[i].ToString();
                    }

                    return myData;
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

          public int DeleteCasebyIDDA(int CaseID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_DeleteCasebyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);
                    
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

          public SqlDataAdapter GetPrivateCasebyIDDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ShowPrivateCaseByID", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SoulID", SoulID);

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

          public int UpdateCaseDA(int CaseID, Case myCase)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UpdateCase", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);
                    cmd.Parameters.AddWithValue("@Title", myCase._Title);
                    cmd.Parameters.AddWithValue("@Description", myCase._Description);
                    cmd.Parameters.AddWithValue("@Category", myCase._Category);
                    cmd.Parameters.AddWithValue("@PostDate", myCase._PostDate);
                    cmd.Parameters.AddWithValue("@PostTime", myCase._PostTime);
                    cmd.Parameters.AddWithValue("@SoulId", myCase._SoulId);
                    cmd.Parameters.AddWithValue("@Security", myCase._Security);

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

          public String[] GetCountDA(int CaseID)
          {
               String[] myData = new String[3];

               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);

                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                         myData[i] = dataReader[i].ToString();
                    }

                    return myData;
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

          public int UpdateCountDA(int CaseID, int Count_Sym, int Count_Oppor, int Count_Fac)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UpdateCount", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);
                    cmd.Parameters.AddWithValue("@CountSym", Count_Sym);
                    cmd.Parameters.AddWithValue("@CountOppor", Count_Oppor);
                    cmd.Parameters.AddWithValue("@CountFac", Count_Fac);
                    
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
