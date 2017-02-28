using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ListCategory : System.Web.UI.Page
{
    private Oto objOto = new Oto();
    public DataTable dtlData;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        Session["TITLE"] = "Hàng hóa";

        

        if (!Page.IsPostBack)
        {
            this.dtlData = objOto.getData();

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = 15;
            cpChucVu.DataSource = this.dtlData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();
            if (this.dtlData.Rows.Count < 9)
            {
                this.tblABC.Visible = false;
            }
            else
            {
                this.tblABC.Visible = true;
            }
        }
    }
}