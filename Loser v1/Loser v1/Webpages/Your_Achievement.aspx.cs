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
     public partial class Your_Achievement : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    AchievementLogic achievementLogic = new AchievementLogic();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet dataSet = new DataSet();

                    UserLogic userLogic = new UserLogic();

                    adapter = achievementLogic.GetUserAchievementBL(int.Parse(Session["SoulId"].ToString()));
                    adapter.Fill(dataSet, "Achievement");
                    rp_1.DataSource = dataSet.Tables["Achievement"];
                    rp_1.DataBind();
               }
          }
     }
}