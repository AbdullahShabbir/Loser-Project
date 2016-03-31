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

namespace Loser_v1.Webpages
{
     public partial class Other_Case : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    if (!IsPostBack)
                    {
                         if (Session["SoulName"].ToString() == Request.QueryString["Profile"])
                         {
                              Response.Redirect("../Webpages/Your_Case.aspx");
                         }
                         else
                         {
                              getData();
                         }
                    }
               }
          }

          protected void btn_detail_Click(object sender, EventArgs e)
          {
               Button button = (sender as Button);

               Response.Cookies["CaseID"].Value = button.CommandArgument;
               
               Response.Redirect("Other_Detail.aspx?Profile=" + Request.QueryString["Profile"]);
          }

          protected void Timer1_Tick(object sender, EventArgs e)
          {
               getData();
          }

          public void getData()
          {
               lb_public.Text = String.Empty;
               lb_private.Text = String.Empty;

               Block myBlock = new Block();
               BlockLogic blockLogic = new BlockLogic();
               UserLogic userLogic = new UserLogic();

               try
               {
                    myBlock._SoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);
               }
               catch (Exception)
               {
                    Response.Redirect("../Webpages/Page_Not_Found.aspx");   
               }
               
               myBlock._BlockedSoulId = int.Parse(Session["SoulId"].ToString());

               if (!blockLogic.IsBlockedBL(myBlock))
               {
                    Panel1.Visible = true;
                    lb_block.Text = String.Empty;
                    lb_public.Text = "Public Case";

                    CaseLogic caseLogic = new CaseLogic();
                    FollowLogic followLogic = new FollowLogic();
                    Follow myFollow = new Follow();

                    myFollow._SoulId = int.Parse(Session["SoulId"].ToString());
                    myFollow._FriendSoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

                    SqlDataAdapter publicAdapter = new SqlDataAdapter();
                    SqlDataAdapter adapter2 = new SqlDataAdapter();
                    DataSet publicSet = new DataSet();

                    publicAdapter = caseLogic.GetPublicCasebyIDBL(myFollow._FriendSoulId);

                    publicAdapter.Fill(publicSet, "publiccase");

                    CaseImageLogic caseImageLogic = new CaseImageLogic();
                    adapter2 = caseImageLogic.ShowCaseImagebySoulIDBL(userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]));
                    adapter2.Fill(publicSet, "caseimage");

                    publicSet.Relations.Add("myrelation", publicSet.Tables["publiccase"].Columns["case_id"], publicSet.Tables["caseimage"].Columns["case_id"]);

                    rp_public.DataSource = publicSet.Tables["publiccase"];
                    rp_public.DataBind();

                    if (followLogic.IsFollowerBL(myFollow))
                    {
                         Panel2.Visible = true;
                         lb_private.Text = "Private Case";

                         SqlDataAdapter privateAdapter = new SqlDataAdapter();
                         DataSet privateSet = new DataSet();

                         privateAdapter = caseLogic.GetPrivateCasebyIDBL(myFollow._FriendSoulId);
                         privateAdapter.Fill(privateSet, "privatecase");

                         adapter2.Fill(privateSet, "caseimage");

                         privateSet.Relations.Add("myrelation2", privateSet.Tables["privatecase"].Columns["case_id"], privateSet.Tables["caseimage"].Columns["case_id"],false);

                         rp_private.DataSource = privateSet.Tables["privatecase"];
                         rp_private.DataBind();
                    }
                    else
                    {
                        Panel2.Visible = false;

                        rp_private.DataSource = null;
                        rp_private.DataBind();
                    }
               }
               else
               {
                    lb_block.Text = "You Have Been Blocked By The User";

                    Panel1.Visible = false;
                    Panel2.Visible = false;

                    rp_public.DataSource = null;
                    rp_public.DataBind();

                    rp_private.DataSource = null;
                    rp_private.DataBind();
               }
          }
     }
}