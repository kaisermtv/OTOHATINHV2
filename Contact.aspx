<%@ Page Title="Liên Hệ - " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <style>
       @import url("https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css");
   </style>

        <div class="container">
    <div class="jumbotron jumbotron-sm" style="background-color:#0D598C;margin-top:2%;color:white;    color: white;height: 150px;padding-top: 0px !important;">
        <div class="row">
            <div class="col-sm-12 col-lg-12">
                <div class="page-header">
                <h1>Ô TÔ HÀ TĨNH -  <small>    <%=objTableAbout.Rows[0]["Greeting"].ToString() %></small></h1>
            </div>
              
            </div>
        </div>
    </div>
</div>
<div class="container">
    <div class="row">
        <div class="col-sm-6">
            <div class="well">
                <h3 style="line-height:20%;"><i class="fa fa-home fa-1x" style="line-height:6%;color:#0D598C"></i> Địa Chỉ :</h3>               
                <p style="margin-top:6%;line-height:35%">  <%=objTableAbout.Rows[0]["Address"].ToString() %>     </p>
                <br />
                <br />
                <h3 style="line-height:20%;"><i class="fa fa-envelope fa-1x" style="line-height:6%;color:#0D598C"></i> E-Mail :</h3>
                <p style="margin-top:6%;line-height:35%"><%=objTableAbout.Rows[0]["Email"].ToString() %>  </p>
                <br />
                <br />
                <h3 style="line-height:20%;"><i class="fa fa-user fa-1x" style="line-height:6%;color:#0D598C"></i>Điện thoại :</h3>
                <p style="margin-top:6%;line-height:35%"><%=objTableAbout.Rows[0]["Hotline"].ToString() %>  </p>
                <br />
                <br />
                <h3 style="line-height:20%;"><i class="fa fa-yelp fa-1x" style="line-height:6%;color:#0D598C"></i> Website:</h3>
                <p style="margin-top:6%;line-height:35%"><a href="siteadresi.com/destek">http://www.Otohatinh.vn </a></p>
                <br />
                <h3 style="line-height:20%;"><i class="fa fa-yelp fa-1x" style="line-height:6%;color:#0D598C"></i> Slogen</h3>
                <p style="margin-top:6%;line-height:35%"><a href="siteadresi.com/destek"><%=objTableAbout.Rows[0]["Greeting1"].ToString() %>  </a></p>
            </div>
        </div>
        <div class="col-sm-6">
           
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d96690.80542089987!2d29.864461132544537!3d40.77109282810726!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cb4f66644bfb9d%3A0x82690ee7586b7eb9!2zxLB6bWl0LCBLb2NhZWxp!5e0!3m2!1str!2str!4v1480782606579" width="565" height="430" frameborder="0" style="border:0" allowfullscreen></iframe>
        </div>
    </div>
</div>
       


</asp:Content>
