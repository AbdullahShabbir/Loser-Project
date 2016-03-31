<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="User_Page.aspx.cs" Inherits="Loser_v1.Webpages.User_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../JavaScript/jquery-1.11.0.min.js"></script>
     <script src="../JavaScript/lightbox.min.js"></script>
     <link href="../CSS/lightbox.css" rel="stylesheet"/>

     <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

     <script type="text/javascript">
          var Pos1, Pos2, Pos3
          var prm = Sys.WebForms.PageRequestManager.getInstance();

          function BeginRequestHandler(sender, args) {
               if ($get('<%= Panel1.ClientID %>') != null) {
                    Pos1 = $get('<%= Panel1.ClientID %>').scrollTop;
               }

               if ($get('<%= Panel2.ClientID %>') != null) {
                    Pos2 = $get('<%= Panel2.ClientID %>').scrollTop;
               }

               if ($get('<%= Panel3.ClientID %>') != null) {
                    Pos3 = $get('<%= Panel3.ClientID %>').scrollTop;
               }
          }

          function EndRequestHandler(sender, args) {
               if ($get('<%= Panel1.ClientID %>') != null) {
                    $get('<%= Panel1.ClientID %>').scrollTop = Pos1;
               }

               if ($get('<%= Panel2.ClientID %>') != null) {
                    $get('<%= Panel2.ClientID %>').scrollTop = Pos2;
               }

               if ($get('<%= Panel3.ClientID %>') != null) {
                    $get('<%= Panel3.ClientID %>').scrollTop = Pos3;
               }
          }

          prm.add_beginRequest(BeginRequestHandler);
          prm.add_endRequest(EndRequestHandler);
     </script>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <asp:Timer ID="Timer1" Interval="1000" runat="server" OnTick="Timer1_Tick"></asp:Timer>

               <div class="padding" style="margin-top: 50px">

                    <div style="float: left; width: 32%; margin-right: 15px;">
                         <asp:Label ID="lb_cat1" runat="server"></asp:Label>
                         
                         <br /><br />

                         <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="540">
                              <asp:Repeater ID="rp_1" runat="server">
                                   <ItemTemplate>

                                        <!-- Row Starts Here  -->
                                        <div class="panel panel-default" style="margin-bottom:15px">
                                             <div class="panel-heading" style="height: 60px">
                                                  <h5 style="margin-top: -1px;">
                                                       <a class="pull-right" href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a>
                                                       <b> <%# DataBinder.Eval(Container.DataItem, "title") %> </b> &nbsp; &nbsp;
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
                                                            <asp:HyperLink ID="hl_image" NavigateUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' data-lightbox='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server"> <asp:Image ID="img_case" Height="100%" Width="100%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" /> </asp:HyperLink>
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

                    <div style="float: left; width: 32%; margin-right: 15px;">
                         <asp:Label ID="lb_cat2" runat="server"></asp:Label>    
                         
                         <br /><br />

                         <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="540">
                              <asp:Repeater ID="rp_2" runat="server">
                                   <ItemTemplate>

                                        <!-- Row Starts Here  -->
                                        <div class="panel panel-default" style="margin-bottom:15px">
                                             <div class="panel-heading" style="height: 60px">
                                                  <h5 style="margin-top: -1px;">
                                                       <a class="pull-right" href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a>
                                                       <b> <%# DataBinder.Eval(Container.DataItem, "title") %> </b> &nbsp; &nbsp;
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
                                                            <asp:HyperLink ID="hl_image" NavigateUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' data-lightbox='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server"> <asp:Image ID="img_case" Height="100%" Width="100%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" /> </asp:HyperLink>
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

                    <div style="float: left; width: 32%;">
                         <asp:Label ID="lb_cat3" runat="server"></asp:Label><br />
                         <br />

                         <asp:Panel ID="Panel3" runat="server" ScrollBars="Vertical" Height="540">
                              <asp:Repeater ID="rp_3" runat="server">
                                   <ItemTemplate>

                                        <!-- Row Starts Here  -->
                                        <div class="panel panel-default" style="margin-bottom:15px">
                                             <div class="panel-heading" style="height: 60px">
                                                  <h5 style="margin-top: -1px;">
                                                       <a class="pull-right" href='Other_About.aspx?Profile=<%# DataBinder.Eval(Container.DataItem, "soul_name") %>' style="color: cornflowerblue; text-decoration: underline"><%# DataBinder.Eval(Container.DataItem, "soul_name") %></a>

                                                       <b> <%# DataBinder.Eval(Container.DataItem, "title") %> </b> &nbsp; &nbsp;
                                                                 
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

                                                  <asp:Repeater ID="childRepeater" runat="server" DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("myrelation3") %>'>
                                                       <ItemTemplate>
                                                            <asp:HyperLink ID="hl_image" NavigateUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' data-lightbox='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server"> <asp:Image ID="img_case" Height="100%" Width="100%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" /> </asp:HyperLink>
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
