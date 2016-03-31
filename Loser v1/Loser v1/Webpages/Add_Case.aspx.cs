using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Model;
using BussinessLogic;
using System.IO;

namespace Loser_v1.Webpages
{
     public partial class WebForm1 : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (Session["SoulName"] == null && Session["SoulId"] == null)
               {
                    Response.Redirect("../Webpages/My_Home.aspx");
               }
               else
               {
                    lb_empty.Text = String.Empty;
               }
          }

          protected void btn_post_Click(object sender, EventArgs e)
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

                    caseLogic.AddCaseBL(myCase);

                    if (fu_Image.HasFile)
                    {
                         CaseImage myCaseImage = new CaseImage();
                         CaseImageLogic caseImageLogic = new CaseImageLogic();

                         System.Drawing.Image my_Image = System.Drawing.Image.FromStream(fu_Image.PostedFile.InputStream);
                         
                         myCaseImage._CaseId = caseImageLogic.GetLastestCaseIDbySoulIdBL(int.Parse(Session["SoulId"].ToString()));
                         myCaseImage._SoulId = int.Parse(Session["SoulId"].ToString());
                         myCaseImage._Image = ConvertImageToByteArray(my_Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                         caseImageLogic.AddCaseImageBL(myCaseImage);
                    }

                    //if (fu_Video.HasFile)
                    //{
                    //     CaseVideo myCaseVideo = new CaseVideo();
                    //     CaseVideoLogic caseVideoLogic = new CaseVideoLogic();

                    //     BinaryReader br = new BinaryReader(fu_Video.PostedFile.InputStream);

                    //     byte[] bytes = br.ReadBytes((int) fu_Video.PostedFile.InputStream.Length);
                         
                    //     myCaseVideo._CaseId = caseVideoLogic.GetLastestCaseIDbySoulIdBL(int.Parse(Session["SoulId"].ToString()));
                    //     myCaseVideo._SoulId = int.Parse(Session["SoulId"].ToString());
                    //     myCaseVideo._Name = Path.GetFileName(fu_Video.PostedFile.FileName);
                    //     myCaseVideo._ContentType = "video/mp4";
                    //     myCaseVideo._Data = bytes;

                    //     caseVideoLogic.AddCaseVideoBL(myCaseVideo);
                    //}

                    lb_empty.ForeColor = System.Drawing.Color.Green;
                    lb_empty.Text = "Case has been Posted Sucessfully";

                    tb_title.Text = String.Empty;
                    edt_case.Content = String.Empty;
                    ddl_category.SelectedIndex = 0;
                    cb_security.Checked = false;
               }
          }

          public byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
          {
               byte[] image;
               try
               {
                    using (MemoryStream ms = new MemoryStream())
                    {
                         imageToConvert.Save(ms, formatOfImage);
                         image = ms.ToArray();
                    }
               }
               catch (Exception) 
               { 
                    throw; 
               }
               return image;
          }
     }
}