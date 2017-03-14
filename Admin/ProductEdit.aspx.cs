using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductEdit : System.Web.UI.Page
{
    private Oto objOto = new Oto();
    public int itemId = 0;

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        try
        {
            itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("ListProduct.aspx");
        }

        this.Context.Items["strTitle"] = "Sửa thông tin bán xe";

        if (!Page.IsPostBack)
        {
            try
            {
                DataRow objData = objOto.getOtoById(itemId);
                if (objData == null) Response.Redirect("ListProduct.aspx");
                txtIdNameOto.Text = objData["IdNameOto"].ToString();
                txtNoiDung.InnerText = objData["Mota"].ToString();
                txtNamSanXuat.Text = objData["NamSanXuat"].ToString();
                txtGiaBan.Value = objData["GiaBan"].ToString();

                if (objData["IdTrangThai"] == null)
                {
                    ddlTrangThai.SelectedValue = "0";
                }
                else
                {
                    ddlTrangThai.SelectedValue = objData["IdTrangThai"].ToString();
                }

                

                if (objData["NameImage1"] != null && objData["NameImage1"].ToString() != "") htxtimg1.Value = "/Images/post/" + objData["NameImage1"].ToString();
                if (objData["NameImage2"] != null && objData["NameImage2"].ToString() != "") htxtimg2.Value = "/Images/post/" + objData["NameImage2"].ToString();
                if (objData["NameImage3"] != null && objData["NameImage3"].ToString() != "") htxtimg3.Value = "/Images/post/" + objData["NameImage3"].ToString();

                HangXe objHangXe = new HangXe();
                setDroplist(this.ddlIdHangXe, objHangXe.getDataCategoryToCombobox(), "NameHangXe", "IdHangXe");
                ddlIdHangXe.SelectedValue = objData["IdHangXe"].ToString();

                TinhThanh objTinhThanh = new TinhThanh();
                setDroplist(this.ddlIdTinhThanh, objTinhThanh.getDataCategoryToCombobox(), "NameTinhThanh", "IdTinhThanh");
                ddlIdTinhThanh.SelectedValue = objData["IdTinhThanh"].ToString();

                DongXe objDongXe = new DongXe();
                setDroplist(this.ddlIdDongXe, objDongXe.getDataCategoryToCombobox(), "NameDongXe", "IdDongXe");
                ddlIdDongXe.SelectedValue = objData["IdDongXe"].ToString();

                MauSac objMauSac = new MauSac();
                setDroplist(this.ddlIdMauSac, objMauSac.getDataCategoryToCombobox(), "NameMauSac", "IdMauSac");
                ddlIdMauSac.SelectedValue = objData["IdmauSac"].ToString();

                KieuDang objKieuDang = new KieuDang();
                setDroplist(this.ddlIdKieuDang, objKieuDang.getDataCategoryToCombobox(), "NameKieuDang", "IdKieuDang");
                ddlIdKieuDang.SelectedValue = objData["IdKieuDang"].ToString();

                SoCho objSoCho = new SoCho();
                setDroplist(this.ddlIdSoCho, objSoCho.getDataCategoryToCombobox(), "NameSoCho", "IdSoCho");
                ddlIdSoCho.SelectedValue = objData["IdSoCho"].ToString();

                SoCua objSoCua = new SoCua();
                setDroplist(this.ddlIdSoCua, objSoCua.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");
                ddlIdSoCua.SelectedValue = objData["IdSoCua"].ToString();

                //TinhTrang objTinhTrang = new TinhTrang();
                //setDroplist(this.ddlIdTinhTrang, objTinhTrang.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

                NhienLieu objNhienLieu = new NhienLieu();
                setDroplist(this.ddlIdNhienLieu, objNhienLieu.getDataCategoryToCombobox(), "NameNhienLieu", "IdNhienLieu");
                ddlIdNhienLieu.SelectedValue = objData["IdNhienLieu"].ToString();


            }
            catch
            {
                this.lblMsg.Text = "Có lỗi xảy ra! thử reset lại trang.";
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
        if (txtIdNameOto.Text == null || txtIdNameOto.Text == "")
        {
            this.lblMsg.Text = "Bạn cần nhập tiêu đề!";
            return;
        }

        float giaban = 0;
        if (txtGiaBan.Value != null && txtGiaBan.Value != "")
        {
            try
            {
                if (txtGiaBan.Value == null || txtGiaBan.Value == "") giaban = 0;
                giaban = float.Parse(txtGiaBan.Value);
            }
            catch
            {
                this.lblMsg.Text = "Giá bán định dạng sai!";
                return;
            }
        }

        try
        {
            //upImage1.PostedFile.ToString();

            bool ret = objOto.update(itemId, txtIdNameOto.Text, txtNoiDung.Value, giaban, txtNamSanXuat.Text,
                Int32.Parse(ddlIdTinhTrang.Text), Int32.Parse(ddlIdXuatXu.Text), Int32.Parse(ddlHopSo.Text), Int32.Parse(ddlIdKieuDang.Text),
                Int32.Parse(ddlIdNhienLieu.Text), Int32.Parse(ddlIdTinhThanh.Text), Int32.Parse(ddlIdMauSac.Text), Int32.Parse(ddlIdSoCho.Text),
                Int32.Parse(ddlIdSoCua.Text), Int32.Parse(ddlIdHangXe.Text), Int32.Parse(ddlIdDongXe.Text), saveImage(FileUpload1,htxtimg1),
                saveImage(FileUpload2, htxtimg2), saveImage(FileUpload3, htxtimg3), saveImage(FileUpload4, htxtimg4), saveImage(FileUpload5, htxtimg5), Int32.Parse(ddlTrangThai.Text));
            
            if (ret)
            {
                this.lblMsg.Text = "Cập nhật thành công";
            }
            else
            {
                this.lblMsg.Text = objOto.Message;
            }

        }
        catch (Exception ex)
        {
            this.lblMsg.Text = "Có lỗi xảy ra. Xin thử lại!";
            this.lblMsg.Text = ex.Message;
            return;
        }
    }
    #endregion

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListProduct.aspx");
    }
    #endregion

    #region method saveImage
    private String saveImage(FileUpload fileupload, System.Web.UI.HtmlControls.HtmlInputHidden inputc)
    {
        try
        {
            
            if (fileupload.PostedFile.ContentLength > 5048576 || fileupload.PostedFile.ContentLength == 0)
            {
                if(inputc.Value != "")
                {
                    return inputc.Value.Substring(13);
                }
                
                return "";
            }
            else
            {
                string strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["POSTIMAGE"].ToString());

                string sFileName = "0-" + DateTime.Now.ToString("dd-MM-yyy hh-mm-ss-fffffff-");
                string strEx = System.IO.Path.GetFileName(fileupload.PostedFile.FileName);
                //strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                fileupload.PostedFile.SaveAs(strBaseLoactionImg);

                inputc.Value = "/Images/post/" + sFileName + strEx;
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