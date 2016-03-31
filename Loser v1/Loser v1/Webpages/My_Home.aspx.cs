using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class My_Home : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               Session["SoulId"] = null;
               Session["SoulName"] = null;

               //Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
          }

          protected void btn_login_Click(object sender, EventArgs e)
          {
               UserLogic userLogic = new UserLogic();
               String[] Info = userLogic.LoginCheckBL(tb_soulname.Text, tb_password.Text);

               if (int.Parse(Info[0]) != 0)
               {
                    Session["SoulId"] = int.Parse(Info[0]);
                    Session["SoulName"] = Info[1];
                    Response.Redirect("../Webpages/User_Page.aspx");
               }
          }
     }
}