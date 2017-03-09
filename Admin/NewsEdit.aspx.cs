using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsEdit : System.Web.UI.Page
{
    public int id = 0;

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        try
        {
            id = Int32.Parse(Request["id"].ToString());
        }
        catch { }

        this.Context.Items["strTitle"] = "ĐĂNG BÀI";

        if (!Page.IsPostBack)
        {
            Category objCategory = new Category();
            setDroplist(this.ddlCategory, objCategory.getDataIntoCombobox(), "Name", "Id");
            this.ddlCategory.SelectedValue = "0";

            

            if(id != 0)
            {
                TinTuc objTinTuc = new TinTuc();
                DataRow objData = objTinTuc.getDataById(id);
                if(objData != null)
                {
                    txtTitle.Text = objData["Title"].ToString();
                    this.ddlCategory.SelectedValue = objData["CatId"].ToString();
                    txtDescribe.Value = objData["ShortContent"].ToString();
                    txtComment.Text = objData["Content"].ToString();
                    txtAuthor.Text = objData["Author"].ToString();

                    if(objData["ImgUrl"].ToString() != "")
                    {
                        htxtimg1.Value = "/Images/news/" + objData["ImgUrl"].ToString();
                    }
                    
                }
            }


            
        }
        
    }
    #endregion

    #region setDroplist
    private void setDroplist(DropDownList drop, DataTable data, String DataTextField, String DataValueField)
    {
        drop.DataSource = data;
        drop.DataTextField = DataTextField;
        drop.DataValueField = DataValueField;
        drop.DataBind();
    }
    #endregion

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try{
            TinTuc objTinTuc = new TinTuc();
            if (objTinTuc.setData(id, txtTitle.Text, txtAuthor.Text, Int32.Parse(ddlCategory.Text), txtDescribe.Value, txtComment.Text, saveImage(FileUpload1, htxtimg1)) == 1)
            {
                if (id == 0) Response.Redirect("/Admin/ListNews.aspx");

                lblMsg.Text = "Cập nhật thành công";
            }
            else
            {
                lblMsg.Text = objTinTuc.Message;// "Cập nhật thất bại";
            }
        } catch (Exception ex)
        {
            lblMsg.Text = "Cập nhật thất bại";
        }
        
    }
    #endregion

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/ListNews.aspx");
    }
    #endregion


    #region method saveImage
    private String saveImage(FileUpload fileupload, System.Web.UI.HtmlControls.HtmlInputHidden inputc)
    {
        try
        {

            if (fileupload.PostedFile.ContentLength > 5048576 || fileupload.PostedFile.ContentLength == 0)
            {
                if (inputc.Value != "")
                {
                    return inputc.Value.Substring(13);
                }

                return "";
            }
            else
            {
                string strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["NEWSIMAGE"].ToString());

                string sFileName = "0-" + DateTime.Now.ToString("dd-MM-yyy hh-mm-ss-fffffff-");
                string strEx = System.IO.Path.GetFileName(fileupload.PostedFile.FileName);
                //strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                fileupload.PostedFile.SaveAs(strBaseLoactionImg);

                inputc.Value = "/Images/News/" + sFileName + strEx;
                return sFileName + strEx;
            }
        }
        catch //(Exception ex)
        {
            //this.lblMsg.Text = ex.Message; //HttpContext.Current.Response.Write(ex.Message);
            return "";
        }
    }
    #endregion
}