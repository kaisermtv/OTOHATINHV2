<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DongXeEdit.aspx.cs" Inherits="Directory_DongXeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Hãng xe:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlIDHangXe" AutoPostBack = "true" runat="server" Style="width: 100%; height: 30px; line-height: 30px;" OnSelectedIndexChanged="ddlIDHangXe_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên dòng xe:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNameDongXe" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trạng thái: 
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" Checked = "true" runat="server" Style="font-weight: normal;" />
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
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

