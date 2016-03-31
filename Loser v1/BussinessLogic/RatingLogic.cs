using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class RatingLogic
     {
          public int SetRatingBL(int SoulID)
          {
               try
               {
                    RatingDA ratingDA = new RatingDA();
                    return ratingDA.SetRatingDA(SoulID);
               }
               catch
               {
                    throw;
               }
          }

          public Rating GetPreviousRatingBL(int SoulID, int CategoryID)
          {
               try
               {
                    RatingDA ratingDA = new RatingDA();
                    return ratingDA.GetPreviousRatingDA(SoulID, CategoryID);
               }
               catch
               {
                    throw;
               }
          }


          public int UpdateRatingBL(Rating myRating)
          {
               try
               {
                    RatingDA ratingDA = new RatingDA();
                    return ratingDA.UpdateRatingDA(myRating);
               }
               catch
               {
                    throw;
               }
          }

          public decimal GetCaseRatingBL(int CaseId)
          {
               try
               {
                    RatingDA ratingDA = new RatingDA();
                    return ratingDA.GetCaseRatingDA(CaseId);
               }
               catch
               {
                    throw;
               }
          }
 
          public int GiveCaseRatingBL(decimal Rating, int CaseId)
          {
               try
               {
                    RatingDA ratingDA = new RatingDA();
                    return ratingDA.GiveCaseRatingDA(Rating, CaseId);
               }
               catch
               {
                    throw;
               }
          }
     }
}
