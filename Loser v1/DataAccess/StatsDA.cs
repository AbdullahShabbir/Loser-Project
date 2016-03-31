using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
     public class StatsDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public SqlDataAdapter GetCategoryStatsbyIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCategoryStatsbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);
                    
                    con.Open();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                    return myAdapter;
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

          public SqlDataAdapter GetTotalCategoryStatsbyIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetTotalCategoryStatsbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

                    con.Open();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                    return myAdapter;
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

          public SqlDataAdapter GetSecurityStatsbyIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetSecurityStatsbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

                    con.Open();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                    return myAdapter;
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

          public SqlDataAdapter GetRatingStatsbyIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetRatingStatsbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

                    con.Open();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                    return myAdapter;
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

          public SqlDataAdapter GetTotalRatingStatsbyIDDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetTotalRatingStatsbyID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulId", SoulId);

                    con.Open();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                    return myAdapter;
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
