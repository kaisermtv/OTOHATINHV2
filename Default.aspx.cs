using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public string strHtmlTest = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Oto objOto = new Oto();

            DataTable objData = objOto.getData();

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = 10;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();
        }
                       
    }
}