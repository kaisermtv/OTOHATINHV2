﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ListCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        Session["TITLE"] = "NHÓM HÀNG HÓA";

        
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}