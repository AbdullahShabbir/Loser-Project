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
     public class FollowNotificationLogic
     {
          public int SendFollowNotificationBL(FollowNotification myFollowNotification)
          {
               try
               {
                    FollowNotificationDA followNotificationDA = new FollowNotificationDA();
                    return followNotificationDA.SendFollowNotificationDA(myFollowNotification);
               }
               catch
               {
                    throw;
               }
          }

          public int GetFollowNotificationCountbySoulIDBL(int SoulID)
          {
               try
               {
                    FollowNotificationDA followNotificationDA = new FollowNotificationDA();
                    return followNotificationDA.GetFollowNotificationCountbySoulIDDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetFollowNotificationbySoulIDBL(int SoulID)
          {
               try
               {
                    FollowNotificationDA followNotificationDA = new FollowNotificationDA();
                    return followNotificationDA.GetFollowNotificationbySoulIDDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public int SetFollowMarkAsReadbyIDBL(int FollowNotificationID)
          {
               try
               {
                    FollowNotificationDA followNotificationDA = new FollowNotificationDA();
                    return followNotificationDA.SetFollowMarkAsReadbyIDDA(FollowNotificationID);
               }
               catch
               {
                    throw;
               }
          }
     }
}
