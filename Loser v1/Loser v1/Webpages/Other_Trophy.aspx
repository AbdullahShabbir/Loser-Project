<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Other.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Other_Trophy.aspx.cs" Inherits="Loser_v1.Webpages.Other_Trophy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <div style="width:1050px;">
                    <asp:Repeater ID="rp_1" runat="server">
                         <ItemTemplate>
                              <div class="col-sm-5" style="width: 25%; margin-top: -5px">
                                   <div class="well" style="height: 380px; background-color:white">
                                        <asp:Image ID="img_trophy" style="margin-left:20px" Height="180px" Width="150" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "picture_url") %>' runat="server" />
                                        <br /><br />
                                        <h6><%# DataBinder.Eval(Container.DataItem, "description") %></h6>
                                        <br />
                                        <asp:Button ID="btn_Give" CssClass="btn btn-success" style="margin-left:12%" runat="server" Text="Give this Trophy" OnClick="btn_Give_Click" CommandArgument='<%# Eval("trophy_id") %>' />
                                        <br /><br />
                                        <asp:Label ID="lb_msg" runat="server" Font-Size="Smaller"></asp:Label>
                                   </div>
                              </div>
                         </ItemTemplate>
                    </asp:Repeater>
               </div>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
