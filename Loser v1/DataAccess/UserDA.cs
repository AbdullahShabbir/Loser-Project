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
     public class UserDA
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public int RegisterUserDA(User myUser) // passing Bussiness object Here
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_RegisterUser", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulName", myUser._SoulName);
                    cmd.Parameters.AddWithValue("@Email", myUser._Email);
                    cmd.Parameters.AddWithValue("@Password", myUser._Password);

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

          public List<String> GetUserNameDA()
          {
               SqlCommand cmd = new SqlCommand("Select soul_name from [User]", con);
               cmd.CommandType = CommandType.Text;
               List<String> UserName = new List<String>();

               con.Open();

               SqlDataReader da = cmd.ExecuteReader();
      
               while (da.Read())
               {
                    if (da.HasRows)
	               {
		               UserName.Add(da[0].ToString());
                    }
               }

               return UserName;
          }

          public String[] LoginCheckDA(string SoulName, string Password) // passing Bussiness object Here
          {
               String[] Info = new String[2];

               try
               {
                    SqlCommand cmd = new SqlCommand("sp_LoginCheck", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = cmd.CreateParameter();
                    param = cmd.CreateParameter();
                    param.ParameterName = "@SoulName";
                    param.Value = SoulName;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = cmd.CreateParameter();
                    param.ParameterName = "@Password";
                    param.Value = Password;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader();
                    da.Read();

                    if (da.HasRows)
                    {
                         Info[0] = da[0].ToString();
                         Info[1] = da[1].ToString();
                    }
                    else
                    {
                         Info[0] = "0";
                         Info[1] = "0";
                    }
                         

                    return Info;
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

          public int UpdateUserPrefDA(string SoulName, string cat_1, string cat_2, string cat_3)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UpdateUserPref", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulName", SoulName);
                    cmd.Parameters.AddWithValue("@Cat_1", cat_1);
                    cmd.Parameters.AddWithValue("@Cat_2", cat_2);
                    cmd.Parameters.AddWithValue("@Cat_3", cat_3);

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

          public int SetDeafultPrefDA(string SoulName)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_DefaultUserPref", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulName", SoulName);
                    
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

          public List<string> GetUserDetailDA(string SoulName)
          {
               SqlCommand cmd = new SqlCommand("sp_GetUserDetail", con);
               cmd.CommandType = CommandType.StoredProcedure;

               SqlParameter param = cmd.CreateParameter();
               param = cmd.CreateParameter();
               param.ParameterName = "@SoulName";
               param.Value = SoulName;
               param.DbType = DbType.String;
               cmd.Parameters.Add(param);

               List<String> UserDetail = new List<String>();

               con.Open();

               SqlDataReader da = cmd.ExecuteReader();
               da.Read();

               UserDetail.Add(da[0].ToString());
               UserDetail.Add(da[1].ToString());
               UserDetail.Add(da[2].ToString());
               UserDetail.Add(da[3].ToString());
               UserDetail.Add(da[4].ToString());
               UserDetail.Add(da[5].ToString());
               UserDetail.Add(da[6].ToString());

               return UserDetail;
          }

          public int GetIDbySoulNameDA(string SoulName)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetIDbySoulName", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulName", SoulName);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader();
                    da.Read();

                    return int.Parse(da[0].ToString());
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

          public int UpdateUserDetailDA(int SoulID, string Email, string Satisfaction, string Info, string Privacy)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_UpdateUserDetail", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulID);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Satisfaction", Satisfaction);
                    cmd.Parameters.AddWithValue("@Info", Info);
                    cmd.Parameters.AddWithValue("@Privacy", Privacy);

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

          public string GetSoulNamebyCaseIDDA(int CaseId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetSoulNamebyCaseID", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseId", CaseId);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader();
                    da.Read();

                    return da[0].ToString();
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

          public SqlDataAdapter GetFollowingDA(int SoulId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetFollowing", con);

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

          public SqlDataAdapter GetFollowerDA(int FriendId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetFollower", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FriendID", FriendId);

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

          public SqlDataAdapter GetMutualFriendDA(int SoulId, int SearchId)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetMutualFriend", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SoulID", SoulId);
                    cmd.Parameters.AddWithValue("@SearchID", SearchId);

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
