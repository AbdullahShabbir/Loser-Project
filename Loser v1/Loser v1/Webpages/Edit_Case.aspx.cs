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
     public partial class Edit_Case : System.Web.UI.Page
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
                         CaseLogic caseLogic = new CaseLogic();
                         String[] data = caseLogic.GetCasebyIDBL(int.Parse(Request.Cookies["CaseID"].Value));

                         tb_title.Text = data[1];
                         edt_case.Content = data[2];
                         ddl_category.SelectedValue = data[3];

                         if (data[8] == "Private")
                         {
                              cb_security.Checked = true;
                         }
                         else
                         {
                              cb_security.Checked = false;
                         }
                    }

                    lb_empty.Text = String.Empty;
               }
          }

          protected void btn_update_Click(object sender, EventArgs e)
          {
               if (edt_case.Content == String.Empty)
               {
                    lb_empty.ForeColor = System.Drawing.Color.Red;
                    lb_empty.Text = "Enter Your Case";
               }
               else
               {
                    CaseLogic caseLogic = new CaseLogic();
                    Case myCase = new Case();

                    myCase._Title = tb_title.Text;
                    myCase._Description = edt_case.Content;
                    myCase._Category = ddl_category.SelectedValue.ToString();
                    myCase._PostDate = DateTime.Now.ToShortDateString();
                    myCase._PostTime = DateTime.Now.ToShortTimeString();
                    myCase._SoulId = int.Parse(Session["SoulId"].ToString());

                    if (cb_security.Checked)
                    {
                         myCase._Security = "Private";
                    }
                    else
                    {
                         myCase._Security = "Public";
                    }

                    caseLogic.UpdateCaseBL(int.Parse(Request.Cookies["CaseID"].Value), myCase);

                    lb_empty.ForeColor = System.Drawing.Color.Green;
                    lb_empty.Text = "Case has been Updated Sucessfully";

                    tb_title.Text = String.Empty;
                    edt_case.Content = String.Empty;
                    ddl_category.SelectedIndex = 0;
                    cb_security.Checked = false;
               }
          }
     }
}