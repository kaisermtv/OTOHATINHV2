<%@ Page Title="ĐĂNG KÝ THÀNH VIÊN" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Member_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <b>ĐĂNG KÝ THÀNH VIÊN</b>
                <hr />
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading"><b>Thông tin thành viên</b></div>
                        <div class="panel-body">
                            <div class="RowRegister">
                                <div class="LeftRegister">Họ và tên (*): </div>
                                <div class="RightRegister">
                                    <asp:TextBox ID="txtNameThanhVien" CssClass="form-control" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister">Địa chỉ: </div>
                                <div class="RightRegister">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister">Điện thoại (*): </div>
                                <div class="RightRegister">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister">Địa chỉ email (*): </div>
                                <div class="RightRegister">
                                    <input type="email" runat="server" id="txtEmail" class="form-control" />
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister">Ảnh đại diện: </div>
                                <div class="RightRegister">
                                    <asp:TextBox ID="txtAvartar" CssClass="form-control" Style="width: 100% !important; max-width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="RowRegister">
                                <div class="LeftRegister">Tỉnh, thành: </div>
                                <div class="RightRegister">
                                    <asp:DropDownList ID="ddlIDTinhThanh" runat="server" CssClass="form-control" Style="width: 100%;">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:CheckBox ID="ckbAgree" runat="server" />
                    &nbsp;Tôi đồng ý với điều khoản và các quy định của otohatinh.vn
           
                    <br /><br />
                    <asp:Label ID="lblMsg" runat="server" Text="&nbsp;" ForeColor = "Red"></asp:Label>

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
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Đăng ký" OnClick = "btnSave_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

