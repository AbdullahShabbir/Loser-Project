using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Model;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class Other_Detail : System.Web.UI.Page
     {
          String[] dataReader;

          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    CaseLogic caseLogic = new CaseLogic();

                    dataReader = caseLogic.GetCasebyIDBL(int.Parse(Request.Cookies["CaseID"].Value));

                    lb_casename.Text = dataReader[1];
                    lb_description.Text = dataReader[2];
                    lb_category.Text = dataReader[3];
                    lb_rating.Text = dataReader[4];
                    lb_date.Text = dataReader[5];
                    lb_time.Text = dataReader[6];
                    lb_soulname.Text = dataReader[7];
                    lb_sympathy.Text = "Sympathy: " + dataReader[9];
                    lb_opportunity.Text = "Opportunity: " + dataReader[10];
                    lb_facility.Text = "Facility: " + dataReader[11];

                    getBestComment();
                    getComment();
               }
          }

          protected void btn_submit_Click(object sender, EventArgs e)
          {
               if (tb_addcomment.Text != String.Empty)
               {
                    Comment myComment = new Comment();
                    CommentLogic commentLogic = new CommentLogic();

                    if (rb_opportunity.Checked)
                    {
                         myComment._Type = "Opportunity";
                         rb_opportunity.Checked = false;
                    }
                    else if (rb_facility.Checked)
                    {
                         myComment._Type = "Facility";
                         rb_facility.Checked = false;
                    }
                    else
                    {
                         myComment._Type = "Sympathy";
                         rb_sympathy.Checked = false;
                    }

                    myComment._Description = tb_addcomment.Text;
                    myComment._PostDate = DateTime.Now.ToShortDateString();
                    myComment._PostTime = DateTime.Now.ToShortTimeString();
                    myComment._SoulId = int.Parse(Session["SoulId"].ToString());
                    myComment._CaseId = int.Parse(dataReader[0]);

                    if (commentLogic.AddCommentBL(myComment) == 1)
                    {
                         CaseLogic myCase = new CaseLogic();

                         if (myComment._Type == "Sympathy")
                         {
                              myCase.UpdateCountBL(int.Parse(dataReader[0]), int.Parse(dataReader[9]) + 1, int.Parse(dataReader[10]), int.Parse(dataReader[11]));
                         }
                         else if (myComment._Type == "Opportunity")
                         {
                              myCase.UpdateCountBL(int.Parse(dataReader[0]), int.Parse(dataReader[9]), int.Parse(dataReader[10]) + 1, int.Parse(dataReader[11]));
                         }
                         else
                         {
                              myCase.UpdateCountBL(int.Parse(dataReader[0]), int.Parse(dataReader[9]), int.Parse(dataReader[10]), int.Parse(dataReader[11]) + 1);
                         }
                    }

                    tb_addcomment.Text = String.Empty;

                    giveCommentNotification();

                    getComment();
                    getCount();
               }
          }

          public void giveCommentNotification()
          {
               CaseNotificationLogic caseNotificationLogic = new CaseNotificationLogic();
               CaseNotification myCaseNotification = new CaseNotification();

               myCaseNotification._NotificationType = 1;
               myCaseNotification._FromID = int.Parse(Session["SoulId"].ToString());
               myCaseNotification._ToID = new UserLogic().GetIDbySoulNameBL(dataReader[7]);
               myCaseNotification._CaseId = int.Parse(dataReader[0]);
               myCaseNotification._GivenDate = DateTime.Now.ToShortDateString();
               myCaseNotification._GivenTime = DateTime.Now.ToShortTimeString();
               myCaseNotification._IsReaded = "No";

               caseNotificationLogic.SendCaseNotificationBL(myCaseNotification);
          }

          public void getBestComment()
          {
               CommentLogic commentLogic = new CommentLogic();
               String[] bestComment = commentLogic.GetBestCommentBL(int.Parse(dataReader[0]));

               if (bestComment != null)
               {
                    pnl_msg.Visible = false;
                    pnl_info.Visible = true;

                    lb_bsname.Text = bestComment[0];
                    lb_bsdesc.Text = bestComment[1];
                    lb_bsdate.Text = bestComment[2];
                    lb_bstime.Text = bestComment[3];
                    lb_bstype.Text = bestComment[4];
               }
               else
               {
                    pnl_msg.Visible = true;
                    pnl_info.Visible = false;
               }
          }

          public void getComment()
          {
               SqlDataAdapter adapter = new SqlDataAdapter();
               DataSet RelationSet = new DataSet();

               CommentLogic commentLogic = new CommentLogic();

               adapter = commentLogic.GetCommentbyCaseBL(int.Parse(dataReader[0]));
               adapter.Fill(RelationSet, "comment");

               rp_comment.DataSource = RelationSet.Tables["comment"];
               rp_comment.DataBind();
          }

          public void getCount()
          {
               CaseLogic myCase = new CaseLogic();
               String[] caseCount = myCase.GetCountBL(int.Parse(dataReader[0]));

               lb_sympathy.Text = "Sympathy: " + caseCount[0];
               lb_opportunity.Text = "Opportunity: " + caseCount[1];
               lb_facility.Text = "Facility: " + caseCount[2];
          }

          protected void btn_rating_Click(object sender, EventArgs e)
          {
               decimal myRating;
               Button button = (sender as Button);

               RatingLogic ratingLogic = new RatingLogic();
               myRating = ratingLogic.GetCaseRatingBL(int.Parse(dataReader[0]));

               if (myRating!=0)
               {
                    myRating = (myRating + rt_case.CurrentRating) / 2;
                    myRating = Math.Round(myRating, 2);
                    ratingLogic.GiveCaseRatingBL(myRating, int.Parse(dataReader[0]));
               }
               else
               {
                    myRating = rt_case.CurrentRating;
                    ratingLogic.GiveCaseRatingBL(myRating, int.Parse(dataReader[0]));
               }

               lb_rating.Text = myRating.ToString();
          }
     }
}