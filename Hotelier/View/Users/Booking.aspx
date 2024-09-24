<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Hotelier.View.Users.Booking" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- 您可以在这里添加额外的头部内容 -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">

    <div style="display: flex; justify-content: center">
        <div class="card shadow mb-4" style="width: 95%">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Room Information</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="RoomsGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" DataKeyNames="roomId" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged" AllowPaging="True" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="roomId" HeaderText="Room Id" DataFormatString="{0:D4}" ReadOnly="True" />
                            <asp:BoundField DataField="roomName" HeaderText="Name" />
                            <asp:BoundField DataField="category" HeaderText="Categories" />
                            <asp:BoundField DataField="cost" HeaderText="Cost" DataFormatString="{0:C}" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:ButtonField Text="Select" CommandName="Select" ButtonType="Button" />
                        </Columns>
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <!-- 入住和退房时间输入框 -->
    <asp:Panel ID="BookingPanel" runat="server" Visible="false">
        <div class="container-fluid mt-4">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Booking Details</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <!-- 房间信息显示 -->
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="SelectedRoomTb" class="form-label">Selected Room</label>
                                <asp:TextBox ID="SelectedRoomTb" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="AmountTb" class="form-label">Price</label>
                                <asp:TextBox ID="AmountTb" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <!-- 日期输入框 -->
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="DateInTb" class="form-label">Check In Date</label>
                                <asp:TextBox ID="DateInTb" runat="server" CssClass="form-control" Type="date" OnTextChanged="DateInTb_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="DateOutTb" class="form-label">Check Out Date</label>
                                <asp:TextBox ID="DateOutTb" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!-- 预定和重置按钮 -->
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:Label ID="SuccessMsg" runat="server" CssClass="text-success"></asp:Label>
                            <div class="mt-3">
                                <asp:Button ID="BookBtn" runat="server" Text="Book" CssClass="btn btn-warning me-2" OnClick="BookBtn_Click" />
                                <asp:Button ID="ResetBtn" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="ResetBtn_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <!-- Rooms Booking Check -->
    <div style="display: flex; justify-content: center">
        <div class="card shadow mb-4" style="width: 95%">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Rooms Booking Check</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="BookingGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="orderNumber" HeaderText="Order Number" />
                            <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="roomNumber" HeaderText="Room Number" />
                            <asp:BoundField DataField="userId" HeaderText="UserID" />
                            <asp:BoundField DataField="checkInTime" HeaderText="Check In Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="checkOutTime" HeaderText="Check Out Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="totalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
                        </Columns>
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
