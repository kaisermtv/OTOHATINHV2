using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Category : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Category objCategory = new Category();
    private int currPage = 0;
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
        Session["TITLE"] = "MENU, DANH MỤC";
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 6, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        try
        {
            this.currPage = int.Parse(Request.QueryString["Page"].ToString());
        }
        catch
        {
            this.currPage = 0;
        }

        if (!Page.IsPostBack)
        {
            this.ddlCategory.DataSource = this.objCategory.getDataParent();
            this.ddlCategory.DataTextField = "Name";
            this.ddlCategory.DataValueField = "Id";
            this.ddlCategory.DataBind();

            this.ddlCategory.SelectedValue = "0";

            this.objTable = this.objCategory.getDataByParentId(int.Parse(this.ddlCategory.SelectedValue.ToString()));
            cpCategory.MaxPages = 1000;
            cpCategory.PageSize = 15;
            cpCategory.DataSource = this.objTable.DefaultView;
            cpCategory.BindToControl = dtlCategory;
            dtlCategory.DataSource = cpCategory.DataSourcePaged;
            dtlCategory.DataBind();
            if (this.objTable.Rows.Count < 15)
            {
                this.tblABC.Visible = false;
            }
            else
            {
                this.tblABC.Visible = true;
            }
        }
    }
    #endregion

    #region method ddlCategory_SelectedIndexChanged
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.objTable = this.objCategory.getDataByParentId(int.Parse(this.ddlCategory.SelectedValue.ToString()));
        cpCategory.MaxPages = 1000;
        cpCategory.PageSize = 15;
        cpCategory.DataSource = this.objTable.DefaultView;
        cpCategory.BindToControl = dtlCategory;
        dtlCategory.DataSource = cpCategory.DataSourcePaged;
        dtlCategory.DataBind();
        if (this.objTable.Rows.Count < 15)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion
}