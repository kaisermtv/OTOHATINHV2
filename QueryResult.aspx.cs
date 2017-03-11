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
                   getResult(querry,"que");
                   return;
               }
               else if (Request.QueryString["hangxe"] != null)
               {
                   querry = Request.QueryString["hangxe"].ToString();
                   getResult(querry,"hangxe");
                   return;
               }
            else if(Request.QueryString["location"] != null)
               {
                   querry = Request.QueryString["location"].ToString();
                   getResult(querry,"location");
                   return;
               }
               else if (Request.QueryString["kieuxe"] != null)
               {
                   querry = Request.QueryString["kieuxe"].ToString();
                   getResult(querry, "kieuxe");
                   return;
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
    public void getResult(string querry , string filter = "")
    {
        switch(filter)
        {
            case "hangxe": { HangXe objHangxe = new HangXe(); objTblCar = objOto.getDataShowHome("", objHangxe.getIdByName(querry), 0,0,2); break; }
            case "location": { TinhThanh objTinhThanh = new TinhThanh(); objTblCar = objOto.getDataShowHome("", 0, 0,objTinhThanh.getIdByName(querry),2); break; }
            case "kieuxe": { KieuDang objKieuDang = new KieuDang(); objTblCar = objOto.getDataShowHome("", 0, 0, 0, 2, objKieuDang.getIdByName(querry)); break; }
            default:        {   objTblCar = objOto.getDataShowHome(querry, 0, 0); break; }
        }

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