<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Main.Master" AutoEventWireup="true" CodeBehind="Edit_Case.aspx.cs" Inherits="Loser_v1.Webpages.Edit_Case" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <div class="padding">
                    <div class="full col-sm-9">

                         <!-- Row Starts Here  -->
                         <div class="row">

                              <div class="well">

                                   <div class="form-horizontal" role="form">
                                        <h4>Edit Your Case</h4>
                                        <div class="form-group" style="padding: 14px;">
                                             Your Case Title <asp:TextBox ID="tb_title" runat="server"></asp:TextBox>
                                             &nbsp;
                                             <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="tb_title" ForeColor="Red" ErrorMessage="Enter Case Title"></asp:RequiredFieldValidator>
                                             <br /><br />
                                             <cc1:Editor CssClass="form-control" ID="edt_case" runat="server" />
                                             <br />
                                             <asp:Label ID="lb_empty" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                        <asp:Button ID="btn_update" CssClass="btn btn-primary pull-right" runat="server" Text="Update" OnClick="btn_update_Click" />

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
                                        <asp:CheckBox ID="cb_security" runat="server" /> Make It Private?
                                   </div>

                              </div>

                         </div>
                         <!-- Row End Here  -->
                    </div>
               </div>
          </ContentTemplate>
          <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btn_update" EventName="Click" />
          </Triggers>
     </asp:UpdatePanel>
</asp:Content>
