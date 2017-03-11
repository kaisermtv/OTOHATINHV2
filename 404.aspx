<%@ Page Title="404" Language="C#" MasterPageFile="~/SiteHome.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        .error {
  margin: 0 auto;
  text-align: center;
}

.error-code {
  bottom: 60%;
  color: #2d353c;
  font-size: 96px;
  line-height: 100px;
}

.error-desc {
  font-size: 12px;
  color: #647788;
}

.m-b-10 {
  margin-bottom: 10px!important;
}

.m-b-20 {
  margin-bottom: 20px!important;
}

.m-t-20 {
  margin-top: 20px!important;
}

    </style>

    <div class="error">
        <div class="error-code m-b-10 m-t-20">404 <i class="fa fa-warning"></i></div>
        <h3 class="font-bold">Nội dung yêu cầu chưa có sẵn hoặc đang được xây dựng </h3>

        <div class="error-desc">
          Xin lỗi , Nội dung bạn yêu cầu không có sẵn vào lúc này ! <br/>
          Tải lại trang hoặc quay lại trang chủ
            <div>
                <a class=" login-detail-panel-button btn" href="http://www.otohatinh.vn/">
                        <i class="fa fa-arrow-left"></i>
                        Trở lại trang chủ                  
                    </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" Runat="Server">
</asp:Content>

