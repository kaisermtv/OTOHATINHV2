using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Login : System.Web.UI.Page
{
    #region declare objects
    private TinhThanh objTinhThanh = new TinhThanh();
    private ThanhVien objThanhVien = new ThanhVien();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtAccount.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        if (this.txtAccount.Text.ToString() == "")
        {
            this.lblMsg.Text = "Tên đăng nhập không hợp lệ";
            return;
        }
        if (this.txtPassword.Text.ToString() == "")
        {
            this.lblMsg.Text = "Mật khẩu không hợp lệ";
            return;
        }
        if (this.objThanhVien.checkForLogin(this.txtAccount.Text.ToString().Trim(), this.txtPassword.Text.Trim()))
        {
            Session["ACCOUNT"] = this.txtAccount.Text.ToUpper();
            Response.Redirect("/");
        }
        else
        {
            this.lblMsg.Text = "Thông tin đăng nhập không hợp lệ";
        }

    }
    #endregion
}