<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Hotelier.View.Users.Booking" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">

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
                                    <asp:Button ID="BookBtn" runat="server" Text="Book"  class="btn btn-warning"/>
                                    <asp:Button ID="ResetBtn" runat="server" Text="Reset"  class="btn btn-danger"/>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <h3 class="text-primary">Room Information</h3>
                 <asp:GridView ID="RoomsGV" runat="server" class="table" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateSelectButton="True" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
                     <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                     <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                     <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                     <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#FFF1D4" />
                     <SortedAscendingHeaderStyle BackColor="#B95C30" />
                     <SortedDescendingCellStyle BackColor="#F1E5CE" />
                     <SortedDescendingHeaderStyle BackColor="#93451F" />
                 </asp:GridView>
            </div>

            <div class="col">
                <div class="col-md-9">
                 
            </div>
        </div>
    </div>

</asp:Content>
