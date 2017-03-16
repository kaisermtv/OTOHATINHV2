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

        } else
        {
            
        }

    }


    protected void btnSend_Click(object sender, EventArgs e)
    {
 
        Contracts objContract = new Contracts();
        if (objContract.addData(0, this.txtFullName.Value.ToString(), this.txtEmail.Value.ToString(), this.txtTitle.Value.ToString(), this.txtQuestion.InnerText.ToString()) == 1)
        {
            this.txtFullName.Value = "";
            this.txtEmail.Value = "";
            this.txtQuestion.Value = "";
            this.txtTitle.Value = "";
            this.lblMsg.Text = "<span style = \"color:blue;\">Thông tin đã được gửi đi thành công, Chúng tôi sẽ phản hồi quý vị trong theo quy định!</span>";
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi gửi thông tin tới hệ thống";
        }
    }
}