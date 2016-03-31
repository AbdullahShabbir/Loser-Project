using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class FollowLogic
     {
          public bool IsFollowerBL(Follow myFollow)
          {
               try
               {
                    FollowDA followDA = new FollowDA();
                    return followDA.IsFollowerDA(myFollow);
               }
               catch
               {
                    throw;
               }
          }

          public int FollowUserBL(Follow myFollow)
          {
               try
               {
                    FollowDA followDA = new FollowDA();
                    return followDA.FollowUserDA(myFollow);
               }
               catch
               {
                    throw;
               }
          }

          public int UnFollowUserBL(Follow myFollow)
          {
               try
               {
                    FollowDA followDA = new FollowDA();
                    return followDA.UnFollowUserDA(myFollow);
               }
               catch
               {
                    throw;
               }
          }
     }
}
