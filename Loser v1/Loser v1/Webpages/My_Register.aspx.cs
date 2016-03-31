using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogic;
using Model;

namespace Loser_v1.Webpages
{
     public partial class My_Register : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {

          }

          protected void btn_back_Click(object sender, EventArgs e)
          {
               Response.Redirect("../Webpages/My_Home.aspx");
          }

          protected void btn_signup_Click(object sender, EventArgs e)
          {
               if (chk_terms.Checked)
               {
                    UserLogic userLogic = new UserLogic();
                    User myUser = new User();

                    myUser._SoulName = tb_username.Text;
                    myUser._Email = tb_email.Text;
                    myUser._Password = tb_password.Text;

                    userLogic.RegisterUserBL(myUser);
                    userLogic.SetDefaultPrefBL(tb_username.Text);

                    RatingLogic ratingLogic = new RatingLogic();
                    ratingLogic.SetRatingBL(userLogic.GetIDbySoulNameBL(myUser._SoulName));

                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    lb_msg.Visible = true;
               }
          }
     }
}