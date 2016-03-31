<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Main.Master" AutoEventWireup="true" CodeBehind="Add_Case.aspx.cs" Inherits="Loser_v1.Webpages.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="full col-sm-9">
          <div class="well">
               <div class="form-horizontal" role="form">
                    <h4>What's Your New Case</h4>
                    <div class="form-group" style="padding: 14px;">
                         <table>
                              <tr>
                                   <td style="width: 200px"> Your Case Title </td>
                                   <td style="width: 275px"> <asp:TextBox ID="tb_title" runat="server"></asp:TextBox> </td>
                                   <td> <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="tb_title" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Case Title"></asp:RequiredFieldValidator> </td>
                              </tr>
                              <tr>
                                   <td style="width: 200px"> <br /> Want to Upload any Image </td>
                                   <td style="width: 275px"> <br /> <asp:FileUpload ID="fu_Image" AllowMultiple="false" runat="server" /> </td>
                                   <td> <br /> <asp:RegularExpressionValidator ID="rev_uploadimage" runat="server" ErrorMessage="Only Images are Allowed" Display="Dynamic" ControlToValidate="fu_Image" ForeColor="Red" ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator> </td>
                              </tr>
                              <%--<tr>
                                   <td style="width: 200px"> <br /> Want to Upload any Video </td>
                                   <td style="width: 275px"> <br /> <asp:FileUpload ID="fu_Video" AllowMultiple="false" runat="server" /> </td>
                                   <td> <br /> </td>
                              </tr>--%>
                         </table>
                         <br /> <br />
                         <cc1:Editor CssClass="form-control" ID="edt_case" runat="server" />
                         <br />
                         <asp:Label ID="lb_empty" runat="server" ForeColor="Red"></asp:Label>
                    </div>

                    <asp:Button ID="btn_post" CssClass="btn btn-primary pull-right" runat="server" Text="Post" OnClick="btn_post_Click" />

                    <asp:DropDownList ID="ddl_category" runat="server">
                         <asp:ListItem Value="Select Category">Select Category</asp:ListItem>
                         <asp:ListItem Value="Education">Education</asp:ListItem>
                         <asp:ListItem Value="Bussiness">Bussiness</asp:ListItem>
                         <asp:ListItem Value="Social">Social</asp:ListItem>
                         <asp:ListItem Value="Relationship">Relationship</asp:ListItem>
                         <asp:ListItem Value="Family">Family</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="rfv_category" runat="server" ControlToValidate="ddl_category" ForeColor="Red" InitialValue="Select Category" Display="Dynamic" ErrorMessage="Select a Category"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="cb_security" runat="server" />
                    Make It Private?
               </div>
          </div>
     </div>
</asp:Content>
