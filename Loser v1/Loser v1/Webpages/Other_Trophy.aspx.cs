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
     public partial class Other_Trophy : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    if (Session["SoulName"].ToString() == Request.QueryString["Profile"])
                    {
                         Response.Redirect("../Webpages/Your_About.aspx");
                    }
                    else
                    {
                         TrophyLogic trophyLogic = new TrophyLogic();
                         SqlDataAdapter adapter = new SqlDataAdapter();
                         DataSet dataSet = new DataSet();

                         adapter = trophyLogic.ShowAllTrophyBL();
                         adapter.Fill(dataSet, "Trophy");
                         rp_1.DataSource = dataSet.Tables["Trophy"];
                         rp_1.DataBind();
                    }
               }
          }

          protected void btn_Give_Click(object sender, EventArgs e)
          {
               UserLogic userLogic = new UserLogic();
               Button button = (sender as Button);
               Label label = (Label)rp_1.Items[int.Parse(button.CommandArgument) - 1].FindControl("lb_msg");
              
               Achievement myAchievement = new Achievement();

               myAchievement._ToID = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);
               myAchievement._FromID = int.Parse(Session["SoulId"].ToString());
               myAchievement._TrophyID = int.Parse(button.CommandArgument);
               myAchievement._GivenDate = DateTime.Now.ToShortDateString();
               myAchievement._GivenTime = DateTime.Now.ToShortTimeString();

               AchievementLogic achievementLogic = new AchievementLogic();

               if (achievementLogic.IsAchievementGivenBL(myAchievement._ToID, myAchievement._FromID, myAchievement._TrophyID))
               {
                    label.ForeColor = System.Drawing.Color.Red;
                    label.Text = "Trophy Already Given";
               }
               else
               {
                    achievementLogic.GiveTrophyBL(myAchievement);

                    label.ForeColor = System.Drawing.Color.Green;
                    label.Text = "Trophy Successfully Given";
               }
          }
     }
}