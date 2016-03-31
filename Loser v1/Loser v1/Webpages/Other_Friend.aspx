<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Other.Master" AutoEventWireup="true" CodeBehind="Other_Friend.aspx.cs" Inherits="Loser_v1.Webpages.Other_Friend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="rp_1" runat="server" >
          <ItemTemplate>
               <a href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>'>
                    <div class="col-sm-5" style="width: 27%; top:-20px">
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

     <div class="col-sm-5" style="top:-20px">
          <asp:Label ID="lb_msg" runat="server" ForeColor="Red"></asp:Label>                         
     </div>
     
</asp:Content>
