<%@ Page Title="ĐĂNG BÀI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Member_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <b>ĐĂNG TIN BÁN XE</b>
                <hr />
                <div class="row">
                    <div class="col-md-8" style="padding-left: 0px;">
                        <div class="RowRegister">
                            <div class="LeftPost1">Tiêu đề: </div>
                            <div class="RightPost1">
                                <asp:TextBox ID="txtIdNameOto" Style="width: 100% !important; max-width: 100%;" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost1">Nội dung: </div>
                            <div class="RightPost1">
                                <textarea id="txtNoiDung" rows="4" style="width: 100% !important; max-width: 100%;" class="form-control" runat="server"></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        HÌNH ẢNH XE
                        <br />
                        <br />
                        <div style="border: solid 1px red; height: 100px; margin-top: 5px;"></div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="RowRegister">
                            <div class="LeftPost">Hãng xe: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdHangXe" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Xuất xứ: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdXuatXu" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Màu xe: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdMauSac" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Dáng xe: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdKieuDang" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Số chỗ: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdSoCho" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Số cửa: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdSoCua" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="RowRegister">
                            <div class="LeftPost">Dòng xe: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdDongXe" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Tình trạng: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdTinhTrang" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Nhiên liệu: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdNhienLieu" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Năm sản xuất: </div>
                            <div class="RightPost">
                                <asp:TextBox ID="txtNamSanXuat" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="RowRegister">
                            <div class="LeftPost">Giá bán: </div>
                            <div class="RightPost">
                                <input type="text" placeholder="Giá bán (Triệu đồng)" id="txtGiaBan" class="form-control" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4">
                        <div style="border: solid 1px red; height: 100px;"></div>
                        <br />
                        <div style="border: solid 1px red; height: 100px;"></div>
                    </div>
                   
                </div>

                 <br /><br />
                 <asp:Label ID="lblMsg" runat="server" Text="&nbsp;" ForeColor="Red"></asp:Label>
                  <br />
                <asp:Button ID="btnPost" CssClass ="btn btn-primary" runat="server" Text="Đăng tin" OnClick ="btnPost_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

