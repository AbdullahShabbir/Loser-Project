using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class Your_About : System.Web.UI.Page
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
                         UserLogic userLogic = new UserLogic();

                         List<string> UserDetail = userLogic.GetUserDetailBL(Session["SoulName"].ToString());

                         lb_cat1.Text = UserDetail[0];
                         lb_cat2.Text = UserDetail[1];
                         lb_cat3.Text = UserDetail[2];
                         lb_email.Text = UserDetail[3];
                         lb_who.Text = UserDetail[4];
                         lb_satisfaction.Text = UserDetail[5];
                         lb_privacy.Text = UserDetail[6];
                    }
               }
          }
     }
}