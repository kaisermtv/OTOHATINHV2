using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_NhienLieuEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private NhienLieu objNhienLieu = new NhienLieu();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        Session["TITLE"] = "THÔNG TIN NHIÊN LIỆU";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objNhienLieu.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtNameNhienLieu.Text = this.objTable.Rows[0]["NameNhienLieu"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtNameNhienLieu.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtNameNhienLieu.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên hãng xe";
            this.txtNameNhienLieu.Focus();
            return;
        }

        if (this.objNhienLieu.setData(this.itemId, this.txtNameNhienLieu.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("NhienLieu.aspx");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NhienLieu.aspx");
    }
    #endregion
}