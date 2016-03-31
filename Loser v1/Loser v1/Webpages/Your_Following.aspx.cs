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
     public partial class Your_Following : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    UserLogic userLogic = new UserLogic();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet dataSet = new DataSet();

                    adapter = userLogic.GetFollowingBL(int.Parse(Session["SoulId"].ToString()));
                    adapter.Fill(dataSet, "Following");
                    rp_1.DataSource = dataSet.Tables["Following"];
                    rp_1.DataBind();
               }
          }
     }
}