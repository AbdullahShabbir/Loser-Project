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
     public class FilterLogic
     {
          public SqlDataAdapter FilterCaseBL(Filter myFilter)
          {
               try
               {
                    FilterDA filterDA = new FilterDA();
                    return filterDA.FilterCaseDA(myFilter);
               }
               catch
               {
                    throw;
               }
          }
     }
}
