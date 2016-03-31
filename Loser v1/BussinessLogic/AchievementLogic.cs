using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class AchievementLogic
     {
          public int GiveTrophyBL(Achievement myAchievement)
          {
               try
               {
                    AchievementDA objAchievementda = new AchievementDA();
                    return objAchievementda.GiveTrophyDA(myAchievement);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetUserAchievementBL(int SoulId)
          {
               try
               {
                    AchievementDA objAchievementda = new AchievementDA();
                    return objAchievementda.GetUserAchievementDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public bool IsAchievementGivenBL(int ToId, int FromId, int TrophyId)
          {
               try
               {
                    AchievementDA objAchievementda = new AchievementDA();
                    return objAchievementda.IsAchievementGivenDA(ToId, FromId, TrophyId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
