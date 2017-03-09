using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ListNews : System.Web.UI.Page
{
    #region
    public int tt = 1;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        this.Context.Items["strTitle"] = "TIN TỨC";

        if (!Page.IsPostBack)
        {
            int id = 0;
            try
            {
                id = Int32.Parse(Request["id"].ToString());
            }
            catch { }

            String Search = "";
            try
            {
                Search = Request["Search"].ToString();
            }
            catch { }
            txtSearch.Value = Search;

            TinTuc objTinTuc = new TinTuc();

            DataTable objData = objTinTuc.getTopShowHome(id, 0, this.txtSearch.Value);

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = 15;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();
            if (objData.Rows.Count < 9)
            {
                this.tblABC.Visible = false;
            }
            else
            {
                this.tblABC.Visible = true;
            }

            Category objCategory = new Category();
            setDroplist(this.ddlCategory, objCategory.getDataIntoCombobox(), "Name", "Id");
            this.ddlCategory.SelectedValue = id.ToString();
        }
    }
    #endregion

    #region setDroplist
    private void setDroplist(DropDownList drop, DataTable data, String DataTextField, String DataValueField)
    {
        drop.DataSource = data;
        drop.DataTextField = DataTextField;
        drop.DataValueField = DataValueField;
        drop.DataBind();
    }
    #endregion

    #region btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        String rdr = "?";
        try
        {
            int cat = Int32.Parse(this.ddlCategory.Text);
            if (cat > 0) rdr += "id=" + cat;
        }
        catch { }

        if (this.txtSearch.Value != "")
        {
            if (rdr != "?") rdr += "&";
            rdr += "Search=" + HttpUtility.UrlEncode(txtSearch.Value);
        }

        Response.Redirect("/Admin/ListNews.aspx" + rdr);
    }
    #endregion
}