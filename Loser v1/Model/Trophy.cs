using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Trophy
     {
          private int TrophyID;
          private string Description;
          private string PictureURL;

          public int _TrophyID
          {
               get { return TrophyID; }
          }

          public string _Description
          {
               get { return Description; }
               set { Description = value; }
          }

          public string _PictureURL
          {
               get { return PictureURL; }
               set { PictureURL = value; }
          }
     }
}
