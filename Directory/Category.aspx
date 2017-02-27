<%@ Page Title="QUẢN LÝ CHUYÊN MỤC" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="System_Category" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; height: 45px; line-height: 45px; background-color: #dde8ec; font-family: Arial; font-size: 13px; font-weight: bold; text-transform: uppercase;">
        <div style="width: 100%; padding:4px;">
            <div style="float: left; width: 100%;">
                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" Style="width: 100%; margin-top: 3px;" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    </div>
    <asp:DataList ID="dtlCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
                <tr>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #262626; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                            <%# Eval("TT") %>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #000; background-color: #FFF; width: 68%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                            <%# Eval("Name") %>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #000; background-color: #FFF; width: 10%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                            <%# Eval("MenuNgang") %>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #000; background-color: #FFF; width: 10%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                            <%# Eval("MenuDoc") %>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 3%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; font-weight: bold;">
                            <a href="CategoryEdit.aspx?id=<%# Eval("Id") %>">
                                <img src="../images/edit.png" alt="Sửa"></a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 3%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; border-right: solid 1px #808080; font-weight: bold;">
                            <a href="CategoryDel.aspx?id=<%# Eval("Id") %>">
                                <img src="../images/delete.png" alt="Xóa"></a>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #dde8ec; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 5px;">
                <cc1:CollectionPager ID="cpCategory" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="CategoryEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
</asp:Content>

