<%@ Page Title="TRANG TÌM KIẾM" Language="C#" MasterPageFile="~/SiteHome.master" AutoEventWireup="true" CodeFile="QueryResult.aspx.cs" Inherits="QueryResult" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

     <style>
        img {
            max-width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdsContent" Runat="Server">
     <div class="row">
        <div class="container" style="margin-left: 15px; padding-left: 0px;padding-right:0px">
            <img src="/Images/Ads.png" alt=" " />
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
      <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
          XE 
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
    <div style="width:100%">
    <cc1:CollectionPager ID="cpChucVu" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None" 
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
   </div>
    <!-- TU VAN XE -->
   <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            BÀI VIẾT 
        </div>
    </div>
    <br />

    <div class="col-md-12" style="padding-right: 0px !important; padding-left: 0px; margin-right: 0px;">
        <asp:DataList ID="dtlNews" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <div class="DeafaultRow">
                <div class="DeafaultItem">
                    <div class="DeafaultItemLeft">
                        <a href="/tin-tuc/<%# TVSFunction.convertToUnSign2(Eval("Title").ToString()) + "-post" + Eval("Id") %>">
                            <img  onerror="imgCatchError(this)"  src="/Images/News/<%# Eval("ImgUrl") %>" alt="<%# Eval("Title") %>" style="width: 100%" />
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
    <cc1:CollectionPager ID="cpNews" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
    </div>
    <!-- KET THUC TU VAN XE -->
    <br />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" Runat="Server">

       
</asp:Content>

