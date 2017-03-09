<%@ Page Title="TIN TỨCs" Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteHome.Master" CodeFile="View.aspx.cs" Inherits="View" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        img{
            max-width:100%;
        }

        .NewsTopTile
        {
                margin-top: -5px;
                width: 100%;
                display: table;
                max-height: 80px;
                font-size: 14px;
                font-family: Arial;
                font-weight: bold;
                color: #0f0f0f;
                text-align: justify;
        }

        .NewsTopShortContent
        {
            width: 100%;
            display: table;
            max-height: 80px;
            font-size: 14px;
            font-family: Arial;
            color: #0f0f0f;
            text-align: justify;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="DeafaultHeader">
                <div class="DeafaultHeaderName" style="width:100%">
                    <%=objData["Title"] %> <small>(<%=PostTime %>)</small>
                </div>
            </div>
            <br />
            <b><%=objData["ShortContent"] %></b>
            <%=objData["Content"] %>
            <br />
            <% if(objData["Author"].ToString() != "" ){ %>
            <small><i><b>Author: </b><%=objData["Author"] %> </i></small>
            <% } %>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
    <div class="DeafaultHeader">
        <div class="DeafaultHeaderName">
            Tin liên quan
        </div>
    </div>
    <br />
    <asp:DataList ID="dtlTuVan" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <ItemTemplate>
            <div class="NewsHomeItem">
                <div class="col-md-4" style="padding-left:0px">
                    <a href="/View.aspx?id=<%# Eval("Id") %>">
                        <img src="/Images/News/<%# Eval("ImgUrl") %>" alt="<%# Eval("Title") %>" style="width: 100%" />
                    </a>
                </div>
                <div class="col-md-8" style="padding-right:0px">
                    <div class="NewsTopTile">
                        <a href="/View.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a>
                    </div>
                    <div class="NewsTopShortContent">
                        <%# Eval("ShortContent").ToString() %>
                    </div>
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="RightContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>