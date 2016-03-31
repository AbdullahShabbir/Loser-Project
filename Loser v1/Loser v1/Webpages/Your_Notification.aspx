<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Profile.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Your_Notification.aspx.cs" Inherits="Loser_v1.Webpages.Your_Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
               <div style="width: 1000px; margin-left: 15px; margin-top: -20px">
                    <h4>Recent Notifications about Cases</h4>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
                    <asp:Repeater ID="rp_casenotification" runat="server">
                         <ItemTemplate>
                              <div class="well" style="height: 30px; margin-bottom:5px">
                                   <div style="margin-top:-10px;"> 
                                        Soul Name <a href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a> has Commented on Your Case <asp:LinkButton ForeColor="DarkSeaGreen" Font-Bold="true" Font-Underline="true" ID="lb_gotocase" OnClick="lb_gotocase_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "case_id") %>' runat="server"> <%# DataBinder.Eval(Container.DataItem, "title") %> </asp:LinkButton> on <a style="color:darksalmon;"> <%# DataBinder.Eval(Container.DataItem, "date") %> </a> at <a style="color:darksalmon;"> <%# DataBinder.Eval(Container.DataItem, "time") %> </a>
                                        <asp:LinkButton CssClass="pull-right" ForeColor="CornflowerBlue" Font-Underline="true" ID="lb_markcaseasread" runat="server" OnClick="lb_markcaseasread_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "casenotification_id") %>'>Mark as Read</asp:LinkButton>
                                   </div>
                              </div>
                         </ItemTemplate>
                    </asp:Repeater>
               </ContentTemplate>
     </asp:UpdatePanel>
                    <br />
                    <h4>Recent Notifications about Followers</h4>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
                    <asp:Repeater ID="rp_follownotification" runat="server">
                         <ItemTemplate>
                              <div class="well" style="height: 30px; margin-bottom:5px">
                                   <div style="margin-top:-10px;"> 
                                        Soul Name <a href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a> has <a style="color:darkseagreen; font-weight:bold"> Followed </a> You on <a style="color:darksalmon"> <%# DataBinder.Eval(Container.DataItem, "date") %> </a> at <a style="color:darksalmon"> <%# DataBinder.Eval(Container.DataItem, "time") %> </a>
                                        <asp:LinkButton CssClass="pull-right" ForeColor="CornflowerBlue" Font-Underline="true" ID="lb_markfollowasread" runat="server" OnClick="lb_markfollowasread_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "follownotification_id") %>'>Mark as Read</asp:LinkButton>
                                   </div>
                              </div>
                         </ItemTemplate>
                    </asp:Repeater>
               </ContentTemplate>
     </asp:UpdatePanel>
               </div>
         
</asp:Content>
