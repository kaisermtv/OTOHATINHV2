<%@ Page Title="LIÊN HỆ " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 20px; padding: 0px;">
        <script>
            function validate() {
                var txtFullName = document.getElementById('MainContent_txtFullName').value;
                var txtEmail = document.getElementById('MainContent_txtEmail').value;
                var txtTitle = document.getElementById('MainContent_txtTitle').value;
                var txtQuestion = document.getElementById('MainContent_txtQuestion').value;
                if (txtFullName != "" && txtEmail != "" && txtTitle != "" && txtQuestion != "") {
                    document.getElementById('MainContent_btnSend').disabled = false;
                }
                else {
                    document.getElementById('MainContent_btnSend').disabled = 'disabled'
                }
            }
        </script>
        <div class="col-md-12" style="padding: 0px; margin-right: -15px;">
            <div class="BodyTitle">
                <h1>LIÊN HỆ</h1>
            </div>
            <br />
            <p>
                Các tổ chức, cá nhân cần liên hệ với <%=objTableAbout.Rows[0]["Name"].ToString() %>, vui lòng liên hệ với chúng tôi theo các thông tin sau:
            </p>
            <br />
            <p style="font-weight: bold; font-size: 15px;"><%=objTableAbout.Rows[0]["Name"].ToString().ToUpper() %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Địa chỉ: <%=objTableAbout.Rows[0]["Address"].ToString() %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Điện thoại: <%=objTableAbout.Rows[0]["Hotline"].ToString() %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Email: <%=objTableAbout.Rows[0]["Email"].ToString() %></p>
            <br />
            <p style="margin-top: -5px;">
                Hoặc gửi thông tin liên hệ trực tiếp về cho chúng tôi theo mẫu sau đây
            </p>
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">THÔNG TIN LIÊN HỆ</h3>
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon1">@</span>
                            <input type="text" style="width: 98%; max-width: 1000px !important;" id="txtFullName" onkeyup="validate()" class="form-control" runat="server" placeholder="Họ và tên" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon2">@</span>
                            <input type="email" style="width: 98%; max-width: 1000px !important;" id="txtEmail" onkeyup="validate()" class="form-control" runat="server" placeholder="Địa chỉ email" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon3">@</span>
                            <input type="text" style="width: 98%; max-width: 1000px !important;" id="txtTitle" onkeyup="validate()" class="form-control" runat="server" placeholder="Tiêu đề" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px; display: table;">
                            <span class="input-group-addon" id="basic-addon4">@</span>
                            <textarea style="width: 98%; max-width: 925px !important;" id="txtQuestion" onkeyup="validate()" class="form-control" runat="server" placeholder="Nội dung liên hệ" rows="6" aria-describedby="basic-addon1"></textarea>
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <asp:Button ID="btnSend" CssClass="btn btn-default" Enabled="false" Style="width: 100px;" runat="server" Text="Gửi câu hỏi" OnClick="btnSend_Click" />
                            <button type="reset" runat="server" class="btn btn-default">Xóa trắng</button>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </div>
        <br />
    </div>
</asp:Content>
