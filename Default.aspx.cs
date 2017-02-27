using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public string strHtmlTest = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strHtmlTest = "<div class=\"DeafaultItemLeft\">";
        strHtmlTest += "<img src=\"../Images/Car/Car1.png\" alt=\"\" />";
        strHtmlTest += "<div class=\"CarPrice\">";
        strHtmlTest += "338 triệu";
        strHtmlTest += "</div>";
        strHtmlTest += "</div>";
                       
    }
}