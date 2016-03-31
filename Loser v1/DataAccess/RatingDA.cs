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
     public class RatingDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int SetRatingDA(int SoulID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_SetRating", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulID);

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

          public Rating GetPreviousRatingDA(int SoulID, int CategoryID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetPreviousRating", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulID);
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    Rating myRating = new Rating();
                    myRating._SoulId = int.Parse(dataReader[0].ToString());
                    myRating._CategoryId = int.Parse(dataReader[1].ToString());
                    myRating._Points = int.Parse(dataReader[2].ToString());

                    return myRating;
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

          public int UpdateRatingDA(Rating myRating)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UpdateRating", con);    //Add it

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", myRating._SoulId);
                    cmd.Parameters.AddWithValue("@CategoryID", myRating._CategoryId);
                    cmd.Parameters.AddWithValue("@Points", myRating._Points + 5);

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

          public decimal GetCaseRatingDA(int CaseId)
          {
               try
               {
                    SqlCommand cmd_1 = new SqlCommand("sp_GetCaseRating", con);

                    cmd_1.CommandType = CommandType.StoredProcedure;
                    cmd_1.Parameters.AddWithValue("@CaseId", CaseId);

                    con.Open();

                    SqlDataReader dataReader = cmd_1.ExecuteReader();
                    dataReader.Read();

                    return decimal.Parse(dataReader[0].ToString());
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

          public int GiveCaseRatingDA(decimal Rating, int CaseId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GiveCaseRating", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rating", Rating);
                    cmd.Parameters.AddWithValue("@CaseID", CaseId);

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
