<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Main.Master" AutoEventWireup="true" CodeBehind="Your_Case.aspx.cs" Inherits="Loser_v1.Webpages.Your_Case" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="../JavaScript/jquery-1.11.0.min.js"></script>
     <script src="../JavaScript/lightbox.min.js"></script>
     <link href="../CSS/lightbox.css" rel="stylesheet"/>
     <link href="../CSS/rating.css" rel="stylesheet" />
     <script src="http://jwpsrv.com/library/Z8utMMdGEeSzuhJtO5t17w.js"></script>
     <script src="../JavaScript/flowplayer-3.1.4.min.js" type="text/javascript"></script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <div class="padding">
                    <!-- content -->
                    <div class="full col-sm-9">
                         Security:
                         <asp:DropDownList ID="ddl_security" runat="server">
                              <asp:ListItem Value="Any">Any</asp:ListItem>
                              <asp:ListItem Value="Private">Private</asp:ListItem>
                              <asp:ListItem Value="Public">Public</asp:ListItem>
                         </asp:DropDownList>
                         &nbsp; &nbsp;&nbsp; &nbsp;Category:
                         <asp:DropDownList ID="ddl_category" runat="server">
                              <asp:ListItem Value="Any">Any</asp:ListItem>
                              <asp:ListItem Value="Education">Education</asp:ListItem>
                              <asp:ListItem Value="Bussiness">Bussiness</asp:ListItem>
                              <asp:ListItem Value="Social">Social</asp:ListItem>
                              <asp:ListItem Value="Relationship">Relationship</asp:ListItem>
                              <asp:ListItem Value="Family">Family</asp:ListItem>
                         </asp:DropDownList>
                         &nbsp; &nbsp;&nbsp; &nbsp;
                         <asp:Button ID="btn_filter" runat="server" Text="Filter Your Case" CssClass="btn btn-success" OnClick="btn_filter_Click" />

                         <br />
                         <br />

                         <!-- Reapeater Starts Here -->
                         <asp:Repeater ID="rp_case" runat="server">
                              <ItemTemplate>

                                   <!-- Row Starts Here  -->
                                   <div class="panel panel-default" style="margin-bottom: 15px">
                                        <div class="panel-heading" style="height: 60px;">
                                             <h4 style="margin-top: -2px">
                                                  <asp:Label ID="lb_soulname" runat="server" CssClass="pull-right"> <%# DataBinder.Eval(Container.DataItem, "soul_name") %></asp:Label>
                                                  <asp:Label ID="lb_casename" runat="server"><%# DataBinder.Eval(Container.DataItem, "title") %></asp:Label>
                                                  &nbsp; &nbsp;
                                                  <asp:Label ID="lb_rating" runat="server" Text="Rated: " Font-Size="Small" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "rating") %> </asp:Label>
                                                  &nbsp; &nbsp;
                                                  <asp:Label ID="lb_category" runat="server" Font-Size="Small" Font-Bold="true">[<%# DataBinder.Eval(Container.DataItem, "category") %>] </asp:Label>
                                                  &nbsp; &nbsp;
                                                  <asp:Label ID="lb_security" runat="server" Font-Size="Small" Font-Bold="true"><%# DataBinder.Eval(Container.DataItem, "security") %> </asp:Label>

                                                  <h6>
                                                       Date: <%# DataBinder.Eval(Container.DataItem, "date") %>
                                                       &nbsp; &nbsp; &nbsp;
                                                       Time Posted: <%# DataBinder.Eval(Container.DataItem, "time") %>
                                                  </h6>
                                             </h4>
                                        </div>

                                        <div class="panel-body">
                                             <%# DataBinder.Eval(Container.DataItem, "description") %>
                                             <br />

                                             <asp:Repeater ID="childRepeater" runat="server" DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("myrelation") %>'>
                                                  <ItemTemplate>
                                                       <asp:HyperLink ID="hl_image" NavigateUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' data-lightbox='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server"> <asp:Image ID="img_case" Height="50%" Width="50%" ImageUrl='<%# Eval("[\"case_id\"]", "~/Services/ImageHandler.ashx?case_id={0}") %>' runat="server" /> </asp:HyperLink>
                                                       <br />
                                                       <br />
                                                  </ItemTemplate>
                                             </asp:Repeater>

                                             <%--<asp:Repeater ID="videoReapeater" runat="server" DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("myrelation2") %>'>
                                                  <ItemTemplate>
                                                       <a href='<%# Eval("[\"case_id\"]", "../Services/VideoHandler.ashx?case_id={0}") %>' style="display:block; width:400px; height:300px" id="player"></a>
    
                                                       <script type="text/javascript">
                                                           flowplayer("player", "../JavaScript/flowplayer-3.1.5.swf", {
                                                                plugins: {
                                                                     pseudo: { url: "../JavaScript/flowplayer.pseudostreaming-3.2.13.swf" }
                                                                },
                                                                 clip: { provider: 'pseudo', autoPlay: false },
                                                           });
                                                      </script>


                                                       <div id='playerCBuxkKTLrnCk'></div>
                                             
                                                       <script type='text/javascript'>
                                                            jwplayer('playerCBuxkKTLrnCk').setup
                                                            ({
                                                                 file: '../Image/a.mp4',
                                                                 image: '//www.longtailvideo.com/content/images/jw-player/lWMJeVvV-876.jpg',
                                                                 width: '480',
                                                                 height: '270'
                                                            });
                                                       </script>

                                                       <br />
                                                       <br />
                                                  </ItemTemplate>
                                             </asp:Repeater>--%>

                                             Opportunity: <%# DataBinder.Eval(Container.DataItem, "count_oppor") %> &nbsp; &nbsp; &nbsp;
                                             Sympathy: <%# DataBinder.Eval(Container.DataItem, "count_sym") %> &nbsp; &nbsp; &nbsp;
                                             Facility: <%# DataBinder.Eval(Container.DataItem, "count_fac") %>
                                             <br />
                                             <br />
                                             <asp:Button ID="btn_detail" runat="server" Text="Show Detail" CssClass="btn btn-info" OnClick="btn_detail_Click" CommandArgument='<%# Eval("case_id") %>' />
                                             <asp:Button ID="btn_edit" runat="server" Text="Edit Case" CssClass="btn btn-primary" OnClick="btn_edit_Click" CommandArgument='<%# Eval("case_id") %>' />
                                             <asp:Button ID="btn_delete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btn_delete_Click" CommandArgument='<%# Eval("case_id") %>' />
                                             <ajaxToolkit:ConfirmButtonExtender ID="cbe_delete" TargetControlID="btn_delete" ConfirmText="Are You Sure? All Comments will also be Deleted" runat="server"></ajaxToolkit:ConfirmButtonExtender>
                                        </div>
                                   </div>
                                   <!-- Row Ends Here  -->

                              </ItemTemplate>
                         </asp:Repeater>
                         <!-- Reapeater Ends Here -->

                    </div>
                    <!-- content -->
               </div>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
