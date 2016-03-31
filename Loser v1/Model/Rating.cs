using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Rating
     {
          private int SoulId;
          private int CategoryId;
          private int Points;

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public int _CategoryId
          {
               get { return CategoryId; }
               set { CategoryId = value; }
          }

          public int _Points
          {
               get { return Points; }
               set { Points = value; }
          }
     }
}
