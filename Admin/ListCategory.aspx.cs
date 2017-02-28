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
    public DataRowCollection dtlData;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["TITLE"] = "Hàng hóa";

        dtlData = objOto.getData();
    }
}