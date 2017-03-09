using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOto : System.Web.UI.Page
{
    #region declare
    public int ItemId = 0;
    public DataRow objData;

    public int hostIdTuVan = 0;
    public String hostImgTuVan = "";
    public String hostTileTuVan = "";
    public String hostShortContentTuVan = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ItemId = Int32.Parse(Request["id"].ToString());
        }
        catch { }

        if (ItemId == 0) Response.Redirect("/");

        if(!Page.IsPostBack)
        {
            Oto objOto = new Oto();
            objData = objOto.getDataShowHomeById(ItemId);
            if (objData == null) Response.Redirect("/");


            DataTable objDataTuVan = objOto.getDataLienQuan(5, ItemId, (int)objData["IdDongXe"]);

            dtlBanOto.DataSource = objDataTuVan.DefaultView;
            dtlBanOto.DataBind();
        }
        
    }
    #endregion
}