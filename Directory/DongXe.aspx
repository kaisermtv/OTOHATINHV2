<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DongXe.aspx.cs" Inherits="Directory_DongXe" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td style ="width:23%;">
                <asp:DropDownList ID="ddlIDHangXe" AutoPostBack = "true" CssClass = "form-control" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlIDHangXe_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên dòng xe để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../Admin/images/Search.png" runat="server" Style="margin-bottom: -12px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top: -20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Tên hãng xe
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 61%;">Tên dòng xe
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlDongXe" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                     <td class="DataListTableTdItemJustify" style="width: 20%;">
                        <%# Eval("NameHangXe") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 61%;">
                        <%# Eval("NameDongXe") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DongXeEdit.aspx?id=<%# Eval("IDDongXe") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DongXeDel.aspx?id=<%# Eval("IDDongXe") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpDongXe" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="DongXeEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
</asp:Content>

