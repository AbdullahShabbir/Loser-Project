using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class Profile : System.Web.UI.MasterPage
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               int total;

               hl_name.Text = "Welcome " + Session["SoulName"];
               lb_soulname.Text = Session["SoulName"].ToString();

               total = new CaseNotificationLogic().GetCaseNotificationCountbySoulIDBL(int.Parse(Session["SoulId"].ToString()));
               total += new FollowNotificationLogic().GetFollowNotificationCountbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               if (total > 0)
               {
                    lb_notification.Text = "Notification (" + total + ")";
               }
          }

          protected void btn_search_Click(object sender, ImageClickEventArgs e)
          {
               if (tb_search.Text == Session["SoulName"].ToString())
               {
                    Response.Redirect("../Webpages/Your_About.aspx");
               }
               else
               {
                    Response.Redirect("../Webpages/Other_About.aspx?Profile=" + tb_search.Text);
               }
          }
     }
}