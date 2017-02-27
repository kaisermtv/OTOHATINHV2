using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_DongXe : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private HangXe objHangXe = new HangXe();
    private DongXe objDongXe = new DongXe();
    private int currPage = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        Session["TITLE"] = "DÒNG XE";
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
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        if (!Page.IsPostBack)
        {
            this.getData();
        }
        this.txtSearch.Focus();
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objDongXe.getData(int.Parse(this.ddlIDHangXe.SelectedValue.ToString()), this.txtSearch.Value);
        cpDongXe.MaxPages = 1000;
        cpDongXe.PageSize = 9;
        cpDongXe.DataSource = this.objTable.DefaultView;
        cpDongXe.BindToControl = dtlDongXe;
        dtlDongXe.DataSource = cpDongXe.DataSourcePaged;
        dtlDongXe.DataBind();
        if (this.objTable.Rows.Count < 9)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();
    }
    #endregion

    #region method ddlIDHangXe_SelectedIndexChanged
    protected void ddlIDHangXe_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["IDHANGXE"] = this.ddlIDHangXe.SelectedValue.ToString();
        this.getData();
    }
    #endregion
}