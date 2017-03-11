<%@ Page Title="TIN TỨC" Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeFile="News.aspx.cs" Inherits="News" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            BÀI VIẾT MỚI
        </div>
    </div>
    <br />
    <asp:DataList ID="dtlChucVu" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <div class="DeafaultRow">
                <div class="DeafaultItem">
                    <div class="DeafaultItemLeft">
                        <a href="/tin-tuc/<%# TVSFunction.convertToUnSign2(Eval("Title").ToString()) + "-post" + Eval("Id") %>">
                            <img  onerror="imgCatchError(this)" src="/Images/News/<%# Eval("ImgUrl") %>" alt="<%# Eval("Title") %>" style="width: 100%" />
                        </a>
                    </div>
                    <div class="DeafaultItemRight">
                        <div class="DeafaultItemRight1">
                            <a href="/tin-tuc/<%# TVSFunction.convertToUnSign2(Eval("Title").ToString()) + "-post" + Eval("Id") %>"><%# Eval("Title") %></a>
                        </div>
                        <div class="DeafaultItemRight2">
                            <%# Eval("ShortContent") %>
                        </div>
                    </div>

                </div>
            </div>
            <br />

        </ItemTemplate>
    </asp:DataList>
    <cc1:CollectionPager ID="cpChucVu" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
    <!-- TIM KIEM TIN TUC -->

    <div class="DeafaultHeaderRight">
        <div class="DeafaultHeaderRightName">
            TÌM BÀI VIẾT
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
        <asp:DropDownList ID="ddlCategory" CssClass="DeafaultHeaderRightCombobox" Width="100%" runat="server">
        </asp:DropDownList>
    </div>

    <!-- KET THUC TIM KIEM XE O TO-->
    <br />
</asp:Content>
