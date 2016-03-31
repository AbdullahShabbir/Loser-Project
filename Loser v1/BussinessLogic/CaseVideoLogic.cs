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
     public class CaseVideoLogic
     {
          public int GetLastestCaseIDbySoulIdBL(int SoulId)
          {
               try
               {
                    CaseVideoDA caseVideoDA = new CaseVideoDA();
                    return caseVideoDA.GetLastestCaseIDbySoulIdDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public int AddCaseVideoBL(CaseVideo myCaseVideo)
          {
               try
               {
                    CaseVideoDA caseVideoDA = new CaseVideoDA();
                    return caseVideoDA.AddCaseVideoDA(myCaseVideo);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter ShowCaseVideobySoulIDBL(int SoulId)
          {
               try
               {
                    CaseVideoDA caseVideoDA = new CaseVideoDA();
                    return caseVideoDA.ShowCaseVideobySoulIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter ShowOtherCaseVideoBL(int SoulId)
          {
               try
               {
                    CaseVideoDA caseVideoDA = new CaseVideoDA();
                    return caseVideoDA.ShowOtherCaseVideoDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
