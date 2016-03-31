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
     public class QuotationLogic
     {
          public int AddQuotationBL(Quotation myQuotation)
          {
               try
               {
                    QuotationDA quoteDA = new QuotationDA();
                    return quoteDA.AddQuotationDA(myQuotation);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetQuotationbySoulNameBL(int SoulId)
          {
               try
               {
                    QuotationDA quoteDA = new QuotationDA();
                    return quoteDA.GetQuotationbySoulNameDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
