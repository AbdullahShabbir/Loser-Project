using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class User_Page : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    if (Session["SoulName"] != null && Session["SoulId"] != null)
                    {
                         UpdatePage();
                    }
                    else
                    {
                         Response.Redirect("../Webpages/My_Home.aspx");
                    }
               }
          }

          protected void Timer1_Tick(object sender, EventArgs e)
          {
               UpdatePage();
          }

          public void UpdatePage()
          {
               UserLogic userLogic = new UserLogic();
               CaseLogic caseLogic = new CaseLogic();

               List<string> UserPref = userLogic.GetUserDetailBL(Session["SoulName"].ToString());

               SqlDataAdapter adapter1 = new SqlDataAdapter();
               SqlDataAdapter adapter2 = new SqlDataAdapter();

               DataSet dataSet = new DataSet();

               lb_cat1.Text = UserPref[0];

               adapter1 = caseLogic.GetCasebyCategoryBL(UserPref[0] , Session["SoulId"].ToString());
               adapter1.Fill(dataSet, "cat_1");

               CaseImageLogic caseImageLogic = new CaseImageLogic();
               adapter2 = caseImageLogic.ShowOtherCaseImageBL(int.Parse(Session["SoulId"].ToString()));
               adapter2.Fill(dataSet, "caseimage");

               dataSet.Relations.Add("myrelation", dataSet.Tables["cat_1"].Columns["case_id"], dataSet.Tables["caseimage"].Columns["case_id"], false);

               rp_1.DataSource = dataSet.Tables["cat_1"];
               rp_1.DataBind();

               //////////////////////////////////////////////

               lb_cat2.Text = UserPref[1];

               adapter1 = caseLogic.GetCasebyCategoryBL(UserPref[1] , Session["SoulId"].ToString());
               adapter1.Fill(dataSet, "cat_2");

               dataSet.Relations.Add("myrelation2", dataSet.Tables["cat_2"].Columns["case_id"], dataSet.Tables["caseimage"].Columns["case_id"], false);

               rp_2.DataSource = dataSet.Tables["cat_2"];
               rp_2.DataBind();

               //////////////////////////////////////////////

               lb_cat3.Text = UserPref[2];

               adapter1 = caseLogic.GetCasebyCategoryBL(UserPref[2], Session["SoulId"].ToString());
               adapter1.Fill(dataSet, "cat_3");

               dataSet.Relations.Add("myrelation3", dataSet.Tables["cat_3"].Columns["case_id"], dataSet.Tables["caseimage"].Columns["case_id"], false);

               rp_3.DataSource = dataSet.Tables["cat_3"];
               rp_3.DataBind();
          }

          protected void btn_detail_Click(object sender, EventArgs e)
          {
               UserLogic myLogic = new UserLogic();

               Button button = (sender as Button);

               string SoulName = myLogic.GetSoulNamebyCaseIDBL(int.Parse(button.CommandArgument.ToString()));

               Response.Cookies["CaseID"].Value = button.CommandArgument;

               Response.Redirect("Other_Detail.aspx?Profile=" + SoulName);
          }
     }
}