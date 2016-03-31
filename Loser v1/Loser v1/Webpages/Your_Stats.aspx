<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Profile.Master" AutoEventWireup="true" CodeBehind="Your_Stats.aspx.cs" Inherits="Loser_v1.Webpages.Your_Stats" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-5" style="margin-bottom:40px">
          <asp:Chart ID="cht_PieCategory" Height="400px" Width="480px" runat="server">
               <Series>
                    <asp:Series Name="main_Series" ChartType="Doughnut" ChartArea="main_Area"></asp:Series>
               </Series>

               <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Percentage of Cases in Categories"></asp:Title>
               </Titles>

               <Legends>
                    <asp:Legend Title="Type of Categories"></asp:Legend>
               </Legends>

               <ChartAreas>
                    <asp:ChartArea Name="main_Area" Area3DStyle-Enable3D="true"></asp:ChartArea>
               </ChartAreas>
          </asp:Chart>
     </div>

     <div class="col-sm-5" style="margin-bottom:40px">
          <asp:Chart ID="cht_BarCategory" Height="400px" Width="480px" runat="server">
               <Series>
                    <asp:Series Name="main_Series" ChartType="Column" ChartArea="main_Area" IsValueShownAsLabel="true"></asp:Series>
               </Series>

               <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Number of Cases in Categories"></asp:Title>
               </Titles>

               <ChartAreas>
                    <asp:ChartArea Name="main_Area" Area3DStyle-Enable3D="true"></asp:ChartArea>
               </ChartAreas>
          </asp:Chart>
     </div>

     <div class="col-sm-5" style="margin-bottom:40px">
          <asp:Chart ID="cht_PieRating" Height="400px" Width="480px" runat="server">
               <Series>
                    <asp:Series Name="main_Series" ChartType="Doughnut" ChartArea="main_Area"></asp:Series>
               </Series>

               <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Percentage of Rating Across different Categories"></asp:Title>
               </Titles>

               <Legends>
                    <asp:Legend Title="Type of Category"></asp:Legend>
               </Legends>

               <ChartAreas>
                    <asp:ChartArea Name="main_Area" Area3DStyle-Enable3D="true"></asp:ChartArea>
               </ChartAreas>
          </asp:Chart>
     </div>

     <div class="col-sm-5" style="margin-bottom:40px">
          <asp:Chart ID="cht_BarRating" Height="400px" Width="480px" runat="server">
               <Series>
                    <asp:Series Name="main_Series" ChartType="Column" ChartArea="main_Area" IsValueShownAsLabel="true"></asp:Series>
               </Series>

               <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Number of Points in Categories"></asp:Title>
               </Titles>

               <ChartAreas>
                    <asp:ChartArea Name="main_Area" Area3DStyle-Enable3D="true">
                         <AxisX>
                              <LabelStyle Font="50px"/>
                         </AxisX>
                    </asp:ChartArea>
               </ChartAreas>
          </asp:Chart>
     </div>

     <div class="col-sm-5" style="margin-bottom:40px">
          <asp:Chart ID="cht_PieSecurity" Height="400px" Width="480px" runat="server">
               <Series>
                    <asp:Series Name="main_Series" ChartType="Doughnut" ChartArea="main_Area"></asp:Series>
               </Series>

               <Titles>
                    <asp:Title Font="Trebuchet MS, 10pt, style=Bold" Text="Percentage of Public/Private Case"></asp:Title>
               </Titles>

               <Legends>
                    <asp:Legend Title="Type of Security"></asp:Legend>
               </Legends>

               <ChartAreas>
                    <asp:ChartArea Name="main_Area" Area3DStyle-Enable3D="true"></asp:ChartArea>
               </ChartAreas>
          </asp:Chart>
     </div>
</asp:Content>
