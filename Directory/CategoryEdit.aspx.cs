using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_CategoryEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Category objCategory = new Category();
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        Session["TITLE"] = "THÔNG TIN MENU, CHUYÊN MỤC";
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 6, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
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
            this.ddlCategory.DataSource = this.objCategory.getDataParent();
            this.ddlCategory.DataTextField = "Name";
            this.ddlCategory.DataValueField = "Id";
            this.ddlCategory.DataBind();
            this.ddlCategory.SelectedValue = "0";
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objCategory.getData(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.ddlCategory.SelectedValue = this.objTable.Rows[0]["ParentId"].ToString();
               
                this.ckbShowTaskBarMobile.Checked = bool.Parse(this.objTable.Rows[0]["ShowTaskBarMobile"].ToString());
                this.txtShowTaskBarMobileIndex.Text = this.objTable.Rows[0]["ShowTaskBarMobileIndex"].ToString();
                this.ckbShowHomeMobile.Checked = bool.Parse(this.objTable.Rows[0]["ShowHomeMobile"].ToString());
                this.txtShowHomeMobileIndex.Text = this.objTable.Rows[0]["ShowHomeMobileIndex"].ToString();

                this.cbbMenuHorizontal.Checked = bool.Parse(this.objTable.Rows[0]["MenuHorizontal"].ToString());
                this.txtMenuHorizontalIndex.Text = this.objTable.Rows[0]["MenuHorizontalIndex"].ToString();
               
                this.ckbMenuVertical.Checked = bool.Parse(this.objTable.Rows[0]["MenuVertical"].ToString());
                this.txtMenuVerticalIndex.Text = this.objTable.Rows[0]["MenuVerticalIndex"].ToString();

                //this.ckbShowHomePC.Checked = bool.Parse(this.objTable.Rows[0]["ShowHomePC"].ToString());
                //this.txtShowHomePCIndex.Text = this.objTable.Rows[0]["ShowHomePCIndex"].ToString();

                //this.ckbMenuOther.Checked = bool.Parse(this.objTable.Rows[0]["MenuOther"].ToString());
            }
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên chuyên mục.";
            this.txtName.Focus();
            return;
        }

        if (this.txtShowTaskBarMobileIndex.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập thứ tự hiển thị chuyên mục trên menu di động";
            this.txtShowTaskBarMobileIndex.Focus();
            return;
        }

        int tmpShowTaskBarMobileIndex = 0;
        try
        {
            tmpShowTaskBarMobileIndex = int.Parse(this.txtShowTaskBarMobileIndex.Text.Trim());
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập thứ tự hiển thị chuyên mục trên menu di động";
            this.txtShowTaskBarMobileIndex.Focus();
            return;
        }

        if (this.txtShowHomeMobileIndex.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập thứ tự hiển thị chuyên mục trên trang chủ di động";
            this.txtShowHomeMobileIndex.Focus();
            return;
        }

        int tmpShowHomeMobileIndex = 0;
        try
        {
            tmpShowHomeMobileIndex = int.Parse(this.txtShowHomeMobileIndex.Text.Trim());
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập thứ tự hiển thị chuyên mục trên trang chủ di động";
            this.txtShowHomeMobileIndex.Focus();
            return;
        }

        if (this.objCategory.addData(this.itemId, int.Parse(this.ddlCategory.SelectedValue.ToString()), this.txtName.Text, this.ckbShowTaskBarMobile.Checked, int.Parse(this.txtShowTaskBarMobileIndex.Text), this.ckbShowHomeMobile.Checked, int.Parse(this.txtShowHomeMobileIndex.Text), this.cbbMenuHorizontal.Checked, int.Parse(this.txtMenuHorizontalIndex.Text), this.ckbMenuVertical.Checked, int.Parse(this.txtMenuVerticalIndex.Text)) == 1)
        {
            Response.Redirect("Category.aspx");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi lưu thông tin!";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Category.aspx");
    }
    #endregion
}