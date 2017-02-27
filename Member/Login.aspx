<%@ Page Title="ĐĂNG NHẬP HỆ THỐNG" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Member_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <b>ĐĂNG NHẬP HỆ THỐNG</b>
                <hr />
                <div class="col-md-8">
                    <div class = "LoginBanner">
                        <img src="../images/Banner.jpg" alt="banner">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading"><b>Thông tin tài khoản</b></div>
                        <div class="panel-body">
                            <div class="RowRegister">
                                <div class="LeftRegister1">Tài khoản: </div>
                                <div class="RightRegister1">
                                    <asp:TextBox ID="txtAccount" CssClass="form-control" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister1">Mật khẩu: </div>
                                <div class="RightRegister1">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Text="&nbsp;" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Đăng nhập" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;<a href = "/Member/Register.aspx">Đăng ký</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

