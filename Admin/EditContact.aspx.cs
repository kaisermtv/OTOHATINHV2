using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_EditContact : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Contracts objContract = new Contracts();
    private int itemId = 0;
    private Account objAccount = new Account();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "NỘI DUNG LIÊN HỆ";
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 12, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        txtContent.config.toolbar = new object[]
        {
            new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript", "NumberedList", "BulletedList", "-", "Outdent", "Indent", "Blockquote", "CreateDiv",
                            "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" , "Link", "Unlink", "Anchor", "Image", "Table", "HorizontalRule", "PageBreak", "Font", "FontSize","TextColor", "BGColor" },
        };
        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.objTable = this.objContract.getData(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtFullName.Text = this.objTable.Rows[0]["FullName"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.txtTitle.Text = this.objTable.Rows[0]["Title"].ToString();
                this.txtQuestion.Text = this.objTable.Rows[0]["Question"].ToString();
                this.txtContent.Text = this.objTable.Rows[0]["Answer"].ToString();
            }
        }
    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtContent.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập nội dung trả lời.";
            this.txtContent.Focus();
            return;
        }

        this.objContract.setData(this.itemId, this.txtContent.Text, this.ckbState.Checked, DateTime.Now,0);

        Response.Redirect("ListContact.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListContact.aspx");
    }
    #endregion
}