<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Other.Master" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Other_Case.aspx.cs" Inherits="Loser_v1.Webpages.Other_Case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

     <script type="text/javascript">
          var Pos1, Pos2
          var prm = Sys.WebForms.PageRequestManager.getInstance();

          function BeginRequestHandler(sender, args)
          {
               if ($get('<%= Panel1.ClientID %>') != null)
               {
                    Pos1 = $get('<%= Panel1.ClientID %>').scrollTop;
               }

               if ($get('<%= Panel2.ClientID %>') != null)
               {
                    Pos2 = $get('<%= Panel2.ClientID %>').scrollTop;
               }
          }

          function EndRequestHandler(sender, args)
          {
               if ($get('<%= Panel1.ClientID %>') != null)
               {
                    $get('<%= Panel1.ClientID %>').scrollTop = Pos1;
               }

               if ($get('<%= Panel2.ClientID %>') != null)
               {
                    $get('<%= Panel2.ClientID %>').scrollTop = Pos2;
               }
          }

          prm.add_beginRequest(BeginRequestHandler);
          prm.add_endRequest(EndRequestHandler);
     </script>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>

               <asp:Timer ID="Timer1" Interval="1000" runat="server" OnTick="Timer1_Tick"></asp:Timer>

               <br /><br /><br />

               <div style="margin-top:-80px; margin-left:20px;">
                    <asp:Label ID="lb_block" runat="server" ForeColor="Red"></asp:Label>
               </div>

               <div class="padding" style="margin-top:-120px;">

                    <div style="float: left; width: 40%; margin-right: 12px;">
                         <asp:Label ID="lb_public" runat="server"></asp:Label> <br /><br />

                         <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="470">
                              <asp:Repeater ID="rp_public" runat="server">
                                   <ItemTemplate>

                                        <!-- Row Starts Here  -->
                                        <div class="panel panel-default" style="margin-bottom:15px">
                                             <div class="panel-heading" style="height: 60px">
                                                  <h5 style="margin-top: -1px;">
                                                       <a class="pull-right" href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a>
                                                       <b> <%# DataBinder.Eval(Container.DataItem, "title") %> </b> &nbsp; &nbsp;
                                                       <asp:Label ID="lb_category" runat="server" Font-Size="Small">[<%# DataBinder.Eval(Container.DataItem, "category") %>] </asp:Label>
                                                       <h6>
                                                            Date: <%# DataBinder.Eval(Container.DataItem, "date") %>
                                                            &nbsp; &nbsp; &nbsp;
                                                            Time Posted: <%# DataBinder.Eval(Container.DataItem, "time") %>
                                                       </h6>
                                                  </h5>
                                             </div>

                                             <div class="panel-body">

                                                  <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                  <br />

                                                  <asp:Repeater ID="childRepeater" runat="server" DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("myrelation") %>'>
                                                       <ItemTemplate>
                                                            <asp:Image ID="img_case" Height="100%" Width="100%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" />
                                                            <br />
                                                            <br />
                                                       </ItemTemplate>
                                                  </asp:Repeater>

                                                  Opportunity: <%# DataBinder.Eval(Container.DataItem, "count_oppor") %> &nbsp; &nbsp; &nbsp;
                                                  Sympathy: <%# DataBinder.Eval(Container.DataItem, "count_sym") %> &nbsp; &nbsp; &nbsp;
                                                  Facility: <%# DataBinder.Eval(Container.DataItem, "count_fac") %>
                                                  <br />
                                                  <br />
                                                  <asp:Button ID="btn_detail" runat="server" Text="Show Detail" CssClass="btn btn-info" OnClick="btn_detail_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "case_id") %>' />

                                             </div>
                                        </div>
                                        <!-- Row Ends Here  -->

                                   </ItemTemplate>
                              </asp:Repeater>
                         </asp:Panel>
                    </div>

                    <div style="float: left; width: 40%;">
                         <asp:Label ID="lb_private" runat="server"></asp:Label> <br /><br />

                         <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="470">
                              <asp:Repeater ID="rp_private" runat="server">
                                   <ItemTemplate>

                                        <!-- Row Starts Here  -->
                                        <div class="panel panel-default" style="margin-bottom:15px">
                                             <div class="panel-heading" style="height: 60px">
                                                  <h5 style="margin-top: -1px;">
                                                       <a class="pull-right" href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a>
                                                       <b> <%# DataBinder.Eval(Container.DataItem, "title") %> </b> &nbsp; &nbsp;
                                                       <asp:Label ID="lb_category" runat="server" Font-Size="Small">[<%# DataBinder.Eval(Container.DataItem, "category") %>] </asp:Label>
                                                       <h6>
                                                            Date: <%# DataBinder.Eval(Container.DataItem, "date") %>
                                                            &nbsp; &nbsp; &nbsp;
                                                            Time Posted: <%# DataBinder.Eval(Container.DataItem, "time") %>
                                                       </h6>
                                                  </h5>
                                             </div>

                                             <div class="panel-body">

                                                  <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                  <br />

                                                  <asp:Repeater ID="childRepeater" runat="server" DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("myrelation2") %>'>
                                                       <ItemTemplate>
                                                            <asp:Image ID="img_case" Height="100%" Width="100%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" />
                                                            <br />
                                                            <br />
                                                       </ItemTemplate>
                                                  </asp:Repeater>

                                                  Opportunity: <%# DataBinder.Eval(Container.DataItem, "count_oppor") %> &nbsp; &nbsp; &nbsp;
                                                  Sympathy: <%# DataBinder.Eval(Container.DataItem, "count_sym") %> &nbsp; &nbsp; &nbsp;
                                                  Facility: <%# DataBinder.Eval(Container.DataItem, "count_fac") %>
                                                  <br />
                                                  <br />
                                                  <asp:Button ID="btn_detail" runat="server" Text="Show Detail" CssClass="btn btn-info" OnClick="btn_detail_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "case_id") %>' />

                                             </div>
                                        </div>
                                        <!-- Row Ends Here  -->

                                   </ItemTemplate>
                              </asp:Repeater>
                         </asp:Panel>
                    </div>

               </div>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
