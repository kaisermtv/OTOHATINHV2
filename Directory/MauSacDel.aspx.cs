﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_MauSacDel : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    private MauSac objMauSac = new MauSac();
    private int itemId = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        Session["TITLE"] = "XÓA MÀU SẮC";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
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
        this.objMauSac.delData(this.itemId);
        Response.Redirect("MauSac.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MauSac.aspx");
    }
    #endregion
}