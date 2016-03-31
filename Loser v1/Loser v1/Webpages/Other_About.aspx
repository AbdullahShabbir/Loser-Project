<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Other.Master" AutoEventWireup="true" CodeBehind="Other_About.aspx.cs" Inherits="Loser_v1.Webpages.Other_About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <asp:Timer ID="Timer1" Interval="1000" runat="server" OnTick="Timer1_Tick"></asp:Timer>
               
               <br /><br /><br />

               <div style="margin-top:-80px; margin-left:20px; margin-bottom:10px">
                    <asp:Label ID="lb_block" runat="server" ForeColor="Red"></asp:Label>
               </div>          
          </ContentTemplate>
     </asp:UpdatePanel>

     <div>
          <div style="width: 1000px; margin-left: 15px;">
               <div class="well">
                    <div class="form-horizontal" role="form">
                         <h4>About User</h4>
                    
                         <div class="form-group" style="padding: 14px;">
                              <p> Email Address: <asp:Label ID="lb_email" runat="server" Font-Bold="true"></asp:Label></p>
                              <p> Rating: </p>
                              <p> Favourite Topics: 
                                   <asp:Label ID="lb_cat1" runat="server" Font-Bold="true"></asp:Label>,
                                   <asp:Label ID="lb_cat2" runat="server" Font-Bold="true"></asp:Label>,
                                   <asp:Label ID="lb_cat3" runat="server" Font-Bold="true"></asp:Label>
                              </p>
                              <p> Satisfaction Status: <asp:Label ID="lb_satisfaction" runat="server" Font-Bold="true"></asp:Label> </p>
                              <p> Who I Am: <asp:Label ID="lb_who" runat="server" Font-Bold="true"></asp:Label></p>
                              <p> Privacy: <asp:Label ID="lb_privacy" runat="server" Font-Bold="true"></asp:Label></p>
                         </div>
                   </div>
               </div>
                    
               <div class="well panel-heading">
                    <p>Favourite Quotations: </p>

                    <asp:GridView ID="gv_otherquot" GridLines="None" runat="server" ShowHeader="False" EmptyDataText="No Quotation Has Been Added" CellPadding="4" ForeColor="#333333">
                         <AlternatingRowStyle BackColor="White" />
                         <EditRowStyle BackColor="#7C6F57" />
                                   <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                   <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                   <RowStyle BackColor="#E3EAEB" />
                                   <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                   <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                   <SortedAscendingHeaderStyle BackColor="#246B61" />
                                   <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                   <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
               </div>
          </div>
     </div>
</asp:Content>
