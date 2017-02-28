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

        Session["TITLE"] = "HÀNG HÓA";



        if (!Page.IsPostBack)
        {
            Oto objOto = new Oto();

            DataTable objData = objOto.getData();

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
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Oto objOto = new Oto();

        DataTable objData = objOto.getData(txtSearch.Value);

        txtSearch.Value = objOto.Message;

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
}