<%@ Page Title="TRANG CHỦ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="container" style="margin-left:10px; padding-left:0px;">
            <img src="../Images/Ads.png" alt=" " />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="container" style="margin-left: 10px; padding-left: 0px; padding-right: 0px;">
            <div class="col-md-9" style="padding-left: 0px;">
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
                                    <img src="/Images/Car/Car1.png" alt="" />
                                    <div class="CarPrice">
                                        <%# Eval("GiaBan") %> triệu
                                    </div>
                                </div>
                                <div class="DeafaultItemRight">
                                    <div class="DeafaultItemRight1">
                                        <%# Eval("IdNameOto") %>
                                    </div>
                                    <div class="DeafaultItemRight2">
                                        <div class="DeafaultItemRightSub1">
                                            Mới
                                        </div>
                                        <div class="DeafaultItemRightSub2">
                                            Nhập khẩu
                                        </div>
                                        <div class="DeafaultItemRightSub3">
                                            Số tự động
                                        </div>
                                    </div>
                                    <div class="DeafaultItemRight3">
                                        <div class="DeafaultItemRightSub4">
                                            Mới
                                        </div>
                                        <div class="DeafaultItemRightSub5">
                                            Nhập khẩu
                                        </div>
                                        <div class="DeafaultItemRightSub6">
                                            Số tự động
                                        </div>
                                    </div>
                                    <div class="DeafaultItemRight4">
                                        <div class="DeafaultItemRightSub7">
                                            <div class="DeafaultItemRightSub7Content">1-2-3</div>
                                        </div>
                                        <div class="DeafaultItemRightSub8">
                                            <div class="DeafaultItemRightSub8Content">1-2-3</div>
                                        </div>
                                        <div class="DeafaultItemRightSub9">
                                            <div class="DeafaultItemRightSub9Content">1-2-3</div>
                                        </div>
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
                        <img src="../Images/News/NewsHot.jpg" alt="" />
                    </div>
                    <div class="NewsHotTitle">
                        Tìm hiểu về những mức thử nghiệm khí thải mới <span class="TimePost">(30/12/2016)</span>
                    </div>
                    <div class="NewsShortContent">
                        Nhà nước ta quy định có khoảng 11 loại hình thử nghiệm khí thải, tuy nhiên không phải ai cũng hiểu rõ về những mức thử nghiệm này.
                    </div>
                </div>
                <div class="col-md-7" style="padding-right: 0px !important; padding-left: 15px; margin-right: 0px;">
                    <div class="NewsHomeItem">
                        <div class="NewsHomeItemLeft">
                            <img src="../Images/News/NewsHomeSmall.png" alt="" />
                        </div>
                        <div class="NewsHomeItemRight">
                            <div class="NewsHomeItemRightTitle">
                                Tương lai của ngành công nghiệp ô tô sẽ là trí tuệ nhân tạo
                            </div>
                            <div class="NewsHomeItemRightShortContent">
                                Những chiếc ô tô ngày nay đang chuyển mình theo hướng không đơn giản chỉ...
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="NewsHomeItem">
                        <div class="NewsHomeItemLeft">
                            <img src="../Images/News/NewsHomeSmall.png" alt="" />
                        </div>
                        <div class="NewsHomeItemRight">
                            <div class="NewsHomeItemRightTitle">
                                Nguyên tắc sống còn khi dừng đỗ xe trên cao tốc
                            </div>
                            <div class="NewsHomeItemRightShortContent">
                                Cao tốc thường là khu vực thiếu sáng với nhiều phương tiện di chuyển tốc...
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="NewsHomeItem">
                        <div class="NewsHomeItemLeft">
                            <img src="../Images/News/NewsHomeSmall.png" alt="" />
                        </div>
                        <div class="NewsHomeItemRight">
                            <div class="NewsHomeItemRightTitle">
                                Nguyên tắc sống còn khi dừng đỗ xe trên cao tốc
                            </div>
                            <div class="NewsHomeItemRightShortContent">
                                Cao tốc thường là khu vực thiếu sáng với nhiều phương tiện di chuyển tốc...
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="NewsHomeItem">
                        <div class="NewsHomeItemLeft">
                            <img src="../Images/News/NewsHomeSmall.png" alt="" />
                        </div>
                        <div class="NewsHomeItemRight">
                            <div class="NewsHomeItemRightTitle">
                                Nguyên tắc sống còn khi dừng đỗ xe trên cao tốc
                            </div>
                            <div class="NewsHomeItemRightShortContent">
                                Cao tốc thường là khu vực thiếu sáng với nhiều phương tiện di chuyển tốc...
                            </div>
                        </div>
                    </div>
                </div>
                <!-- KET THUC TU VAN XE -->
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div class="col-md-3" style="padding-right: 0px; margin-right: 0px;">

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
                        <asp:ImageButton ID="imgSearch" ImageUrl="../Images/btnSearch.png" Width="28px" CssClass="btnImgSearch" runat="server" />
                    </div>
                </div>

                <div class="DeafaultHeaderRightItem">
                    <div class="DeafaultHeaderRightLeft">
                        <asp:DropDownList ID="ddlHangXe" CssClass="DeafaultHeaderRightCombobox" runat="server">
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
                            <asp:ListItem>Tình trạng</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- KET THUC TIM KIEM XE O TO-->

                <!-- BAT DAU TIM KIEM O TO THEO HANG -->
                <br />
                <div class="DeafaultHeaderRight" style="margin-top: -3px;">
                    <div class="DeafaultHeaderRightName">
                        BÁN Ô TÔ THEO HÃNG
                    </div>
                </div>
                <br />
                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Acura</b> (219)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>Asia</b> (65)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Audi</b> (150)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>BMW</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Chovrolet</b> (120)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>KIA</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Acura</b> (219)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>Asia</b> (65)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Audi</b> (150)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>BMW</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Chovrolet</b> (120)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>KIA</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Acura</b> (219)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>Asia</b> (65)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Audi</b> (150)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>BMW</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Chovrolet</b> (120)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>KIA</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Acura</b> (219)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>Asia</b> (65)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Audi</b> (150)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>BMW</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Chovrolet</b> (120)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>KIA</b> (50)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Acura</b> (219)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>Asia</b> (65)
                    </div>
                </div>

                <div class="DeafaultHeaderRightAsBrand">
                    <div class="DeafaultHeaderRightAsBrand1">
                        <b>Audi</b> (150)
                    </div>
                    <div class="DeafaultHeaderRightAsBrand2">
                        <b>BMW</b> (50)
                    </div>
                </div>

                <!-- KET THUC TIM KIEM O TO THEO HANG -->

                <!-- BAT DAU PHAN SALON O TO TIEU BIEU -->
                <br />
                <div class="DeafaultHeaderRight" style="margin-top: -13px;">
                    <div class="DeafaultHeaderRightName">
                        SALON Ô TÔ TIÊU BIỂU
                    </div>
                </div>
                <br />
                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                            Kia Gò Vấp
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            189 Nguyễn Oanh, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                            Mazda Vinh
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            Đường 46, Xóm 3 , xã Nghi Phú, TP Vinh, Nghệ An, 0911166968 
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                           Chevrolet Giải Phóng
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            Km8 Giải Phóng - Pháp Vân - Hà Nội, 0982461484 
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                           Chevrolet Phú Mỹ Hưng
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            1489 Nguyễn Văn Linh, P Tân Phong, Quận 7, Tp HCM
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                           Nissan Sài Gòn
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            175B Cao Thắng (nối dài), Phường 12, Quận 10, TP.HCM
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle">
                           Long Biên Ford
                        </div>
                        <div class="NewsHomeItemRightBlockShortContent">
                            Số 3 Nguyễn Văn Linh - Long Biên - Hà Nội
                        </div>
                    </div>
                </div>
                <!-- KET THUC PHAN SALON O TO TIEU BIEU -->

                <!-- BAT DAU PHAN DANH GIA XE -->
                 <br /><br /><br />
                <div class="DeafaultHeaderRight" style="margin-top: -3px;">
                    <div class="DeafaultHeaderRightName">
                       ĐÁNH GIÁ XE
                    </div>
                </div>
                <br />
                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle1">
                           Đánh giá xe Hyundai i20 Active 2017: Ngoại hình khỏe khoắn, động cơ tiết kiệm, giá phải chăng 
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle1">
                            Đánh giá xe Nissan X-Trail 2016: Chiếc CUV đô thị bền bỉ và mạnh mẽ
                        </div>
                    </div>
                </div>

                <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle1">
                            Đánh giá xe Bentley Mulsanne 2017: Đẳng cấp xe sang quý tộc Anh 
                        </div>
                    </div>
                </div>

                 <div class="NewsHomeItemBlock">
                    <div class="NewsHomeItemLeftBlock">
                        <img src="../Images/News/NewsHomeSmall.png" alt="" />
                    </div>
                    <div class="NewsHomeItemRightBlock">
                        <div class="NewsHomeItemRightBlockTitle1">
                            Đánh giá xe Kia Optima 2017: Phong cách châu Âu, hiện đại và cá tính 
                        </div>
                    </div>
                </div>
                <!-- KET THUC PHAN DANH GIA XE -->
            </div>
        </div>
    </div>
    <br /><br />
    <div class="row">
        <div class="container" style="margin-left: 10px; padding-left: 20px; padding-right: 0px; background-color:#f2f2f2;">
            <div class ="DivP20L">
                <p style ="margin-top:20px; font-weight:bold;">Bán xe Toyota</p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Camry
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Vios
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Altis
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Fortune
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Yaris
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Venza
                </p>
                <br />
            </div>
            <div class ="DivP20L">
                <p style ="margin-top:20px; font-weight:bold;">Bán xe Toyota</p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Camry
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Vios
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Altis
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Fortune
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Yaris
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Venza
                </p>
                <br />
            </div>
            <div class ="DivP20L">
                <p style ="margin-top:20px; font-weight:bold;">Bán xe Toyota</p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Camry
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Vios
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Altis
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Fortune
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Yaris
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Venza
                </p>
                <br />
            </div>
            <div class ="DivP20L">
                <p style ="margin-top:20px; font-weight:bold;">Bán xe Toyota</p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Camry
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Vios
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Altis
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Fortune
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Yaris
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Venza
                </p>
                <br />
            </div>
            <div class ="DivP20R">
                <p style ="margin-top:20px; font-weight:bold;">Bán xe Toyota</p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Camry
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Vios
                </p>
               <p style ="margin-bottom:5px;">
                    Xe Toyota Altis
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Fortune
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Yaris
                </p>
                <p style ="margin-bottom:5px;">
                    Xe Toyota Venza
                </p>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
