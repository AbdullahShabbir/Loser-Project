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
     public partial class Your_Notification : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    UpdateNotification();
               }
          }

          public void UpdateNotification()
          {
               CaseNotificationLogic caseNotificationLogic = new CaseNotificationLogic();
               FollowNotificationLogic followNotificationLogic = new FollowNotificationLogic();

               SqlDataAdapter adapter = new SqlDataAdapter();
               DataSet dataSet = new DataSet();

               adapter = caseNotificationLogic.GetCaseNotificationbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               adapter.Fill(dataSet, "CaseNotification");
               rp_casenotification.DataSource = dataSet.Tables["CaseNotification"];
               rp_casenotification.DataBind();

               adapter = new SqlDataAdapter();
               dataSet = new DataSet();

               adapter = followNotificationLogic.GetFollowNotificationbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               adapter.Fill(dataSet, "FollowNotification");
               rp_follownotification.DataSource = dataSet.Tables["FollowNotification"];
               rp_follownotification.DataBind();
          }

          public void CaseNotification()
          {
               CaseNotificationLogic caseNotificationLogic = new CaseNotificationLogic();
               
               SqlDataAdapter adapter = new SqlDataAdapter();
               DataSet dataSet = new DataSet();

               adapter = caseNotificationLogic.GetCaseNotificationbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               adapter.Fill(dataSet, "CaseNotification");
               rp_casenotification.DataSource = dataSet.Tables["CaseNotification"];
               rp_casenotification.DataBind();
          }

          public void FollowNotification()
          {
               FollowNotificationLogic followNotificationLogic = new FollowNotificationLogic();

               SqlDataAdapter adapter = new SqlDataAdapter();
               DataSet dataSet = new DataSet();

               adapter = followNotificationLogic.GetFollowNotificationbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               adapter.Fill(dataSet, "FollowNotification");
               rp_follownotification.DataSource = dataSet.Tables["FollowNotification"];
               rp_follownotification.DataBind();
          }

          protected void lb_gotocase_Click(object sender, EventArgs e)
          {
               LinkButton button = (sender as LinkButton);
               Response.Cookies["CaseID"].Value = button.CommandArgument;
               Response.Redirect("../Webpages/Your_Detail.aspx");
          }

          protected void lb_markcaseasread_Click(object sender, EventArgs e)
          {
               CaseNotificationLogic caseNotificationLogic = new CaseNotificationLogic();
               LinkButton button = (sender as LinkButton);
               
               caseNotificationLogic.SetCaseMarkAsReadbyIDBL(int.Parse(button.CommandArgument));

               //CaseNotification();
               UpdateNotification();
          }

          protected void lb_markfollowasread_Click(object sender, EventArgs e)
          {
               FollowNotificationLogic followNotificationLogic = new FollowNotificationLogic();
               LinkButton button = (sender as LinkButton);

               followNotificationLogic.SetFollowMarkAsReadbyIDBL(int.Parse(button.CommandArgument));

               //FollowNotification();
               UpdateNotification();
          }
     }
}