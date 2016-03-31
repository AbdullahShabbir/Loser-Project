using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class CategoryLogic
     {
          public int GetCategoryIDbyNameBL(string Name)
          {
               try
               {
                    CategoryDA objCategoryda = new CategoryDA();
                    return objCategoryda.GetCategoryIDbyNameDA(Name);
               }
               catch
               {
                    throw;
               }
          }
     }
}
