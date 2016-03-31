<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Other.Master" AutoEventWireup="true" CodeBehind="Other_Achievement.aspx.cs" Inherits="Loser_v1.Webpages.Other_Achievement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:1050px;">
          <asp:Repeater ID="rp_1" runat="server">
               <ItemTemplate>
                    <div class="col-sm-5" style="width: 25%; margin-top: -5px">
                         <div class="well" style="height: 310px; background-color:white">
                              <asp:Image ID="img_trophy" style="margin-left:20px" Height="180px" Width="150" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "picture_url") %>' runat="server" />
                              <br /><br />
                              <h6><%# DataBinder.Eval(Container.DataItem, "description") %> <br /><br />
                              Number of Trophies: <%# DataBinder.Eval(Container.DataItem, "trophy_count") %></h6>
                         </div>
                    </div>
               </ItemTemplate>
          </asp:Repeater>
     </div>
</asp:Content>
