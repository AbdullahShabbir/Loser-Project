using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Achievement
     {
          private int ToID;
          private int FromID;
          private int TrophyID;
          private string GivenDate;
          private string GivenTime;

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

          public int _TrophyID
          {
               get { return TrophyID; }
               set { TrophyID = value; }
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
     }
}
