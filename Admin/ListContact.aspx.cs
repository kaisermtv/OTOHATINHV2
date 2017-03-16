using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListContact : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Contracts objContract = new Contracts();
    private int currPage = 0;
    private Account objAccount = new Account();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "NỘI DUNG LIÊN HỆ";
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 12, ref View, ref Add, ref Edit, ref Del, ref Orther))
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
            this.objTable = this.objContract.getData();
            cpContract.MaxPages = 1000;
            cpContract.PageSize = 15;
            cpContract.DataSource = this.objTable.DefaultView;
            cpContract.BindToControl = dtlContract;
            dtlContract.DataSource = cpContract.DataSourcePaged;
            dtlContract.DataBind();
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
}