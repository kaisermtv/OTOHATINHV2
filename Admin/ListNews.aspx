<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="ListNews.aspx.cs" Inherits="Admin_ListNews" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server">
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
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 76%;">Tiêu đề
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Ngày đăng
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>
 
    <asp:DataList ID="dtlChucVu" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%= this.tt ++ %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 76%;">
                        <%# Eval("Title") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 15%;">
                        <%# Eval("DayPost") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="NewsEdit.aspx?id=<%# Eval("Id") %>">
                            <img src="/Images/Edit.png" alt="">
                        </a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="NewsDel.aspx?id=<%# Eval("Id") %>">
                            <img src="/Images/delete.png" alt="">
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

    <a href="NewsEdit.aspx" class="btn btn-primary" style="width: 90px !important;">Thêm mới</a>
</asp:Content>