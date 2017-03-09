<%@ Page Title="ĐĂNG BÀI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Member_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
                        <div style="border: solid 1px red; height: 100px;">
                            <img id="preview" style="height: 100px !important; width: 100%" alt="" />
                            <label class="file-upload" style="margin-top: 1px;">
                                <asp:TextBox ID="txtImage1" runat="server" Width="10px" Visible="false"></asp:TextBox>
                                <asp:FileUpload ID="upImage1" onchange="LoadImgSrc(this,'#preview');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                            </label>
                        </div>
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
                                    <asp:ListItem Value="0">Nhập khẩu</asp:ListItem>
                                    <asp:ListItem Value="1">Trong nước</asp:ListItem>
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
                                    <asp:ListItem Value="0">Mới</asp:ListItem>
                                    <asp:ListItem Value="1">Cũ</asp:ListItem>
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

                        <div class="RowRegister">
                            <div class="LeftPost">Tỉnh thành: </div>
                            <div class="RightPost">
                                <asp:DropDownList ID="ddlIdTinhThanh" runat="server" CssClass="form-control" Style="width: 100%;">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div style="border: solid 1px red; height: 100px;">
                            <img id="preview2" style="height: 100px !important; width: 100%" alt="" />
                            <label class="file-upload" style="margin-top: 1px;">
                                <asp:TextBox ID="txtImage2" runat="server" Width="10px" Visible="false"></asp:TextBox>
                                <asp:FileUpload ID="upImage2" onchange="LoadImgSrc(this,'#preview2');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                            </label>
                        </div>
                        <br />
                        <br />
                        <div style="border: solid 1px red; height: 100px;">
                            <img id="preview3" style="height: 100px !important; width: 100%" alt="" />
                            <label class="file-upload" style="margin-top: 1px;">
                                <asp:TextBox ID="txtImage3" runat="server" Width="10px" Visible="false"></asp:TextBox>
                                <asp:FileUpload ID="upImage3" onchange="LoadImgSrc(this,'#preview3');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                            </label>
                        </div>
                        <br />
                        <br />
                        <div style="border: solid 1px red; height: 100px;">
                            <img id="preview4" style="height: 100px !important; width: 100%" alt="" />
                            <label class="file-upload" style="margin-top: 1px;">
                                <asp:TextBox ID="txtImage4" runat="server" Width="10px" Visible="false"></asp:TextBox>
                                <asp:FileUpload ID="upImage4" onchange="LoadImgSrc(this,'#preview4');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                            </label>
                        </div>
                        <br />
                        <br />
                        <div style="border: solid 1px red; height: 100px;">
                            <img id="preview5" style="height: 100px !important; width: 100%" alt="" />
                            <label class="file-upload" style="margin-top: 1px;">
                                <asp:TextBox ID="txtImage5" runat="server" Width="10px" Visible="false"></asp:TextBox>
                                <asp:FileUpload ID="upImage5" onchange="LoadImgSrc(this,'#preview5');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                            </label>
                        </div>
                    </div>
                   
                </div>

                 <br /><br />
                 <asp:Label ID="lblMsg" runat="server" Text="&nbsp;" ForeColor="Red"></asp:Label>
                  <br />
                <asp:Button ID="btnPost" CssClass ="btn btn-primary" runat="server" Text="Đăng tin" OnClick ="btnPost_Click" />
            </div>
            <script>
                function LoadImgSrc(input, img) {
                    if (input.files && input.files[0]) {
                        var reader = new FileReader();

                        reader.onload = function (e) {
                            $(img)
                                .attr('src', e.target.result);
                        };

                        reader.readAsDataURL(input.files[0]);
                    } else {
                        $(img).attr('src','');
                    }
                }
            </script>
</asp:Content>

