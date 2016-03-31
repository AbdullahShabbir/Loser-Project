using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess;

namespace BussinessLogic
{
     public class StatsLogic
     {
          public SqlDataAdapter GetCategoryStatsbyIDBL(int SoulId)
          {
               try
               {
                    StatsDA objStatsDA = new StatsDA();
                    return objStatsDA.GetCategoryStatsbyIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetTotalCategoryStatsbyIDBL(int SoulId)
          {
               try
               {
                    StatsDA objStatsDA = new StatsDA();
                    return objStatsDA.GetTotalCategoryStatsbyIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetSecurityStatsbyIDBL(int SoulId)
          {
               try
               {
                    StatsDA objStatsDA = new StatsDA();
                    return objStatsDA.GetSecurityStatsbyIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }
          public SqlDataAdapter GetRatingStatsbyIDBL(int SoulId)
          {
               try
               {
                    StatsDA objStatsDA = new StatsDA();
                    return objStatsDA.GetRatingStatsbyIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetTotalRatingStatsbyIDBL(int SoulId)
          {
               try
               {
                    StatsDA objStatsDA = new StatsDA();
                    return objStatsDA.GetTotalRatingStatsbyIDDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

     }
}
