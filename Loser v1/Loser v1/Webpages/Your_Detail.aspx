<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Your_Detail.aspx.cs" Inherits="Loser_v1.Webpages.Your_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>

               <div class="padding">
                    <div class="full col-sm-9">

                         <div class="panel panel-default">

                              <div class="panel-heading" style="height: 60px;">
                                   <h4 style="margin-top: -2px">
                                        <asp:Label CssClass="pull-right" ID="lb_soulname" runat="server"></asp:Label>
                                        <asp:Label ID="lb_casename" runat="server"></asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="lb_rating" runat="server" Text="Rated: " Font-Size="Small" Font-Bold="true"></asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="lb_category" runat="server" Font-Size="Small" Font-Bold="true"></asp:Label>

                                        <h6>
                                             Date: <asp:Label ID="lb_date" runat="server"></asp:Label>
                                             &nbsp; &nbsp; &nbsp;
                                             Time Posted: <asp:Label ID="lb_time" runat="server"></asp:Label>
                                        </h6>
                                   </h4>
                              </div>

                              <div class="panel-body" />
                              <p>
                                   <asp:Label ID="lb_description" runat="server"></asp:Label>
                              </p>
                              <br />
                              <asp:Label ID="lb_opportunity" runat="server" Text="Opportunity: "></asp:Label> &nbsp; &nbsp; &nbsp;
                              <asp:Label ID="lb_sympathy" runat="server" Text="Sympathy: "></asp:Label> &nbsp; &nbsp; &nbsp;
                              <asp:Label ID="lb_facility" runat="server" Text="Facility: "></asp:Label>

                              <hr />

                              <div class="input-group">
                                   <asp:TextBox ID="tb_addcomment" CssClass="form-control" placeholder="Add a comment..." runat="server" Rows="4" Columns="75" TextMode="MultiLine"></asp:TextBox>
                                   <br />
                                   <asp:RadioButton ID="rb_opportunity" runat="server" GroupName="function" /> Opportunity 
                                   <asp:RadioButton ID="rb_facility" runat="server" GroupName="function" /> Facility
                                   <asp:RadioButton ID="rb_sympathy" runat="server" GroupName="function" /> Sympathy
                                   <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="btn_submit_Click" />
                                   
                                   <%--<p>
                                        <br />
                                        <ajaxToolkit:Rating ID="rt_case" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" runat="server"></ajaxToolkit:Rating>
                                        &nbsp; &nbsp;
                                        <asp:Button ID="btn_rating" CommandArgument='<%# Eval("case_id") %> ' runat="server" Text="Rate it" Font-Size="Small" CssClass="btn btn-primary" OnClick="btn_rating_Click" />
                                        </p>--%>
                              </div>

                              <hr />

                              <div class="col-sm-7">
                                   <div class="panel panel-default" style="margin-bottom:10px">
                                        <div class="panel-heading">
                                             <h4>Best Comment</h4>
                                             <asp:Panel ID="pnl_msg" runat="server">
                                                  <asp:Label ID="lb_bsmsg" runat="server" Text="No Best Comment Selected"></asp:Label>
                                             </asp:Panel>
                                             <asp:Panel ID="pnl_info" runat="server">
                                                  Comment By:
                                                  <asp:Label ID="lb_bsname" runat="server" Font-Bold="true" Text=""></asp:Label>
                                                  <br />
                                                  <h6>Date:
                                                       <asp:Label ID="lb_bsdate" runat="server" Text=""></asp:Label>&nbsp; &nbsp; &nbsp;
                                                            Time Posted:
                                                       <asp:Label ID="lb_bstime" runat="server" Text=""></asp:Label>&nbsp; &nbsp; &nbsp;
                                                            Type:
                                                       <asp:Label ID="lb_bstype" runat="server" Text=""></asp:Label>
                                                  </h6>
                                                  <asp:Label ID="lb_bsdesc" runat="server" Text=""></asp:Label>
                                             </asp:Panel>
                                        </div>
                                   </div>
                              
                                   <div class="panel panel-default" style="height: 40px; margin-bottom:15px;">
                                        <h4 class="panel-heading" style="margin-top:0px">Other Comments</h4>
                                   </div>
                              </div>

                              <!-- Reapeater For Comments Starts -->
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                                        <asp:Repeater ID="rp_comment" runat="server">
                                             <ItemTemplate>
                                                  <div class="col-sm-7">
                                                       Comment By: <strong><%# DataBinder.Eval(Container.DataItem, "soul_name")%> </strong>
                                                       <asp:Button ID="btn_best" runat="server" Text="Select as Best Answer" CssClass="btn-link" CommandArgument='<%# Eval("comment_id") %>' OnClick="btn_best_Click" />
                                                       <h6>Date: <%# DataBinder.Eval(Container.DataItem, "date")%> &nbsp; &nbsp; &nbsp; Time Posted: <%# DataBinder.Eval(Container.DataItem, "time")%> &nbsp; &nbsp; &nbsp; Type: <%# DataBinder.Eval(Container.DataItem, "type")%></h6>
                                                       <%# DataBinder.Eval(Container.DataItem, "description")%><br />
                                                       <br />
                                                  </div>
                                             </ItemTemplate>
                                        </asp:Repeater>
                                   </ContentTemplate>

                              </asp:UpdatePanel>
                              <!-- Reapeater For Comments Ends  -->
                         </div>
                    </div>
               </div>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
