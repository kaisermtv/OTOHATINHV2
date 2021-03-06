﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    #region declare value
    public string strHtmlTest = "";
    private int PageSize = 6;


    public int hostIdTuVan = 0;
    public String hostTimePostTuVan = "";
    public String hostImgTuVan = "";
    public String hostTileTuVan = "";
    public String hostShortContentTuVan = "";
    #endregion

   
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!Page.IsPostBack)
        {
            int hangxe = getValueInt("hangxe");
            int dongxe = getValueInt("dongxe");
            int tinhthanh = getValueInt("tinhthanh");
            int mucgia = getValueInt("mucgia");
            int namsanxuat = getValueInt("namsx");
            int kieudang = getValueInt("kieudang");

            int tinhtrang = 2;
            try
            {
                tinhtrang = Int32.Parse(Request["tinhtrang"].ToString());
            }
            catch { }
            this.ddlTingTrang.SelectedValue = tinhtrang.ToString();


            String Search = "";
            try
            {
                Search = Request["Search"].ToString();
            }
            catch { }
            txtSearchBox.Value = Search;

            Oto objOto = new Oto();

            DataTable objData = objOto.getDataShowHome(Search, hangxe, dongxe, tinhthanh, tinhtrang, kieudang, namsanxuat, mucgia);
            strHtmlTest = objOto.Message;
            cpChucVu.Visible = true;
            cpChucVu.MaxPages = 1000;
            cpChucVu.PageSize = PageSize;
            cpChucVu.DataSource = objData.DefaultView;
            cpChucVu.BindToControl = dtlChucVu;
            dtlChucVu.DataSource = cpChucVu.DataSourcePaged;
            dtlChucVu.DataBind();

            try
            {
                HangXe objHangXe = new HangXe();
                setDroplist(this.ddlHangXe, objHangXe.getDataCategoryToCombobox("Hãng xe"), "NameHangXe", "IdHangXe");
                this.ddlHangXe.SelectedValue = hangxe.ToString();

                LoadHangXe(hangxe);
                this.ddlDongXe.SelectedValue = dongxe.ToString();

                TinhThanh objTinhThanh = new TinhThanh();
                setDroplist(this.ddlTinhThanh, objTinhThanh.getDataCategoryToCombobox("Tỉnh thành"), "NameTinhThanh", "IdTinhThanh");
                this.ddlTinhThanh.SelectedValue = tinhthanh.ToString();

                MucGia objMucGia = new MucGia();
                setDroplist(this.ddlMucGia, objMucGia.getDataCategoryToCombobox("Mức giá"), "NameMucGia", "IdMucGia");
                this.ddlMucGia.SelectedValue = mucgia.ToString();

                NamSanXuat objNamSanXuat = new NamSanXuat();
                setDroplist(this.ddlNamSX, objNamSanXuat.getDataCategoryToCombobox("Năm SX"), "NameNamSanXuat", "IdNamSanXuat");
                this.ddlNamSX.SelectedValue = namsanxuat.ToString();

            }
            catch
            {
                //this.lblMsg.Text = "Có lỗi xảy ra! thử reset lại trang.";
            }

            TinTuc objTinTuc = new TinTuc();
            DataTable objDataTuVan = objTinTuc.getTopShowHome(32); // 32 ID Category Tư vấn xe 
            //strHtmlTest = objTinTuc.Message;
            if (objDataTuVan.Rows.Count > 0)
            {
                hostIdTuVan = (int)objDataTuVan.Rows[0]["Id"];
                hostImgTuVan = objDataTuVan.Rows[0]["ImgUrl"].ToString();
                hostTileTuVan = objDataTuVan.Rows[0]["Title"].ToString();
                hostShortContentTuVan = objDataTuVan.Rows[0]["ShortContent"].ToString();
                try
                {
                    hostTimePostTuVan = ((DateTime)objDataTuVan.Rows[0]["DayPost"]).ToString("dd/MM/yyyy");
                }
                catch
                {

                }

                objDataTuVan.Rows.Remove(objDataTuVan.Rows[0]);

                dtlTuVan.DataSource = objDataTuVan.DefaultView;
                dtlTuVan.DataBind();
            }
        }
                       
    }
    #endregion

    #region getValueInt
    public int getValueInt(String key)
    {
        int temp = 0;
        try
        {
            temp = Int32.Parse(Request[key].ToString());
        }
        catch { }
        try
        {
            temp = Int32.Parse(RouteData.Values[key].ToString());
        }
        catch { }

        return temp;
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

    #region imgSearch_Click
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        String rdr = "?";

        try
        {
            int i = Int32.Parse(this.ddlHangXe.Text);
            if(i != 0) rdr += "hangxe=" + i;
        }catch{}

        try
        {
            int i = Int32.Parse(this.ddlDongXe.Text);
            if (i != 0)
            {
                if (rdr != "?") rdr += "&";
                rdr += "dongxe=" + i;
            }
        }catch{}

        try
        {
            int i = Int32.Parse(this.ddlTinhThanh.Text);
            if (i != 0)
            {
                if (rdr != "?") rdr += "&";
                rdr += "tinhthanh=" + i;
            }
        }catch{}

        try
        {
            int i = Int32.Parse(this.ddlMucGia.Text);
            if (i != 0)
            {
                if (rdr != "?") rdr += "&";
                rdr += "mucgia=" + i;
            }
        }
        catch { }

        try
        {
            int i = Int32.Parse(this.ddlNamSX.Text);
            if (i != 0)
            {
                if (rdr != "?") rdr += "&";
                rdr += "namsx=" + i;
            }
        }
        catch { }

        try
        {
            int i = Int32.Parse(this.ddlTingTrang.Text);
            if (i < 2)
            {
                if (rdr != "?") rdr += "&";
                rdr += "tinhtrang=" + i;
            }
        }catch{}

        if(txtSearchBox.Value != "")
        {
            if(rdr != "?") rdr += "&";
            rdr += "Search=" + HttpUtility.UrlEncode(txtSearchBox.Value);
        }

        if (rdr == "?") rdr = "";
        Response.Redirect("/" + rdr);
    }
    #endregion

    #region ddlHangXe_TextChanged
    protected void ddlHangXe_TextChanged(object sender, EventArgs e)
    {
        try
        {
            LoadHangXe(Int32.Parse(ddlHangXe.SelectedValue));
        }
        catch { }
    }
    #endregion

    #region LoadHangXe
    public void LoadHangXe(int idHangxe = 0)
    {
        try
        {
            DongXe objDongXe = new DongXe();
            setDroplist(this.ddlDongXe, objDongXe.getDataCategoryToCombobox(idHangxe,"Dòng xe"), "NameDongXe", "IdDongXe");
            this.ddlDongXe.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}