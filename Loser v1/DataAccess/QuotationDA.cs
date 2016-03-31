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
     public class QuotationDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int AddQuotationDA(Quotation myQuotation)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_AddQuotation", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", myQuotation._Description);
                    cmd.Parameters.AddWithValue("@SoulId", myQuotation._SoulId);
                    
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

          public SqlDataAdapter GetQuotationbySoulNameDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetQuotationbySoulID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

                    con.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    return dataAdapter;
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
