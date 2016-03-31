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
     public class CaseImageLogic
     {
          public int GetLastestCaseIDbySoulIdBL(int SoulId)
          {
               try
               {
                    CaseImageDA caseImageDA = new CaseImageDA();
                    return caseImageDA.GetLastestCaseIDbySoulIdDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public int AddCaseImageBL(CaseImage myCaseImage)
          {
               try
               {
                    CaseImageDA caseImageDA = new CaseImageDA();
                    return caseImageDA.AddCaseImageDA(myCaseImage);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter ShowCaseImagebySoulIDBL(int SoulId)
          {
               try
               {
                    CaseImageDA caseImageDA = new CaseImageDA();
                    return caseImageDA.ShowCaseImagebySoulIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter ShowOtherCaseImageBL(int SoulId)
          {
               try
               {
                    CaseImageDA caseImageDA = new CaseImageDA();
                    return caseImageDA.ShowOtherCaseImageDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
