<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Hotelier.View.Admin.Categories" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">

    <div class="container-fluid">
         <%--显示登录用户的用户名--%>
        <div class ="row"><div class="col-md-5"></div><div class="col-md-5"></div><div class="col-md-2"><label id="LogUser" runat="server" class="text-success"></label></div></div>

        <div class="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success text-center">Room Type Management</h1></div>
            <div class="col-4"></div>
        </div>
    <div class="row">
        <%--grid 3--%>
        <div class="col-md-3">
            <form>

                <div class="mb-3">
                    <label for="CatNameTb" class="form-label">Room Type Name</label>
                    <input type="text" class="form-control" id="CatNameTb" runat="server">
                </div>

                <div class="mb-3">
                    <label for="LabelTb" class="form-label">Lable</label>
                    <input type="text" class="form-control" id="LabelTb" runat="server">
                </div>                    
                

                <div class ="row">
                    <%--edit and delete button--%>
                    <div class="col d-grid">
                        <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-warning btn-block" OnClick="EditBtn_Click"/>
                    </div>

                    <div class="col d-grid">
                         <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DeleteBtn_Click"/>
                    </div>
                    
                    
                   
                </div>

                <br />

                <%--save room types--%>
                <div class="d-grid">
                    <label id="ErrMsg" runat="server" class="text-success"></label>
                    <asp:Button ID="SaveBtn" runat="server" Text="Save" OnClick="SaveBtm_Click" class="btn btn-primary"/>
                </div>
                <br />

            </form>
        </div>
        <%--grid 9 showcase room type, prices... --%>
        <div class="col-md-9">
            <%--CategoriesGV_SelectedIndexChanged--%>
            <asp:GridView ID="CategoriesGV" runat="server" class="table" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoriesGV_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
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
