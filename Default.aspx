<%@ Page Title="TRANG CHỦ" Language="C#" MasterPageFile="~/SiteHome.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        img {
            max-width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdsContent" runat="server">
    <div class="row">
        <div class="container" style="margin-left: 15px; padding-left: 0px;padding-right:0px">
            <img src="/Images/Ads.png" alt=" " />
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            XE MỚI ĐĂNG
        </div>
    </div>
    <br />
    <asp:DataList ID="dtlChucVu" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <div class="DeafaultRow">
                <div class="DeafaultItem">
                    <div class="DeafaultItemLeft">
                        <div style="width: 200px;height:150px;overflow:hidden;">
                            <a href ="/<%# TVSFunction.convertToUnSign2(Eval("IdNameOto").ToString()) + "-post" + Eval("IdOto") %>" >
                                <img  onerror="imgCatchError(this)"  src="/Images/post/<%# Eval("img") %>" alt="<%# Eval("IdNameOto") %>" style="width: 200px" />
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
    <cc1:CollectionPager ID="cpChucVu" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
    <br />
    <!-- TU VAN XE -->
    <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            TƯ VẤN XE
        </div>
    </div>
    <br />
    <div class="col-md-5" style="padding-left: 0px;">
        <div class="NewsHotImg">
            <% if (hostImgTuVan != "")
               { %><a href="/tin-tuc/<%= TVSFunction.convertToUnSign2(hostTileTuVan) + "-post" + hostIdTuVan %>"><img onerror="imgCatchError(this)" src="/Images/News/<%=hostImgTuVan %>" alt="<%=hostTileTuVan %>" /></a><% } %>
        </div>
        <div class="NewsHotTitle">
            <a href="/tin-tuc/<%= TVSFunction.convertToUnSign2(hostTileTuVan) + "-post" + hostIdTuVan %>"><%=hostTileTuVan %></a> <span class="TimePost"><%=hostTimePostTuVan %></span>
        </div>
        <div class="NewsShortContent">
            <%=hostShortContentTuVan %>
        </div>
    </div>

    <div class="col-md-7" style="padding-right: 0px !important; padding-left: 15px; margin-right: 0px;">
        <asp:DataList ID="dtlTuVan" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
            <ItemTemplate>
                <div class="NewsHomeItem">
                    <div class="NewsHomeItemLeft">
                        <a href="/tin-tuc/<%# TVSFunction.convertToUnSign2(Eval("Title").ToString()) + "-post" + Eval("Id") %>">
                            <img onerror="imgCatchError(this)" src="/Images/News/<%# Eval("ImgUrl") %>" alt="<%# Eval("Title") %>" style="width: 100%" />
                        </a>
                    </div>
                    <div class="NewsHomeItemRight">
                        <div class="NewsHomeItemRightTitle">
                            <a href="/tin-tuc/<%# TVSFunction.convertToUnSign2(Eval("Title").ToString()) + "-post" + Eval("Id") %>"><%# Eval("Title") %></a>
                        </div>
                        <div class="NewsHomeItemRightShortContent">
                            <%# Eval("ShortContent").ToString() %>
                        </div>
                    </div>
                </div>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <!-- KET THUC TU VAN XE -->
    <br />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>

    <!-- TIM KIEM XE O TO -->
    <div class="DeafaultHeaderRight">
        <div class="DeafaultHeaderRightName">
            TÌM XE Ô TÔ
        </div>
    </div>
    <br />
    <div class="DefaultRightSearchBg">
        <div class="txtTextBoxSearchSmall">
            <input id="txtSearchBox" class="txtTextBoxSearchSmall" runat="server" placeholder="Bạn muốn tìm gì? Ví dụ bán xe Camry...">
        </div>
        <div class="DefaultRightSearchButton">
            <asp:ImageButton ID="imgSearch" ImageUrl="/Images/btnSearch.png" Width="28px" CssClass="btnImgSearch" runat="server" OnClick="imgSearch_Click" />
        </div>
    </div>

    <div class="DeafaultHeaderRightItem">
        <div class="DeafaultHeaderRightLeft">
            <asp:DropDownList ID="ddlHangXe" AutoPostBack ="true" CssClass="DeafaultHeaderRightCombobox" runat="server" OnSelectedIndexChanged="ddlHangXe_TextChanged">
                <asp:ListItem>Chọn hàng</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="DeafaultHeaderRightRight">
            <asp:DropDownList ID="ddlDongXe" CssClass="DeafaultHeaderRightCombobox" runat="server">
                <asp:ListItem>Dòng xe</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="DeafaultHeaderRightItem">
        <div class="DeafaultHeaderRightLeft">
            <asp:DropDownList ID="ddlMucGia" CssClass="DeafaultHeaderRightCombobox" runat="server">
                <asp:ListItem>Mức giá</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="DeafaultHeaderRightRight">
            <asp:DropDownList ID="ddlNamSX" CssClass="DeafaultHeaderRightCombobox" runat="server">
                <asp:ListItem>Năm SX</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="DeafaultHeaderRightItem">
        <div class="DeafaultHeaderRightLeft">
            <asp:DropDownList ID="ddlTinhThanh" CssClass="DeafaultHeaderRightCombobox" runat="server">
                <asp:ListItem>Tỉnh thành</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="DeafaultHeaderRightRight">
            <asp:DropDownList ID="ddlTingTrang" CssClass="DeafaultHeaderRightCombobox" runat="server">
                <asp:ListItem Value="2">Tình trạng</asp:ListItem>
                <asp:ListItem Value="0">Mới</asp:ListItem>
                <asp:ListItem Value="1">Cũ</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <!-- KET THUC TIM KIEM XE O TO-->
    <br />
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
