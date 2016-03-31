using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogic;
using Model;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit;

namespace Loser_v1.Webpages
{
     public partial class Your_Case : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    if (Session["SoulName"] == null && Session["SoulId"] == null)
                    {
                         Response.Redirect("../Webpages/My_Home.aspx");
                    }
                    else
                    {
                         SqlDataAdapter adapter1 = new SqlDataAdapter();
                         SqlDataAdapter adapter2 = new SqlDataAdapter();
                         //SqlDataAdapter adapter3 = new SqlDataAdapter();

                         DataSet dataSet1 = new DataSet();
                         //DataSet dataSet2 = new DataSet();

                         CaseLogic caseLogic = new CaseLogic();
                         adapter1 = caseLogic.ShowCaseBL(int.Parse(Session["SoulId"].ToString()));
                         adapter1.Fill(dataSet1, "case");

                         //dataSet2 = dataSet1;

                         CaseImageLogic caseImageLogic = new CaseImageLogic();
                         adapter2 = caseImageLogic.ShowCaseImagebySoulIDBL(int.Parse(Session["SoulId"].ToString()));
                         adapter2.Fill(dataSet1, "caseimage");

                         dataSet1.Relations.Add("myrelation", dataSet1.Tables["case"].Columns["case_id"], dataSet1.Tables["caseimage"].Columns["case_id"]);

                         //CaseVideoLogic caseVideoLogic = new CaseVideoLogic();
                         //adapter3 = caseVideoLogic.ShowCaseVideobySoulIDBL(int.Parse(Session["SoulId"].ToString()));
                         //adapter3.Fill(dataSet2, "data");

                         //dataSet1.Relations.Add("myrelation2", dataSet1.Tables["case"].Columns["case_id"], dataSet2.Tables["data"].Columns["case_id"]);

                         rp_case.DataSource = dataSet1.Tables["case"];
                         rp_case.DataBind();
                    }
               }
          }

          protected void btn_delete_Click(object sender, EventArgs e)
          {
               Button button = (sender as Button);

               CaseLogic caseLogic = new CaseLogic();
               caseLogic.DeleteCasebyIDBL(int.Parse(button.CommandArgument));

               getFilterCase();
          }

          protected void btn_detail_Click(object sender, EventArgs e)
          {
               Button button = (sender as Button);
               Response.Cookies["CaseID"].Value = button.CommandArgument;
               Response.Redirect("../Webpages/Your_Detail.aspx");
          }

          protected void btn_edit_Click(object sender, EventArgs e)
          {
               Button button = (sender as Button);
               Response.Cookies["CaseID"].Value = button.CommandArgument;

               Response.Redirect("../Webpages/Edit_Case.aspx");
          }

          protected void btn_filter_Click(object sender, EventArgs e)
          {
               getFilterCase();
          }

          public void getFilterCase()
          {
               Filter myFilter = new Filter();
               myFilter._SoulId = int.Parse(Session["SoulId"].ToString());
               myFilter._Category = ddl_category.SelectedValue;
               myFilter._Security = ddl_security.SelectedValue;

               SqlDataAdapter adapter1 = new SqlDataAdapter();
               SqlDataAdapter adapter2 = new SqlDataAdapter();
               DataSet RelationSet = new DataSet();

               FilterLogic filterLogic = new FilterLogic();
               adapter1 = filterLogic.FilterCaseBL(myFilter);
               adapter1.Fill(RelationSet, "case");

               CaseImageLogic caseImageLogic = new CaseImageLogic();
               adapter2 = caseImageLogic.ShowCaseImagebySoulIDBL(int.Parse(Session["SoulId"].ToString()));
               adapter2.Fill(RelationSet, "caseimage");

               RelationSet.Relations.Add("myrelation", RelationSet.Tables["case"].Columns["case_id"], RelationSet.Tables["caseimage"].Columns["case_id"], false);

               rp_case.DataSource = RelationSet.Tables["case"];
               rp_case.DataBind();
          }

          //protected void btn_rating_Click(object sender, EventArgs e)
          //{
          //     decimal myRating;
          //     Button button = (sender as Button);

          //     foreach (RepeaterItem item in rp_case.Items)
          //     {
          //          Rating rt_case = (Rating)item.FindControl("rt_case");

          //          if (rt_case.CurrentRating != 0)
          //          {
          //               CommentLogic commentLogic = new CommentLogic();
          //               myRating = commentLogic.GetRatingBL(int.Parse(button.CommandArgument));

          //               if (myRating == 0)
          //               {
          //                    commentLogic.GiveRatingBL(rt_case.CurrentRating, int.Parse(button.CommandArgument));
          //               }
          //               else
          //               {
          //                    myRating = (myRating + rt_case.CurrentRating) / 2;

          //                    myRating = Math.Round(myRating,2); 

          //                    commentLogic.GiveRatingBL(myRating, int.Parse(button.CommandArgument));
          //               }
          //          }
          //     }

          //     getCaseComment();
          //}
     }
}