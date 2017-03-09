using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsDel : System.Web.UI.Page
{
    #region declare objects
    private TinTuc objTinTuc = new TinTuc();
    private int itemId = 0;
    //private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        this.Context.Items["strTitle"] = "XÓA BÀI VIẾT";

        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.objTinTuc.delData(this.itemId);

        Response.Redirect("ListNews.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListNews.aspx");
    }
    #endregion
}