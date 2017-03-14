<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="ListProduct.aspx.cs" Inherits="Admin_ListProduct" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên màu sắc để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td>
                <asp:DropDownList ID="ddlTrangThai" runat="server" CssClass="form-control" Style="width: 100%;">
                    <asp:ListItem Value="4">Tất cả</asp:ListItem>
                    <asp:ListItem Value="0">Chờ duyệt</asp:ListItem>
                    <asp:ListItem Value="1">Chia sẻ</asp:ListItem>
                    <asp:ListItem Value="2">Lưu trữ</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="/Admin/images/Search.png" runat="server" Style="margin-bottom: -12px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top: -20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;"># </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 66%;">Tiêu đề</td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Trạng thái</td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Ngày đăng</td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;</td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlChucVu" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 66%;">
                        <%# Eval("IdNameOto") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# (Eval("IdTrangThai") != null)? Eval("IdTrangThai").ToString().Replace("1","Chia sẻ").Replace("2","Lưu trữ").Replace("0","Chờ duyệt"):"Chờ duyệt" %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 15%;">
                        <%# Eval("NgayDang") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="ProductEdit.aspx?id=<%# Eval("IdOto") %>">
                            <img src="../Images/Edit.png" alt="">
                        </a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="ProductDel.aspx?id=<%# Eval("IdOto") %>">
                            <img src="../Images/delete.png" alt="">
                        </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpChucVu" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
</asp:Content>