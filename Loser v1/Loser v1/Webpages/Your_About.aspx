<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Profile.Master" AutoEventWireup="true" CodeBehind="Your_About.aspx.cs" Inherits="Loser_v1.Webpages.Your_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="width: 1000px; margin-left: 15px; margin-top: -20px">
          <div class="well">
               <div class="form-horizontal" role="form">
                    <h4>About User</h4>

                    <div class="form-group" style="padding: 14px;">
                         <p>
                              Email Address: <asp:Label ID="lb_email" runat="server" Font-Bold="true"></asp:Label>
                         </p>
                         <p>Rating: </p>
                         <p>
                              Your Top 3 Categories: 
                                        <asp:Label ID="lb_cat1" runat="server" Font-Bold="true"></asp:Label>,
                                        <asp:Label ID="lb_cat2" runat="server" Font-Bold="true"></asp:Label>,
                                        <asp:Label ID="lb_cat3" runat="server" Font-Bold="true"></asp:Label>
                         </p>
                         <p>
                              Satisfaction Status:
                                   <asp:Label ID="lb_satisfaction" runat="server" Font-Bold="true"></asp:Label>
                         </p>
                         <p>
                              Who I Am:
                                   <asp:Label ID="lb_who" runat="server" Font-Bold="true"></asp:Label>
                         </p>
                         <p>
                              Privacy:
                                   <asp:Label ID="lb_privacy" runat="server" Font-Bold="true"></asp:Label>
                         </p>
                    </div>
               </div>
          </div>


          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                    <div class="well panel-heading">
                         <p>Favourite Quotations: </p>

                         <asp:GridView ID="gr_quotation" DataSourceID="ds_quotation" ShowHeader="False" runat="server" GridLines="None" AutoGenerateColumns="False" DataKeyNames="quot_id" EmptyDataText="No Quotation Has Been Added" CellPadding="4" ForeColor="#333333">
                              <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                   <asp:BoundField DataField="description" HeaderText="description" SortExpression="description"></asp:BoundField>
                                   <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true">
                                        <ItemStyle Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" Width="60px" />
                                   </asp:CommandField>
                                   <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true">
                                        <ItemStyle Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" Width="60px" />
                                   </asp:CommandField>
                              </Columns>
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

                         <asp:SqlDataSource ID="ds_quotation" runat="server" ConnectionString="<%$ ConnectionStrings:DAconnectionstring %>"
                              SelectCommand="SELECT * FROM [Quotation] WHERE ([soul_id] = @soul_id) ORDER BY [quot_id] DESC"
                              UpdateCommand="Update [Quotation] Set [description] = @description WHERE ([quot_id] = @quot_id)"
                              DeleteCommand="DELETE FROM [Quotation] WHERE quot_id = @quot_id">

                              <SelectParameters>
                                   <asp:SessionParameter Name="soul_id" SessionField="SoulId" Type="Int32" />
                              </SelectParameters>

                              <UpdateParameters>
                                   <asp:Parameter Name="description" Type="String" />
                                   <asp:Parameter Name="quot_id" Type="Int32" />
                              </UpdateParameters>

                              <DeleteParameters>
                                   <asp:Parameter Name="quot_id" Type="Int32" />
                              </DeleteParameters>
                         </asp:SqlDataSource>
                    </div>
               </ContentTemplate>
          </asp:UpdatePanel>
     </div>

</asp:Content>
