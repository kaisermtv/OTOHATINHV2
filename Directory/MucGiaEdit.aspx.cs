using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_MucGiaEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private MucGia objMucGia = new MucGia();
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
        Session["TITLE"] = "THÔNG TIN MỨC GIÁ";
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
            this.objTable = this.objMucGia.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtNameMucGia.Text = this.objTable.Rows[0]["NameMucGia"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());

                this.txtTuGia.Text = this.objTable.Rows[0]["TuGia"].ToString();
                this.TxtDenGia.Text = this.objTable.Rows[0]["DenGia"].ToString();

                if (this.txtTuGia.Text == "0") this.txtTuGia.Text = "";
                if (this.TxtDenGia.Text == "0") this.TxtDenGia.Text = "";
            }
        }
        this.txtNameMucGia.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtNameMucGia.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên mức giá";
            this.txtNameMucGia.Focus();
            return;
        }

        float tugia = 0;
        if (txtTuGia.Text.Trim() != "")
        {
            try
            {
                tugia = float.Parse(txtTuGia.Text);
            }
            catch
            {
                this.lblMsg.Text = "Định dạng sai!";
                txtTuGia.Focus();
                return;
            }
        }

        float dengia = 0;
        if (TxtDenGia.Text.Trim() != "")
        {
            try
            {
                dengia = float.Parse(TxtDenGia.Text);
            }
            catch
            {
                this.lblMsg.Text = "Định dạng sai!";
                TxtDenGia.Focus();
                return;
            }
        }

        if (this.objMucGia.setData(this.itemId, this.txtNameMucGia.Text, this.ckbState.Checked,tugia,dengia) == 1)
        {
            Response.Redirect("MucGia.aspx");
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
        Response.Redirect("MucGia.aspx");
    }
    #endregion
}