using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Loser_v1
{
     public class Global : System.Web.HttpApplication
     {

          protected void Application_Start(object sender, EventArgs e)
          {
               
          }

          protected void Session_Start(object sender, EventArgs e)
          {
               Session["SoulId"] = null;
               Session["SoulName"] = null;
          }

          protected void Application_BeginRequest(object sender, EventArgs e)
          {

          }

          protected void Application_AuthenticateRequest(object sender, EventArgs e)
          {

          }

          protected void Application_Error(object sender, EventArgs e)
          {
               //Response.Redirect("../Webpages/Page_Not_Found.aspx");
          }

          protected void Session_End(object sender, EventArgs e)
          {
               Session["SoulId"] = null;
               Session["SoulName"] = null;
          }

          protected void Application_End(object sender, EventArgs e)
          {
               Session["SoulId"] = null;
               Session["SoulName"] = null;
          }
     }
}