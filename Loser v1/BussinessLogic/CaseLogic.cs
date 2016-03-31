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
     public class CaseLogic
     {
          public int AddCaseBL(Case myCase)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.AddCaseDA(myCase);
               }
               catch
               {
                    throw;
               }
          }

         public SqlDataAdapter ShowCaseBL(int SoulId)
         {
              try
              {
                   CaseDA objCaseda = new CaseDA();
                   return objCaseda.ShowCaseDA(SoulId);
              }
              catch
              {
                   throw;
              }
         }

          public SqlDataAdapter GetPublicCasebyIDBL(int SoulID)
          {
              try
              {
                   CaseDA objCaseda = new CaseDA();
                   return objCaseda.GetPublicCasebyIDDA(SoulID);
              }
              catch
              {
                   throw;
              }
          }

          public SqlDataAdapter GetPrivateCasebyIDBL(int SoulID)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.GetPrivateCasebyIDDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetCasebyCategoryBL(string Category, string SoulId)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.GetCasebyCategoryDA(Category, SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public String[] GetCasebyIDBL(int CaseID)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.GetCasebyIDDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public int DeleteCasebyIDBL(int CaseID)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.DeleteCasebyIDDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public int UpdateCaseBL(int CaseID, Case myCase)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.UpdateCaseDA(CaseID, myCase);
               }
               catch
               {
                    throw;
               }
          }

          public String[] GetCountBL(int CaseID)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.GetCountDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public int UpdateCountBL(int CaseID, int Count_Sym, int Count_Oppor, int Count_Fac)
          {
               try
               {
                    CaseDA objCaseda = new CaseDA();
                    return objCaseda.UpdateCountDA(CaseID, Count_Sym, Count_Oppor, Count_Fac);
               }
               catch
               {
                    throw;
               }
          }
     }
}
