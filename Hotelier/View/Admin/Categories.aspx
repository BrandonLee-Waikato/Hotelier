﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Hotelier.View.Admin.Categories" EnableEventValidation="false"%>
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
            <asp:GridView ID="CategoriesGV" runat="server" class="table" CellPadding="3" OnSelectedIndexChanged="CategoriesGV_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField ShowHeader ="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select" Text=""></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select"/>
                </Columns>
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
