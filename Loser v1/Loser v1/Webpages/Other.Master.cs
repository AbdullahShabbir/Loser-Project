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
     public partial class Other : System.Web.UI.MasterPage
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               int total = 0;

               lb_otheruser.Text = Request.QueryString["Profile"];
               hl_name.Text = "Welcome " + Session["SoulName"];

               total += new CaseNotificationLogic().GetCaseNotificationCountbySoulIDBL(int.Parse(Session["SoulId"].ToString()));
               total += new FollowNotificationLogic().GetFollowNotificationCountbySoulIDBL(int.Parse(Session["SoulId"].ToString()));

               if (total > 0)
               {
                    lb_notification.Text = "Notification (" + total + ")";
               }

               try
               {
                    UpdateStatus();
               }
               catch (Exception)
               {
                    Response.Redirect("../Webpages/Page_Not_Found.aspx");   
               }
               
               hl_about.NavigateUrl = "../Webpages/Other_About.aspx?Profile=" + Request.QueryString["Profile"];
               hl_case.NavigateUrl = "../Webpages/Other_Case.aspx?Profile=" + Request.QueryString["Profile"];
               hl_friend.NavigateUrl = "../Webpages/Other_Friend.aspx?Profile=" + Request.QueryString["Profile"];
               hl_achievements.NavigateUrl = "../Webpages/Other_Achievement.aspx?Profile=" + Request.QueryString["Profile"];
               hl_trophy.NavigateUrl = "../Webpages/Other_Trophy.aspx?Profile=" + Request.QueryString["Profile"];
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

          public void UpdateStatus()
          {
               Follow myFollow = new Follow();
               Block myBlock = new Block();

               UserLogic userLogic = new UserLogic();
               FollowLogic followLogic = new FollowLogic();
               BlockLogic blockLogic = new BlockLogic();

               myFollow._SoulId = int.Parse(Session["SoulId"].ToString());
               myFollow._FriendSoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

               myBlock._SoulId = int.Parse(Session["SoulId"].ToString());
               myBlock._BlockedSoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

               if (followLogic.IsFollowerBL(myFollow))
               {
                    btn_follow.Text = "Un Follow";
               }
               else
               {
                    btn_follow.Text = "Follow";
               }

               if (blockLogic.IsBlockedBL(myBlock))
               {
                    btn_block.Text = "Un Block";
               }
               else
               {
                    btn_block.Text = "Block";
               }
          }

          protected void btn_follow_Click(object sender, EventArgs e)
          {
               Follow myFollow = new Follow();
               UserLogic userLogic = new UserLogic();
               FollowLogic followLogic = new FollowLogic();

               myFollow._SoulId = int.Parse(Session["SoulId"].ToString());
               myFollow._FriendSoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

               if (btn_follow.Text == "Follow")
               {
                    followLogic.FollowUserBL(myFollow);
                    giveFollowNotification();
               }
               else
               {
                    followLogic.UnFollowUserBL(myFollow);
               }

               UpdateStatus();
          }

          public void giveFollowNotification()
          {
               FollowNotificationLogic followNotificationLogic = new FollowNotificationLogic();
               FollowNotification myFollowNotification = new FollowNotification();

               myFollowNotification._NotificationType = 2;
               myFollowNotification._FromID = int.Parse(Session["SoulId"].ToString());
               myFollowNotification._ToID = new UserLogic().GetIDbySoulNameBL(Request.QueryString["Profile"]);
               myFollowNotification._GivenDate = DateTime.Now.ToShortDateString();
               myFollowNotification._GivenTime = DateTime.Now.ToShortTimeString();
               myFollowNotification._IsReaded = "No";

               followNotificationLogic.SendFollowNotificationBL(myFollowNotification);
          }

          protected void btn_block_Click(object sender, EventArgs e)
          {
               Block myBlock = new Block();
               UserLogic userLogic = new UserLogic();
               BlockLogic blockLogic = new BlockLogic();

               myBlock._SoulId = int.Parse(Session["SoulId"].ToString());
               myBlock._BlockedSoulId = userLogic.GetIDbySoulNameBL(Request.QueryString["Profile"]);

               if (btn_block.Text == "Block")
               {
                    blockLogic.BlockUserBL(myBlock);
               }
               else
               {
                    blockLogic.UnBlockUserBL(myBlock);
               }

               UpdateStatus();
          }          
     }
}