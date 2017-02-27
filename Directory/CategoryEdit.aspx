<%@ Page Title="MENU - CHUYÊN MỤC" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="System_CategoryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Chuyên mục cha:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlCategory" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;"></asp:DropDownList>
        </div>
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên chuyên mục:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Menu ngang:
        </div>
        <div class="AdminRightItem">
            <div style="width: 100%;">
                <div style="width: 3%; float: left;">
                    <asp:CheckBox ID="cbbMenuHorizontal" runat="server" />
                </div>
                <div style="width: 12%; float: left; font-size: 13.5px; font-family: Arial;">
                    Thứ tự hiển thị:
                </div>
                <div style="width: 85%; float: right;">
                    <asp:TextBox ID="txtMenuHorizontalIndex" runat="server" Text = "0" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Menu dọc:
        </div>
        <div class="AdminRightItem">
            <div style="width: 100%;">
                <div style="width: 3%; float: left;">
                    <asp:CheckBox ID="ckbMenuVertical" runat="server" />
                </div>
                <div style="width: 12%; float: left; font-size: 13.5px; font-family: Arial;">
                    Thứ tự hiển thị:
                </div>
                <div style="width: 85%; float: right;">
                    <asp:TextBox ID="txtMenuVerticalIndex" runat="server" Text = "0" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Hiện Menu Mobile:
        </div>
        <div class="AdminRightItem">
            <div style="width: 100%;">
                <div style="width: 3%; float: left;">
                    <asp:CheckBox ID="ckbShowTaskBarMobile" runat="server" />
                </div>
                <div style="width: 12%; float: left; font-size: 13.5px; font-family: Arial;">
                    Thứ tự hiển thị:
                </div>
                <div style="width: 85%; float: right;">
                    <asp:TextBox ID="txtShowTaskBarMobileIndex" runat="server" Text = "0" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trang chủ Mobile:
        </div>
        <div class="AdminRightItem">
            <div style="width: 100%;">
                <div style="width: 3%; float: left;">
                    <asp:CheckBox ID="ckbShowHomeMobile" runat="server" />
                </div>
                <div style="width: 12%; float: left; font-size: 13.5px; font-family: Arial;">
                    Thứ tự hiển thị:
                </div>
                <div style="width: 85%; float: right;">
                    <asp:TextBox ID="txtShowHomeMobileIndex" runat="server" Text = "0" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor = "Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>

