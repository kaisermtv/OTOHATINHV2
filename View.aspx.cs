using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View : System.Web.UI.Page
{
    #region declare
    public int ItemId = 0;
    public DataRow objData;
    public String PostTime;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ItemId = Int32.Parse(Request["id"].ToString());
        }
        catch { }

        if (ItemId == 0) Response.Redirect("/News.aspx");

        if (!Page.IsPostBack)
        {
            TinTuc objTinTuc = new TinTuc();
            objData = objTinTuc.getDataById(ItemId);
            if (objData == null) Response.Redirect("/News.aspx");

            try
            {
                PostTime = ((DateTime)objData["DayPost"]).ToString("dd/MM/yyyy");
            }
            catch
            {

            }

            //TinTuc objTinTuc = new TinTuc();
            DataTable objDataTuVan = objTinTuc.getTopShowHome((int)objData["CatId"], 5, "", ItemId); // 32 ID Category Tư vấn xe 
            dtlTuVan.DataSource = objDataTuVan.DefaultView;
            dtlTuVan.DataBind();
        }
    }
    #endregion
}