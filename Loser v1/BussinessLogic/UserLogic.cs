using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class UserLogic
     {
          public int RegisterUserBL(User myUser)
          {
               try
               {
                    UserDA objUserda = new UserDA();
                    return objUserda.RegisterUserDA(myUser);
               }
               catch
               {
                    throw;
               }
          }

          public String[] LoginCheckBL(string SoulName, string Password)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.LoginCheckDA(SoulName,Password);
               }
               catch
               {
                    throw;
               }
          }

          public List<String> GetUserNameBL()
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetUserNameDA();
               }
               catch
               {
                    throw;
               }
          }

          public int UpdateUserPrefBL(string SoulName, string cat_1, string cat_2, string cat_3 )
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.UpdateUserPrefDA(SoulName, cat_1, cat_2, cat_3);
               }
               catch
               {
                    throw;
               }
          }

          public int UpdateUserDetailBL(int SoulID, string Email, string Satisfaction, string Info, string Privacy)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.UpdateUserDetailDA(SoulID, Email, Satisfaction, Info, Privacy);
               }
               catch
               {
                    throw;
               }
          }

          public int SetDefaultPrefBL(string SoulName)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.SetDeafultPrefDA(SoulName);
               }
               catch
               {
                    throw;
               }
          }

          public List<string> GetUserDetailBL(string SoulName)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetUserDetailDA(SoulName);
               }
               catch
               {
                    throw;
               }
          }

          public int GetIDbySoulNameBL(string SoulName)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetIDbySoulNameDA(SoulName);
               }
               catch
               {
                    throw;
               }
          }

          public string GetSoulNamebyCaseIDBL(int CaseId)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetSoulNamebyCaseIDDA(CaseId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetFollowingBL(int SoulId)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetFollowingDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetFollowerBL(int FriendId)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetFollowerDA(FriendId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetMutualFriendBL(int SoulId, int SearchId)
          {
               try
               {
                    UserDA userDA = new UserDA();
                    return userDA.GetMutualFriendDA(SoulId, SearchId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
