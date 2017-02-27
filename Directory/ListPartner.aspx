<%@ Page Title="KHÁCH HÀNG, ĐỐI TÁC" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ListPartner.aspx.cs" Inherits="Admin_ListPartner" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        KHÁCH HÀNG, ĐỐI TÁC
    </div>
    <div style="width: 100%;">
        <table class="DataListTableHeader">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 50%;">Khách hàng
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tài khoản
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tài khoản FB
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 8%;">Nhóm hàng
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 12%;">Truy cập cuối
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa
                </td>
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable">
                <tr style ="height:40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 50%;">
                        <%# Eval("Name") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("Account") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <img src ="../images/<%# Eval("SocialNetworkType") %>.png">&nbsp;<%# Eval("SocialNetwork") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 8%;">
                        <a href="CategoryPartner.aspx?id=<%# Eval("Id") %>"><%# Eval("CountCategory") %></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 12%; font-size:12px;">
                        <%# Eval("LastAccess") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="AddPartner.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DelPartner.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #daf2a5; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td>
                <cc1:CollectionPager ID="cpCategory" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="AddPartner.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
</asp:Content>

