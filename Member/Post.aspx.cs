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
        if(!Page.IsPostBack)
        {
            try
            {
                HangXe objHangXe = new HangXe();
                setDroplist(this.ddlIdHangXe, objHangXe.getDataCategoryToCombobox(), "NameHangXe", "IdHangXe");

                //XuatSu objXuatSu = new DongXe();
                //setDroplist(this.ddlIdXuatSu, objXuatSu.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

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
        this.lblMsg.Text = txtIdNameOto.Text;
    }
}