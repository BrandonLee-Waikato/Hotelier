<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="Hotelier.View.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <%--<h1 class="text-success">Room Management</h1>--%>
    <div class="container-fluid">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success">Room Management</h1></div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <%--grid 3--%>
            <div class="col-md-3">
                <form>

                    <div class="mb-3">
                        <label for="RNameTb" class="form-label">Room Name</label>
                        <input type="email" class="form-control" id="RNameTb">
                    </div>

                    <div class="mb-3">
                        <label for="CatCb" class="form-label">Room Type</label>
                        <asp:DropDownList ID="CatCb" runat="server" class="form-control"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="LocationTb" class="form-label">Location</label>
                        <input type="email" class="form-control" id="LocationTb">
                    </div>                    
                    
                    <div class="mb-3">
                        <label for="PriceTb" class="form-label">Price</label>
                        <input type="email" class="form-control" id="PriceTb">
                    </div>
                    
                    <div class="mb-3">
                        <label for="LabelTb" class="form-label">Label</label>
                        <input type="email" class="form-control" id="LabelTb">
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
