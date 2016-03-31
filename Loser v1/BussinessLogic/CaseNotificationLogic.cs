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
     public class CaseNotificationLogic
     {
          public int SendCaseNotificationBL(CaseNotification myCaseNotification)
          {
               try
               {
                    CaseNotificationDA caseNotificationDA = new CaseNotificationDA();
                    return caseNotificationDA.SendCaseNotificationDA(myCaseNotification);
               }
               catch
               {
                    throw;
               }
          }

          public int GetCaseNotificationCountbySoulIDBL(int SoulID)
          {
               try
               {
                    CaseNotificationDA caseNotificationDA = new CaseNotificationDA();
                    return caseNotificationDA.GetCaseNotificationCountbySoulIDDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetCaseNotificationbySoulIDBL(int SoulID)
          {
               try
               {
                    CaseNotificationDA caseNotificationDA = new CaseNotificationDA();
                    return caseNotificationDA.GetCaseNotificationbySoulIDDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public int SetCaseMarkAsReadbyIDBL(int CaseNotificationID)
          {
               try
               {
                    CaseNotificationDA caseNotificationDA = new CaseNotificationDA();
                    return caseNotificationDA.SetCaseMarkAsReadbyIDDA(CaseNotificationID);
               }
               catch
               {
                    throw;
               }
          }
     }
}
