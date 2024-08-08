<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Hotelier.View.Admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4"><h1 class="text-success">User Management</h1></div>
        <div class="col-4"></div>
    </div>
    <div class="row">
        <%--grid 3--%>
        <div class="col-md-3">
            <form>

                <div class="mb-3">
                    <label for="UNameTb" class="form-label">User Name</label>
                    <input type="email" class="form-control" id="UNameTb">
                </div>

                <div class="mb-3">
                    <label for="PhoneTb" class="form-label">Phone Number</label>
                    <input type="email" class="form-control" id="PhoneTb">
                </div>                    
                
                <div class="mb-3">
                     <label for="GenCb" class="form-label">Gender</label>
                     <asp:DropDownList ID="GenCb" runat="server" class="form-control"></asp:DropDownList>
                </div>
                
                <div class="mb-3">
                    <label for="AddressTb" class="form-label">Address</label>
                    <input type="email" class="form-control" id="AddressTb">
                </div>                
                
                <div class="mb-3">
                    <label for="PasswordTb" class="form-label">Password</label>
                    <input type="email" class="form-control" id="PasswordTb">
                </div>

                <div class="d-grid">
                    <button type="submit" class="btn btn-primary">Save</button>
                </div>

                <br />

            </form>
        </div>
        <%--grid 9 showcase room type, prices... --%>
        <div class="col-md-9">
            <asp:GridView ID="RoomGrid" runat="server" class="table" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
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
    </div>
</div>
</asp:Content>
