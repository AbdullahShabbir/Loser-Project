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
     public partial class Other_About : System.Web.UI.Page
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
                         if (Session["SoulName"].ToString() == Request.QueryString["Profile"])
                         {
                              Response.Redirect("../Webpages/Your_About.aspx");
                         }
                         else
                         {
                              setStatus();

                              UserLogic userLogic = new UserLogic();

                              List<string> UserDetail = userLogic.GetUserDetailBL(Request.QueryString["Profile"]);

                              lb_cat1.Text = UserDetail[0];
                              lb_cat2.Text = UserDetail[1];
                              lb_cat3.Text = UserDetail[2];
                              lb_email.Text = UserDetail[3];
                              lb_who.Text = UserDetail[4];
                              lb_satisfaction.Text = UserDetail[5];
                              lb_privacy.Text = UserDetail[6];

                              int OtherId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

                              QuotationLogic quotLogic = new QuotationLogic();
                              SqlDataAdapter dataAdapter = quotLogic.GetQuotationbySoulNameBL(OtherId);

                              DataSet mySet = new DataSet();
                              dataAdapter.Fill(mySet, "Quotation");

                              gv_otherquot.DataSource = mySet;
                              gv_otherquot.DataBind();
                         }
                    }
               }
          }

          public void setStatus()
          {
               UserLogic userLogic = new UserLogic();
               BlockLogic blockLogic = new BlockLogic();
               Block myBlock = new Block();

               try
               {
                    myBlock._SoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);
               }
               catch (Exception)
               {
                    Response.Redirect("../Webpages/Page_Not_Found.aspx");     
               }
               
               myBlock._BlockedSoulId = int.Parse(Session["SoulId"].ToString());

               if (blockLogic.IsBlockedBL(myBlock))
               {
                    lb_block.Text = "You Have Been Blocked By The User";
               }
               else
               {
                    lb_block.Text = String.Empty;
               }
          }

          protected void Timer1_Tick(object sender, EventArgs e)
          {
               setStatus();
          }
     }
}