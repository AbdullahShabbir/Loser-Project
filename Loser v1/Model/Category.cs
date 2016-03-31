using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Category
     {
          private int CategoryID;
          private string Name;

          public int _CategoryID
          {
               get { return CategoryID; }
          }

          public string _Name
          {
               get { return Name; }
               set { Name = value; }
          }
     }
}
