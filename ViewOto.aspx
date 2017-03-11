<%@ Page Title="TRANG CHỦ" Language="C#" MasterPageFile="~/SiteHome.Master" AutoEventWireup="true" CodeFile="ViewOto.aspx.cs" Inherits="ViewOto" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        img{
            max-width:100%;
        }

        .OtoBodyDetail11ImgMore img
        {
            width:15%;
        }
    </style>
    <script>
        function changimg(img) {
            $('#img').attr('src','/Images/POST/' + img);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="OtoTitleDetail">
                <%=objData["IdNameOto"] %> ~ <%=objData["GiaBan"] %> triệu
            </div>
            <br />
            <div>
                <span class="OtoImageDetail">Hình ảnh</span>
            </div>
            <div class="OtoBodyDetail1">
                <div class ="OtoBodyDetail11">
                    <div style="overflow:hidden;width:100%;height:300px">
                        <img id="img" src="/Images/POST/<%=objData["img"] %>" style="width:100%" />
                    </div>
                    <br />
                    <div class ="OtoBodyDetail11ImgMore">
                        <% if (objData["NameImage1"].ToString() != ""){ %>
                        <img src ="/Images/POST/<%=objData["NameImage1"] %>" onclick="changimg('<%=objData["NameImage1"] %>')" >
                        <% } %>
                        <% if (objData["NameImage2"].ToString() != ""){ %>
                        <img src ="/Images/POST/<%=objData["NameImage2"] %>" onclick="changimg('<%=objData["NameImage2"] %>')">
                        <% } %>
                        <% if (objData["NameImage3"].ToString() != ""){ %>
                        <img src ="/Images/POST/<%=objData["NameImage3"] %>" onclick="changimg('<%=objData["NameImage3"] %>')">
                        <% } %>
                        <% if (objData["NameImage4"].ToString() != ""){ %>
                        <img src ="/Images/POST/<%=objData["NameImage4"] %>" onclick="changimg('<%=objData["NameImage4"] %>')">
                        <% } %>
                        <% if (objData["NameImage5"].ToString() != ""){ %>
                        <img src ="/Images/POST/<%=objData["NameImage5"] %>" onclick="changimg('<%=objData["NameImage5"] %>')">
                        <% } %>
                    </div>
                    <br />
                </div>
                <div class ="OtoBodyDetail12">
                    <div class ="OtoBodyDetailPrice">
                        <span style ="font-size:18px;">Giá bán: </span><span> <B><%=objData["GiaBan"] %> triệu</B></span>
                    </div>
                    <div class = "OtoTinhTrangTrai">
                        Tình trạng
                    </div>
                    <div class = "OtoTinhTrangPhai">
                        : <%=objData["TinhTrang"] %>
                    </div>

                    <div class = "OtoXuatXuTrai">
                        Xuất xứ
                    </div>
                    <div class = "OtoXuatXuPhai">
                        : <%=objData["XuatXu"] %>
                    </div>

                    <div class = "OtoNamSanXuatTrai">
                        Năm sản xuất
                    </div>
                    <div class = "OtoNamSanXuatPhai">
                        : <%=objData["NamSanXuat"] %>
                    </div>

                    <div class = "OtoKieuDangTrai">
                        Kiểu dáng
                    </div>
                    <div class = "OtoKieuDangPhai">
                        : <%=objData["NameKieuDang"] %>
                    </div>

                    <div class = "OtoHopSoTrai">
                        Hộp số
                    </div>
                    <div class = "OtoHopSoPhai">
                        : Số tự động
                    </div>
                    <br />
                    <br />&nbsp;
                    <div class ="OtoContact">
                        Liên hệ:<%=objData["Phone"] %>
                    </div>
                </div>
            </div>
            <br /><br />
            <div>
                <span class="OtoDetail">THÔNG TIN SẢN PHẨM</span>
            </div>
            <br />
            <div class ="OtoDetailMoTa">
                <%=objData["Mota"] %>
            </div>
        
    <br />
    <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            Các xe khác
        </div>
    </div>
    <br />
    <asp:DataList ID="dtlBanOto" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <div class="DeafaultRow">
                <div class="DeafaultItem">
                    <div class="DeafaultItemLeft">
                        <div style="width: 200px;height:150px;overflow:hidden;">
                            <a href ="/<%# TVSFunction.convertToUnSign2(Eval("IdNameOto").ToString()) + "-post" + Eval("IdOto") %>" >
                                <img src="/Images/post/<%# Eval("img") %>" alt="<%# Eval("IdNameOto") %>" style="width: 200px" />
                            </a>
                        </div>
                        <div class="CarPrice">
                            <%# Eval("GiaBan") %> triệu
                        </div>
                    </div>
                    <div class="DeafaultItemRight">
                        <div class="DeafaultItemRight1">
                            <a href="/<%# TVSFunction.convertToUnSign2(Eval("IdNameOto").ToString()) + "-post" + Eval("IdOto") %>"><%# Eval("IdNameOto") %></a>
                        </div>
                        <div class="DeafaultItemRight2">
                            <div class="DeafaultItemRightSub1">
                                <%# Eval("TinhTrang") %>
                            </div>
                            <div class="DeafaultItemRightSub2">
                                <%# Eval("XuatXu") %>
                            </div>
                            <div class="DeafaultItemRightSub3">
                                <%# Eval("NameSoCho") %>
                            </div>
                        </div>
                        <div class="DeafaultItemRight3">
                            <div class="DeafaultItemRightSub4">
                                <%# Eval("NameSoCua") %>
                            </div>
                            <div class="DeafaultItemRightSub5">
                                <%# Eval("NameMauSac") %>
                            </div>
                            <div class="DeafaultItemRightSub6">
                                <%# Eval("NameNhienLieu") %>
                            </div>
                        </div>
                        <div class="DeafaultItemRight4">
                            <div class="DeafaultItemRightSub7">
                                <div class="DeafaultItemRightSub7Content"><%# Eval("NameTinhThanh") %></div>
                            </div>
                            <div class="DeafaultItemRightSub8">
                                <div class="DeafaultItemRightSub8Content"><%# Eval("Phone") %></div>
                            </div>
                            <div class="DeafaultItemRightSub9">
                                <div class="DeafaultItemRightSub9Content"><%# Eval("NamSanXuat") %></div>
                            </div>
                        </div>
                    </div>

                </div>
                <br />
            </div>
            <br />

        </ItemTemplate>
    </asp:DataList>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
