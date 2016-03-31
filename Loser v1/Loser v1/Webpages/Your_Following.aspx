<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Profile.Master" AutoEventWireup="true" CodeBehind="Your_Following.aspx.cs" Inherits="Loser_v1.Webpages.Your_Following" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="rp_1" runat="server">
          <ItemTemplate>
               <a href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>'>
                    <div class="col-sm-5" style="width: 27%; margin-top:-20px">
                         <div class="well" style="height: 150px;">
                              <h4><%# DataBinder.Eval(Container.DataItem, "soul_name") %></h4>
                              <%# DataBinder.Eval(Container.DataItem, "email") %>
                              <br /><br />
                              <%# DataBinder.Eval(Container.DataItem, "info") %>
                         </div>
                    </div>
               </a>
          </ItemTemplate>
     </asp:Repeater>
</asp:Content>
