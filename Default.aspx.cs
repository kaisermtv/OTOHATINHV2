using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public string strHtmlTest = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!Page.IsPostBack)
        {
            Oto objOto = new Oto();

            DataTable objData = objOto.getDataShowHome();
            strHtmlTest = objOto.Message;

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = 10;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();

            try
            {
                HangXe objHangXe = new HangXe();
                setDroplist(this.ddlHangXe, objHangXe.getDataCategoryToCombobox(), "NameHangXe", "IdHangXe");
                this.ddlHangXe.SelectedValue = "0";

                TinhThanh objTinhThanh = new TinhThanh();
                setDroplist(this.ddlTinhThanh, objTinhThanh.getDataCategoryToCombobox(), "NameTinhThanh", "IdTinhThanh");
                this.ddlTinhThanh.SelectedValue = "0";

                DongXe objDongXe = new DongXe();
                setDroplist(this.ddlDongXe, objDongXe.getDataCategoryToCombobox(), "NameDongXe", "IdDongXe");
                this.ddlDongXe.SelectedValue = "0";

                //MauSac objMauSac = new MauSac();
                //setDroplist(this.ddlMauSac, objMauSac.getDataCategoryToCombobox(), "NameMauSac", "IdMauSac");

                //KieuDang objKieuDang = new KieuDang();
                //setDroplist(this.ddlKieuDang, objKieuDang.getDataCategoryToCombobox(), "NameKieuDang", "IdKieuDang");

                //SoCho objSoCho = new SoCho();
                //setDroplist(this.ddlSoCho, objSoCho.getDataCategoryToCombobox(), "NameSoCho", "IdSoCho");

                //SoCua objSoCua = new SoCua();
                //setDroplist(this.ddlSoCua, objSoCua.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

                ////TinhTrang objTinhTrang = new TinhTrang();
                ////setDroplist(this.ddlIdTinhTrang, objTinhTrang.getDataCategoryToCombobox(), "NameSoCua", "IdSoCua");

                //NhienLieu objNhienLieu = new NhienLieu();
                //setDroplist(this.ddlNhienLieu, objNhienLieu.getDataCategoryToCombobox(), "NameNhienLieu", "IdNhienLieu");


            }
            catch
            {
                //this.lblMsg.Text = "Có lỗi xảy ra! thử reset lại trang.";
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

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Oto objOto = new Oto();

            DataTable objData = objOto.getDataShowHome(txtSearchBox.Value, Int32.Parse(this.ddlHangXe.Text), Int32.Parse(this.ddlDongXe.Text), Int32.Parse(this.ddlTinhThanh.Text), Int32.Parse(this.ddlTingTrang.Text));

            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = 15;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();
        } catch
        {

        }
        
    }
}