<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="NewsEdit.aspx.cs" Inherits="Admin_NewsEdit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="AdminItem">
        <asp:Label ID="lblMsg" runat="server" Text="&nbsp;" ForeColor="Red"></asp:Label>
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tiêu đề:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Nguồn:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtAuthor" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Nhóm tin:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlCategory" CssClass="AdminTextControl" runat="server">
            </asp:DropDownList>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;display:table;">
        <div class="AdminLeftItem">
            Mô tả: 
        </div>
        <div class="AdminRightItem" style="display:table;">
            <textarea ID="txtDescribe" class="AdminTextControl" style="height:100px" runat="server" ></textarea>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;display:table;">
        <div class="AdminLeftItem">
            Nội dung:
            <br />
            <br />
            Ảnh đại diện
            <br />
            <img id="preview" src="<%=htxtimg1.Value %>" style="height: 100px !important; width: 100%" alt="" />
                <label class="file-upload" style="margin-top: 1px;">
                    <input type="hidden" ID="htxtimg1" runat="server" Width="10px"/>
                    <asp:FileUpload ID="FileUpload1" onchange="LoadImgSrc(this,'#preview','htxtimg1');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                </label>
        </div>
        <div class="AdminRightItem" style="display:table;">
            <CKEditor:CKEditorControl ID="txtComment" CssClass="AdminTextControl editor1" runat="server" Height="305" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>
    <script>
        function LoadImgSrc(input, img, imp) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $(img)
                        .attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            } else {
                $(img).attr('src', '');
                document.getElementById('MainContent_' + imp).value = "";
            }
        }
    </script>
     <script>
         var roxyFileman = '/fileman/index.html';

         CKEDITOR.replace('MainContent_txtComment', {
             filebrowserBrowseUrl: roxyFileman,
             filebrowserImageBrowseUrl: roxyFileman + '?type=image',
             removeDialogTabs: 'link:upload;image:upload'
         });
    </script>
</asp:Content>

