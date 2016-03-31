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
     public class TrophyLogic
     {
          public SqlDataAdapter ShowAllTrophyBL()
          {
               try
               {
                    TrophyDA objTrophyda = new TrophyDA();
                    return objTrophyda.ShowAllTrophyDA();
               }
               catch
               {
                    throw;
               }
          }

          //public int GiveTrophyBL(int FromId, int ToId, int TrophyId)
          //{
          //     try
          //     {
          //          TrophyDA objTrophyda = new TrophyDA();
          //          return objTrophyda.GiveTrophyBL();
          //     }
          //     catch
          //     {
          //          throw;
          //     }
          //}
     }
}
