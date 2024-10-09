<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Hotelier.View.Users.Booking" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">


     <!-- 房间卡片展示 -->
    <div class="container">
        <div class="row">
            <asp:Repeater ID="RoomsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <img src='<%# ResolveUrl("~/" + Eval("RImagePath")) %>' class="card-img-top" alt="Room Image" />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("RName") %></h5>
                                <p class="card-text"><%# Eval("RDescription") %></p>
                                <%--<a href='BookingDetails.aspx?RoomId=<%# Eval("RId") %>' class="btn btn-primary">View Details</a>--%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>



    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <div class="mb-3">
                                    <label for="RoomTb" class="form-label">Room Name</label>
                                    <input type="text" class="form-control" id="RoomTb" runat="server">
                                </div>
                                
                                <div class="mb-3">
                                    <label for="AmountTb" class="form-label">Price</label>
                                    <input type="text" class="form-control" id="AmountTb" runat="server">
                                </div>
                               
                            </div>


                            <div class="col">
                                <div class="mb-3">
                                    <label for="DateInTb" class="form-label">Check In Time</label>
                                    <input type="date" class="form-control" id="DateInTb" runat="server">
                                </div>
                                <div class="mb-3">
                                    <label for="DateOutTb" class="form-label">Check Out Time</label>
                                    <input type="date" class="form-control" id="DateOutTb" runat="server">
                                </div>
   
 
                            </div>

                        </div>
                       
                        <div class="row">
                            <div class="col">
                                <%--save room choice--%>
                                <div>
                                    <label id="ErrMsg" runat="server" class="text-success"></label>
                                    <asp:Button ID="BookBtn" runat="server" Text="Book"  class="btn btn-warning" OnClick="BookBtn_Click"/>
                                    <asp:Button ID="ResetBtn" runat="server" Text="Reset"  class="btn btn-danger" OnClick="ResetBtn_Click"/>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <h3 class="text-primary">Room Information</h3>
                 <asp:GridView ID="RoomsGV" runat="server" class="table" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="White" />
                     <FooterStyle BackColor="#CCCC99" />
                     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                     <RowStyle BackColor="#F7F7DE" />
                     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#FBFBF2" />
                     <SortedAscendingHeaderStyle BackColor="#848384" />
                     <SortedDescendingCellStyle BackColor="#EAEAD3" />
                     <SortedDescendingHeaderStyle BackColor="#575357" />
                 </asp:GridView>
            </div>

            <div class="col">
                
                 <div class="row">
                     <div class="col"></div>
                     <div class="col"><h2 class="text=primary">Rooms Booking Check</h2></div>

                 </div>

                 <div class="row">
                     <div class="col">
                        <asp:GridView ID="BookingGV" runat="server" class="table" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateSelectButton="True" ForeColor="Black" GridLines="Vertical" >
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                     </div>
                 </div>

            </div>
        </div>
    </div>

</asp:Content>