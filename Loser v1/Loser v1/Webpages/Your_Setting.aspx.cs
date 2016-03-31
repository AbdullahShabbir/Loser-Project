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
     public partial class Your_Setting : System.Web.UI.Page
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
                         UserLogic userLogic = new UserLogic();

                         List<string> UserDetail = userLogic.GetUserDetailBL(Session["SoulName"].ToString());

                         ddl_cat_1.SelectedValue = UserDetail[0];
                         ddl_cat_2.SelectedValue = UserDetail[1];
                         ddl_cat_3.SelectedValue = UserDetail[2];

                         tb_email.Text = UserDetail[3];
                         tb_info.Text = UserDetail[4];

                         ddl_satisfaction.SelectedValue = UserDetail[5];

                         if (UserDetail[6] == "Private")
                         {
                              rb_private.Checked = true;
                         }
                         else if (UserDetail[6] == "Mutual")
                         {
                              rb_mutual.Checked = true;
                         }
                         else
                         {
                              rb_public.Checked = true;
                         }

                         lb_success.Text = String.Empty;
                         lb_quoteSucess.Text = String.Empty;
                    }
               }
          }

          protected void btn_submit_Click(object sender, EventArgs e)
          {
               UserLogic userogic = new UserLogic();
               string privacy;

               userogic.UpdateUserPrefBL(Session["SoulName"].ToString(), ddl_cat_1.SelectedItem.ToString(), ddl_cat_2.SelectedItem.ToString(), ddl_cat_3.SelectedItem.ToString());

               if(rb_private.Checked)
               {
                    privacy = "Private";
               }
               else if(rb_mutual.Checked)
               {
                    privacy = "Mutual";
               }
               else
	          {
                    privacy = "Public";
	          }

               userogic.UpdateUserDetailBL(int.Parse(Session["SoulId"].ToString()), tb_email.Text, ddl_satisfaction.SelectedValue, tb_info.Text, privacy);

               lb_quoteSucess.Text = String.Empty;
               lb_success.Text = "Changes have been made Successfully";
          }

          protected void btn_addquotes_Click(object sender, EventArgs e)
          {
               Quotation myQuotation = new Quotation();
               myQuotation._Description = tb_quotation.Text;
               myQuotation._SoulId = int.Parse(Session["SoulId"].ToString());

               QuotationLogic quoteLogic = new QuotationLogic();

               quoteLogic.AddQuotationBL(myQuotation);

               tb_quotation.Text = String.Empty;
               lb_success.Text = String.Empty;
               lb_quoteSucess.Text = "Quotation Added Sucessfully";
          }
     }
}