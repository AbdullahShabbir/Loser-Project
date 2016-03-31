<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Profile.Master" AutoEventWireup="true" CodeBehind="Your_Setting.aspx.cs" Inherits="Loser_v1.Webpages.Your_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>

               <div style="width: 1000px; margin-left: 15px; margin-top: -20px">
                    <div class="form-horizonta well" role="form">
                         <div class="form-group" style="padding: 14px;">
                              <table>
                                   <tr>
                                        <td>
                                             <p>Email Address &nbsp;&nbsp;&nbsp; </p>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tb_email" runat="server" TextMode="Email" Columns="30"></asp:TextBox>
                                             <br />
                                             <br />
                                        </td>
                                   </tr>

                                   <tr>
                                        <td>
                                             <p>Favourite Topics &nbsp;&nbsp;&nbsp; </p>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tb_topic" runat="server" Columns="30"></asp:TextBox>
                                             <br />
                                             <br />
                                        </td>

                                   </tr>

                                   <tr>
                                        <td>
                                             <p>Satisfaction Status &nbsp;&nbsp;&nbsp; </p>
                                        </td>
                                        <td>
                                             <asp:DropDownList ID="ddl_satisfaction" AppendDataBoundItems="true" runat="server">
                                                  <asp:ListItem>Very Satisfied</asp:ListItem>
                                                  <asp:ListItem>Satisfied</asp:ListItem>
                                                  <asp:ListItem>Somewhat Satisfied</asp:ListItem>
                                                  <asp:ListItem>No Opinion</asp:ListItem>
                                                  <asp:ListItem>Somewhat Unsatisfied</asp:ListItem>
                                                  <asp:ListItem>Unsatisfied</asp:ListItem>
                                             </asp:DropDownList>
                                             <br />
                                             <br />
                                        </td>
                                   </tr>

                                   <tr>
                                        <td>
                                             <p>Privacy &nbsp;&nbsp;&nbsp; </p>
                                        </td>
                                        <td>
                                             <asp:RadioButton ID="rb_private" GroupName="privacy" runat="server" />
                                             Private &nbsp;&nbsp;
                                                  <asp:RadioButton ID="rb_mutual" GroupName="privacy" runat="server" />
                                             Mutual &nbsp;&nbsp;
                                                  <asp:RadioButton ID="rb_public" GroupName="privacy" runat="server" />
                                             Public
                                                  <br />
                                             <br />
                                        </td>
                                   </tr>

                                   <tr>
                                        <td>
                                             <p>Who I AM &nbsp;&nbsp;&nbsp; </p>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tb_info" runat="server" TextMode="MultiLine" Rows="6" Columns="30"></asp:TextBox>
                                        </td>
                                   </tr>
                              </table>

                              <br />
                              <br />

                              <table>
                                   <tr>
                                        <td>
                                             <p>Select Categories To View on Home Page:</p>
                                        </td>
                                   </tr>

                                   <tr>
                                        <td>

                                             <asp:DropDownList ID="ddl_cat_1" AppendDataBoundItems="true" runat="server">
                                                  <asp:ListItem>Education</asp:ListItem>
                                                  <asp:ListItem>Bussiness</asp:ListItem>
                                                  <asp:ListItem>Social</asp:ListItem>
                                                  <asp:ListItem>Relationship</asp:ListItem>
                                                  <asp:ListItem>Family</asp:ListItem>
                                             </asp:DropDownList>

                                             <asp:DropDownList ID="ddl_cat_2" runat="server">
                                                  <asp:ListItem>Education</asp:ListItem>
                                                  <asp:ListItem>Bussiness</asp:ListItem>
                                                  <asp:ListItem>Social</asp:ListItem>
                                                  <asp:ListItem>Relationship</asp:ListItem>
                                                  <asp:ListItem>Family</asp:ListItem>
                                             </asp:DropDownList>

                                             <asp:DropDownList ID="ddl_cat_3" runat="server">
                                                  <asp:ListItem>Education</asp:ListItem>
                                                  <asp:ListItem>Bussiness</asp:ListItem>
                                                  <asp:ListItem>Social</asp:ListItem>
                                                  <asp:ListItem>Relationship</asp:ListItem>
                                                  <asp:ListItem>Family</asp:ListItem>
                                             </asp:DropDownList>
                                        </td>
                                   </tr>
                                   <tr>
                                        <td>
                                             <br />
                                             <asp:Label ID="lb_success" runat="server" ForeColor="Green"></asp:Label>
                                        </td>
                                   </tr>
                              </table>

                              <asp:Button ID="btn_submit" CssClass="btn btn-info pull-right" runat="server" Text="Submit Changes" OnClick="btn_submit_Click" CausesValidation="false" />

                         </div>

                    </div>

                    <div class="well panel-heading">
                         <asp:Label ID="lb_quotation" runat="server" Text="Write Your Favourite Quotations"></asp:Label>
                         <br />
                         <br />
                         <asp:TextBox ID="tb_quotation" TextMode="MultiLine" Rows="3" Columns="35" runat="server"></asp:TextBox>
                         &nbsp;&nbsp;
                              <asp:RequiredFieldValidator ID="rfv_quote" runat="server" ControlToValidate="tb_quotation" ErrorMessage="Enter a Quote" ForeColor="Red"></asp:RequiredFieldValidator>
                         <br />
                         <br />
                         <asp:Button ID="btn_addquotes" CssClass="btn btn-info" runat="server" Text="Add Quotes" OnClick="btn_addquotes_Click" />
                         &nbsp;&nbsp;&nbsp;
                              <asp:Label ID="lb_quoteSucess" runat="server" ForeColor="Green"></asp:Label>
                    </div>
               </div>


          </ContentTemplate>
          <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btn_submit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btn_addquotes" EventName="Click" />
          </Triggers>
     </asp:UpdatePanel>

</asp:Content>
