using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : Page
{
    
   public DataTable objTableAbout = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if(!IsPostBack)
        {
            AboutUs objAboutUs = new AboutUs();
            objTableAbout = objAboutUs.getData();

        }

    }


}