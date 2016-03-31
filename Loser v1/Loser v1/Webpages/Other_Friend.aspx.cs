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
     public partial class Other_Friend : System.Web.UI.Page
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
                         Response.Redirect("../Webpages/Your_Followers.aspx");
                    }
                    else
                    {
                         UserLogic userLogic = new UserLogic();
                         SqlDataAdapter adapter = new SqlDataAdapter();
                         DataSet dataSet = new DataSet();

                         int SearchId = 0;

                         try
                         {
                              SearchId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);
                         }
                         catch (Exception)
                         {
                              Response.Redirect("../Webpages/Page_Not_Found.aspx");
                         }

                         List<string> UserDetail = userLogic.GetUserDetailBL(Request.QueryString["Profile"]);

                         if (UserDetail[6] == "Mutual")
                         {
                              adapter = userLogic.GetMutualFriendBL(int.Parse(Session["SoulId"].ToString()), SearchId);
                              adapter.Fill(dataSet, "MutualFriend");
                              rp_1.DataSource = dataSet.Tables["MutualFriend"];
                              rp_1.DataBind();
                         }
                         else if (UserDetail[6] == "Public")
                         {
                              adapter = userLogic.GetFollowingBL(SearchId);
                              adapter.Fill(dataSet, "Following");
                              rp_1.DataSource = dataSet.Tables["Following"];
                              rp_1.DataBind();
                         }
                         else
                         {
                              lb_msg.Text = "Friends cannot be shown as User has set its Privacy Setting to Private";
                         }
                    }
               }
          }
     }
}