using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ListProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        this.Context.Items["strTitle"] = "Quản lý bán xe";

        if (!Page.IsPostBack)
        {
            int idtrangthai = 4;
            try
            {
                idtrangthai = Int32.Parse(Request["trangthai"].ToString());
            }
            catch { }
            ddlTrangThai.SelectedValue = idtrangthai.ToString();

            String Search = "";
            try
            {
                Search = Request["Search"].ToString();
            }
            catch { }
            txtSearch.Value = Search;


        
            Oto objOto = new Oto();

            DataTable objData = objOto.getData(Search, idtrangthai);

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
        }
        else
        {
            String rdr = "?";

            try
            {
                int i = Int32.Parse(this.ddlTrangThai.SelectedValue);
                rdr += "trangthai=" + i;
            }
            catch { }

            if (txtSearch.Value != "")
            {
                if (rdr != "?") rdr += "&";
                rdr += "Search=" + HttpUtility.UrlEncode(txtSearch.Value);
            }

            if (rdr == "?") rdr = "";
            Response.Redirect("/Admin/ListProduct.aspx" + rdr);
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}