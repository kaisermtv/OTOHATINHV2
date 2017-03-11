using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    #region declare value
    private int PageSize = 6;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int id = 0;
            try
            {
                id = Int32.Parse(Request["id"].ToString());
            }
            catch { }
            try
            {
                id = Int32.Parse(RouteData.Values["id"].ToString());
            }
            catch { }

            String Search = "";
            try
            {
                Search = Request["Search"].ToString();
            }
            catch { }
            try
            {
                Search = RouteData.Values["Search"].ToString();
            }
            catch { }
            txtSearchBox.Value = Search;

            TinTuc objTinTuc = new TinTuc();

            DataTable objData = objTinTuc.getTopShowHome(id, 0, Search);
            //strHtmlTest = objOto.Message;

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = PageSize;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();

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

    #region imgSearch_Click
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        String rdr = "";
        try
        {
            int cat = Int32.Parse(this.ddlCategory.Text);
            if (cat > 0) rdr += "/cat-" + cat;
        }
        catch { }

        if (this.txtSearchBox.Value != "")
        {
            rdr += "/?Search=" + HttpUtility.UrlEncode(txtSearchBox.Value);
        }
       
        Response.Redirect("/tin-tuc"+rdr);
        
    }
    #endregion
}