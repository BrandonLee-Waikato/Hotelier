<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="Hotelier.View.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success">Room Management</h1></div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <!-- 左侧表单 -->
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                        <label for="RNameTb" class="form-label">Room Name</label>
                        <input type="text" class="form-control" id="RNameTb" runat="server" required="required">
                    </div>

                    <div class="mb-3">
                        <label for="CatCb" class="form-label">Room Type</label>
                        <asp:DropDownList ID="CatCb"  class="form-control" runat="server"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="LocationTb" class="form-label">Location</label>
                        <input type="text" class="form-control" id="LocationTb" runat="server" required="required">
                    </div>                    

                    <div class="mb-3">
                        <label for="CostTb" class="form-label">Price</label>
                        <input type="text" class="form-control" id="CostTb"  runat="server" required="required">
                    </div>

                    <div class="mb-3">
                        <label for="LabelTb" class="form-label">Label</label>
                        <input type="text" class="form-control" id="LabelTb" runat="server" required="required">
                    </div>

                    <!-- 新增描述输入框 -->
                    <div class="mb-3">
                        <label for="DescriptionTb" class="form-label">Description</label>
                        <textarea class="form-control" id="DescriptionTb" runat="server" required="required"></textarea>
                    </div>

                    <!-- 新增图片上传控件 -->
                    <div class="mb-3">
                        <label for="ImageUpload" class="form-label">Upload Image</label>
                        <asp:FileUpload ID="ImageUpload" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="StatusCb" class="form-label">Status</label>
                        <asp:DropDownList ID="StatusCb"  class="form-control" runat="server">
                            <asp:ListItem>Available</asp:ListItem>
                            <asp:ListItem>Booked</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class ="row">
                        <div class="col d-grid">
                            <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-warning btn-block" OnClick="EditBtn_Click"/>
                        </div>

                        <div class="col d-grid">
                             <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DeleteBtn_Click"/>
                        </div>
                    </div>

                    <br />

                    <div class="d-grid">
                        <label id="ErrMsg" runat="server" class="text-success"></label>
                        <asp:Button ID="SaveBtn" runat="server" Text="Save" OnClick="SaveBtn_Click" class="btn btn-primary"/>
                    </div>

                    <br />
                </form>
            </div>
            <!-- 右侧房间列表 -->
            <div class="col-md-9">
                 <asp:GridView ID="RoomGrid" runat="server" class="table" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="RoomGrid_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
                     <AlternatingRowStyle BackColor="White" />
                     <EditRowStyle BackColor="#2461BF" />
                     <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                     <RowStyle BackColor="#EFF3FB" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F5F7FB" />
                     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                     <SortedDescendingCellStyle BackColor="#E9EBEF" />
                     <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
