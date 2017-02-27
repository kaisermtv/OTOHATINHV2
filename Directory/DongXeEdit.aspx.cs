using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_DongXeEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private HangXe objHangXe = new HangXe();
    private DongXe objDongXe = new DongXe();
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
        Session["TITLE"] = "THÔNG TIN DÒNG XE";
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
        if (!Page.IsPostBack)
        {
            this.ddlIDHangXe.DataSource = this.objHangXe.getDataCategoryToCombobox();
            this.ddlIDHangXe.DataTextField = "NameHangXe";
            this.ddlIDHangXe.DataValueField = "IdHangXe";
            this.ddlIDHangXe.DataBind();

            if (Session["IDHANGXE"] != null)
            {
                this.ddlIDHangXe.SelectedValue = Session["IDHANGXE"].ToString();
            }
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objDongXe.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtNameDongXe.Text = this.objTable.Rows[0]["NameDongXe"].ToString();
                this.ddlIDHangXe.SelectedValue = this.objTable.Rows[0]["IdHangXe"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtNameDongXe.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.ddlIDHangXe.SelectedValue.ToString() == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn hãng xe";
            this.ddlIDHangXe.Focus();
            return;
        }

        if (this.txtNameDongXe.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên dòng xe";
            this.txtNameDongXe.Focus();
            return;
        }

        if (this.objDongXe.setData(this.itemId, this.txtNameDongXe.Text, int.Parse(this.ddlIDHangXe.SelectedValue.ToString()), this.ckbState.Checked) == 1)
        {
            Response.Redirect("DongXe.aspx");
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
        Response.Redirect("DongXe.aspx");
    }
    #endregion

    #region method ddlIDHangXe_SelectedIndexChanged
    protected void ddlIDHangXe_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["IDHANGXE"] = this.ddlIDHangXe.SelectedValue.ToString();
    }
    #endregion
}