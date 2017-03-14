using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Directory_NamSanXuatEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private NamSanXuat objNamSanXuat = new NamSanXuat();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        Session["TITLE"] = "THÔNG TIN NĂM SẢN XUẤT";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objNamSanXuat.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtNameNamSanXuat.Text = this.objTable.Rows[0]["NameNamSanXuat"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
                this.txtTuNam.Text = this.objTable.Rows[0]["TuNam"].ToString();
                this.TxtDenNam.Text = this.objTable.Rows[0]["DenNam"].ToString();

                if (this.txtTuNam.Text == "0") this.txtTuNam.Text = "";
                if (this.TxtDenNam.Text == "0") this.TxtDenNam.Text = "";
            }
        }
        this.txtNameNamSanXuat.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtNameNamSanXuat.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên năm sản xuất";
            this.txtNameNamSanXuat.Focus();
            return;
        }

        int tunam = 0;
        if(txtTuNam.Text.Trim() != "" )
        {
            try
            {
                tunam = Int32.Parse(txtTuNam.Text);
            }
            catch
            {
                this.lblMsg.Text = "Định dạng sai!";
                txtTuNam.Focus();
                return;
            }
        }

        int dennam = 0;
            if(TxtDenNam.Text.Trim() != "" )
        {
            try
            {
                dennam = Int32.Parse(TxtDenNam.Text);
            }
            catch
            {
                this.lblMsg.Text = "Định dạng sai!";
                TxtDenNam.Focus();
                return;
            }
        }

        if (this.objNamSanXuat.setData(this.itemId, this.txtNameNamSanXuat.Text, this.ckbState.Checked,tunam,dennam) == 1)
        {
            Response.Redirect("NamSanXuat.aspx");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NamSanXuat.aspx");
    }
    #endregion
}