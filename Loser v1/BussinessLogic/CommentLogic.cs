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
     public class CommentLogic
     {
          public int AddCommentBL(Comment myComment)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.AddCommentDA(myComment);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter ShowCommentBL(int SoulId)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.ShowCommentDA(SoulId);
               }
               catch
               {
                    throw;
               }
          }

          public SqlDataAdapter GetCommentbyCaseBL(int CaseID)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.GetCommentbyCaseDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public int ChooseBestCommentBL(int CommentID)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.ChooseBestCommentDA(CommentID);
               }
               catch
               {
                    throw;
               }
          }

          public int RemoveBestCommentBL(int CaseID)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.RemoveBestCommentDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public string[] GetBestCommentBL(int CaseID)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.GetBestCommentDA(CaseID);
               }
               catch
               {
                    throw;
               }
          }

          public int GetSoulIDbyCommentIDBL(int CommentID)
          {
               try
               {
                    CommentDA objCommentda = new CommentDA();
                    return objCommentda.GetSoulIDbyCommentIDDA(CommentID);
               }
               catch
               {
                    throw;
               }
          }

          //public decimal GetRatingBL(int CaseId)
          //{
          //     try
          //     {
          //          CommentDA objCommentda = new CommentDA();
          //          return objCommentda.GetRatingDA(CaseId);
          //     }
          //     catch
          //     {
          //          throw;
          //     }
          //}

          //public decimal GiveRatingBL(decimal Rating, int CaseId)
          //{
          //     try
          //     {
          //          CommentDA objCommentda = new CommentDA();
          //          return objCommentda.GiveRatingDA(Rating, CaseId);
          //     }
          //     catch
          //     {
          //          throw;
          //     }
          //}
     }
}
