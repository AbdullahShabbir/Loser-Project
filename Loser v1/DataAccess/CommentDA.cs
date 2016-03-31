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
     public class CommentDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int AddCommentDA(Comment myComment)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_AddComment", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", myComment._Description);
                    cmd.Parameters.AddWithValue("@Type", myComment._Type);
                    cmd.Parameters.AddWithValue("@PostDate", myComment._PostDate);
                    cmd.Parameters.AddWithValue("@PostTime", myComment._PostTime);
                    cmd.Parameters.AddWithValue("@SoulId", myComment._SoulId);
                    cmd.Parameters.AddWithValue("@CaseId", myComment._CaseId);

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

          public SqlDataAdapter ShowCommentDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ShowComment", con);

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

          public SqlDataAdapter GetCommentbyCaseDA(int CaseId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCommentbyCase", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseId", CaseId);

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

          //public decimal GetRatingDA(int CaseId)
          //{
          //     try
          //     {
          //          SqlCommand cmd_1 = new SqlCommand("sp_GetRating",con);
                    
          //          cmd_1.CommandType = CommandType.StoredProcedure;
          //          cmd_1.Parameters.AddWithValue("@CaseId", CaseId);

          //          con.Open();
                    
          //          SqlDataReader dataReader = cmd_1.ExecuteReader();
          //          dataReader.Read();

          //          return decimal.Parse(dataReader[0].ToString());
          //     }
          //     catch (Exception)
          //     {
          //          throw;
          //     }
          //     finally
          //     {
          //          con.Close();
          //     }
          //}

          //public decimal GiveRatingDA(decimal Rating, int CaseId)
          //{
          //     try
          //     {
          //          SqlCommand cmd = new SqlCommand("sp_GiveRating", con);

          //          cmd.CommandType = CommandType.StoredProcedure;
          //          cmd.Parameters.AddWithValue("@Rating", Rating);
          //          cmd.Parameters.AddWithValue("@CaseId", CaseId);
                    
          //          con.Open();

          //          int Result = cmd.ExecuteNonQuery();
          //          cmd.Dispose();
          //          return Result;
          //     }
          //     catch
          //     {
          //          throw;
          //     }
          //     finally
          //     {
          //          con.Close();
          //     }
          //}

          public int ChooseBestCommentDA(int CommentID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_ChooseBestComment", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CommentId", CommentID);
                    
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

          public string[] GetBestCommentDA(int CaseID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetBestComment", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", CaseID);

                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    if (dataReader.HasRows)
                    {
                         String[] bestComment = new String[5];

                         for (int i = 0; i < dataReader.FieldCount; i++)
                         {
                              bestComment[i] = dataReader[i].ToString();
                         }

                         return bestComment;
                    }

                    return null;
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

          public int RemoveBestCommentDA(int CaseID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_RemoveBestComment", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseId", CaseID);

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

          public int GetSoulIDbyCommentIDDA(int CommentID)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetSoulIDbyCommentID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CommentID", CommentID);

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
     }
}
