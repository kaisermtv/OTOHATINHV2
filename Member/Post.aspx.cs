using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Post : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["THANHVIEN"] == null)
        {
            Response.Redirect("/dang-nhap");
        }

        if(!Page.IsPostBack)
        {
            try
            {
                HangXe objHangXe = new HangXe();
                setDroplist(this.ddlIdHangXe, objHangXe.getDataCategoryToCombobox(), "NameHangXe", "IdHangXe");

                TinhThanh objTinhThanh = new TinhThanh();
                setDroplist(this.ddlIdTinhThanh, objTinhThanh.getDataCategoryToCombobox(), "NameTinhThanh", "IdTinhThanh");

                DongXe objDongXe = new DongXe();
                setDroplist(this.ddlIdDongXe, objDongXe.getDataCategoryToCombobox(), "NameDongXe", "IdDongXe");

                MauSac objMauSac = new MauSac();
                setDroplist(this.ddlIdMauSac, objMauSac.getDataCategoryToCombobox(), "NameMauSac", "IdMauSac");

                KieuDang objKieuDang = new KieuDang();
                setDroplist(this.ddlIdKieuDang, objKieuDang.getDataCategoryToCombobox(), "NameKieuDang", "IdKieuDang");

                SoCho objSoCho = new SoCho();
                setDroplist(this.ddlIdSoCho, objSoCho.getDataCategoryToCombobox(), "NameSoCho", "IdSoCho");

                SoCua objSoCua = new SoCua();
                setDroplist(this.ddlIdSoCua, objSoCua.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

                //TinhTrang objTinhTrang = new TinhTrang();
                //setDroplist(this.ddlIdTinhTrang, objTinhTrang.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

                NhienLieu objNhienLieu = new NhienLieu();
                setDroplist(this.ddlIdNhienLieu, objNhienLieu.getDataCategoryToCombobox(), "NameNhienLieu", "IdNhienLieu");

                
            }
            catch
            {
                this.lblMsg.Text = "Có lỗi xảy ra! thử reset lại trang.";
            }
        }

    }

    private void setDroplist(DropDownList drop, DataTable data, String DataTextField, String DataValueField)
    {
        drop.DataSource = data;
        drop.DataTextField = DataTextField;
        drop.DataValueField = DataValueField;
        drop.DataBind();
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        Oto objOto = new Oto();

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

            int ret = objOto.insert(txtIdNameOto.Text, txtNoiDung.Value, giaban, txtNamSanXuat.Text, (int)Session["THANHVIENID"],
                Int32.Parse(ddlIdTinhTrang.Text), Int32.Parse(ddlIdXuatXu.Text), Int32.Parse(ddlHopSo.Text), Int32.Parse(ddlIdKieuDang.Text),
                Int32.Parse(ddlIdNhienLieu.Text), Int32.Parse(ddlIdTinhThanh.Text), Int32.Parse(ddlIdMauSac.Text), Int32.Parse(ddlIdSoCho.Text),
                Int32.Parse(ddlIdSoCua.Text), Int32.Parse(ddlIdHangXe.Text), Int32.Parse(ddlIdDongXe.Text),
                saveImage(upImage1), saveImage(upImage2), saveImage(upImage3), saveImage(upImage4), saveImage(upImage5),txtNgayHienThi.Text,txtHienThiden.Text);

            if(ret != 0)
            {
                this.lblMsg.Text = "Đăng tin thành công";
            }
            else
            {
                this.lblMsg.Text = objOto.Message;
            }

        }
        catch(Exception ex)
        {
            this.lblMsg.Text = "Có lỗi xảy ra. Xin thử lại!";
            this.lblMsg.Text = ex.Message;
            return;
        }
    }

    #region method saveImage
    private String saveImage(FileUpload fileupload)
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["POSTIMAGE"].ToString());
            if (fileupload.PostedFile.ContentLength > 5048576 || fileupload.PostedFile.ContentLength == 0)
            {
                return "";
            }
            else
            {
                string sFileName = Session["THANHVIENID"].ToString() + "-" + DateTime.Now.ToString("dd-MM-yyy hh-mm-ss-fffffff-");
                string strEx = System.IO.Path.GetFileName(fileupload.PostedFile.FileName);
                //strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                fileupload.PostedFile.SaveAs(strBaseLoactionImg);
                return sFileName + strEx;
            }
        }
        catch (Exception ex)
        {
            //this.lblMsg.Text = ex.Message; //HttpContext.Current.Response.Write(ex.Message);
            return "";
        }
    }
    #endregion
}