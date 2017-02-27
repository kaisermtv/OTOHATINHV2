using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Register : System.Web.UI.Page
{
    #region declare objects
    private TinhThanh objTinhThanh = new TinhThanh();
    private ThanhVien objThanhVien = new ThanhVien();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ddlIDTinhThanh.DataSource = this.objTinhThanh.getDataCategoryToCombobox();
            this.ddlIDTinhThanh.DataTextField = "NameTinhThanh";
            this.ddlIDTinhThanh.DataValueField = "IdTinhThanh";
            this.ddlIDTinhThanh.DataBind();
        }
        this.txtNameThanhVien.Focus();
    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "&nbsp;";
        if (this.txtNameThanhVien.Text == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ và tên !";
            this.txtNameThanhVien.Focus();
            return;
        }
        if (this.txtPhone.Text == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số điện thoại !";
            this.txtPhone.Focus();
            return;
        }
        if (this.txtEmail.Value.ToString() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập địa chỉ email !";
            this.txtEmail.Focus();
            return;
        }
        if (this.txtAccount.Text.ToString() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên tài khoản thành viên !";
            this.txtAccount.Focus();
            return;
        }
        if (this.txtPassword.Text.ToString() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mật khẩu tài khoản thành viên !";
            this.txtPassword.Focus();
            return;
        }

        if (this.objThanhVien.checkAccount(this.txtAccount.Text.Trim()))
        {
            this.lblMsg.Text = "Tài khoản <b> "+this.txtAccount.Text+" </b> đã tồn tại trên hệ thống !";
            this.txtAccount.Focus();
            return;
        }

        if (!this.ckbAgree.Checked)
        {
            this.lblMsg.Text = "Bạn chưa đọc và chấp nhận các chính sách của otohatinh.vn !";
            this.txtAccount.Focus();
            return;
        }

        if (this.objThanhVien.setData(0,this.txtNameThanhVien.Text,this.txtAddress.Text,this.txtPhone.Text,this.txtEmail.Value.ToString(),this.txtAccount.Text,this.txtPassword.Text,this.txtAvartar.Text,true) == 1)
        {
            Response.Redirect("~/");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin";
        }
    } 
    #endregion
}