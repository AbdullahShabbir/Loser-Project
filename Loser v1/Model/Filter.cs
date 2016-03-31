using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Filter
     {
          private int SoulId;
          private string Category;
          private string Security;

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public string _Category
          {
               get { return Category; }
               set { Category = value; }
          }

          public string _Security
          {
               get { return Security; }
               set { Security = value; }
          }
     }
}
