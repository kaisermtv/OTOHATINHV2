using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryResult : System.Web.UI.Page
{
    string querry = "";

    public DataTable objTblCar = new DataTable();
    public DataTable objTblNews = new DataTable();

    private Oto objOto = new Oto();
    private TinTuc objNews = new TinTuc();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region getQuerrryString
        try
        {
               if(Request.QueryString["que"] != null)
               {
                   querry = Request.QueryString["que"].ToString();
                   getResult(querry);
               }
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Không có thông tin nào cho tìm kiếm của bạn')");
            Response.Redirect("~/");
        }
        #endregion
    }

    #region getResultFromQuerryString
    public void getResult(string querry)
    {

        objTblCar = objOto.getDataShowHome(querry,0,0);
        if (objTblCar.Rows.Count > 0) { 
        cpChucVu.Visible = true;
        cpChucVu.MaxPages = 1000;
        cpChucVu.PageSize = 8;
        cpChucVu.DataSource = objTblCar.DefaultView;
        cpChucVu.BindToControl = dtlChucVu;
        dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
        dtlChucVu.DataBind();
        }
        objTblNews = objNews.getTopShowHome(0, 5, querry, 0);
        if(objTblNews.Rows.Count > 0 )
        {

            cpNews.Visible = true;
            cpNews.MaxPages = 1000;
            cpNews.PageSize = 5;
            cpNews.DataSource = objTblNews.DefaultView;
            cpNews.BindToControl = cpNews;
            dtlNews.DataSource = cpNews.DataSourcePaged;
            dtlNews.DataBind();
        }

    }
    #endregion
}