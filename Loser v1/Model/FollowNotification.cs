using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class FollowNotification
     {
          private int NotificationType;
          private int ToID;
          private int FromID;
          private string GivenDate;
          private string GivenTime;
          private string IsReaded;

          public int _NotificationType
          {
               get { return NotificationType; }
               set { NotificationType = value; }
          }

          public int _ToID
          {
               get { return ToID; }
               set { ToID = value; }
          }

          public int _FromID
          {
               get { return FromID; }
               set { FromID = value; }
          }

          public string _GivenDate
          {
               get { return GivenDate; }
               set { GivenDate = value; }
          }

          public string _GivenTime
          {
               get { return GivenTime; }
               set { GivenTime = value; }
          }

          public string _IsReaded
          {
               get { return IsReaded; }
               set { IsReaded = value; }
          }
     }
}
