using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Oto
/// </summary>
public class Oto : DataClass
{
    #region getData
    public DataTable getData(string searchKey = "", int idHangXe = 0,int idDongXe = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT 0 AS TT, * FROM [tblOto] WHERE 1=1";

            if (searchKey.Trim() != "")
            {
                Cmd.CommandText += " AND UPPER(LTRIM(RTRIM(IdNameOto))) LIKE N'%'+UPPER(LTRIM(RTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            }

            if (idHangXe != 0)
            {
                Cmd.CommandText += " AND IdHangXe = @IdHangXe";
                Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = idHangXe;
            }

            if (idDongXe != 0)
            {
                Cmd.CommandText += " AND IdDongXe = @IdDongXe";
                Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = idDongXe;
            }

            Cmd.CommandText += " ORDER BY [NgayDang] DESC";
            
            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            for (int i = 1; i <= ret.Rows.Count; i++)
            {
                ret.Rows[i - 1]["TT"] = i;
            }
                
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return new DataTable(); ;
        }
    }
    #endregion

    #region getDataShowHome
    public DataTable getDataShowHome(string searchKey = "", int idHangXe = 0, int idDongXe = 0,int idTinhThanh = 0,int idTinhTrang = 2)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT REPLACE(REPLACE(CAST(oto.[IdTinhTrang] AS varchar),'1',N'Cũ'),'0',N'Mới') AS TinhTrang";
            Cmd.CommandText += ",REPLACE(REPLACE(CAST(oto.[IdXuatXu] AS varchar),'1',N'Trong nước'),'0',N'Nhập khẩu') AS XuatXu";
            Cmd.CommandText += ",oto.[IdOto],oto.[IdNameOto],oto.[NgayDang],oto.[GiaBan],nl.[NameNhienLieu],dx.[NameDongXe]";
            Cmd.CommandText += ",hx.[NameHangXe],sc.[NameSoCho],scu.[NameSoCua],ms.[NameMauSac],tit.NameTinhThanh,kd.NameKieuDang";
            Cmd.CommandText += ",oto.NamSanXuat,tv.[Phone]";
            Cmd.CommandText += " FROM [tblOto] AS oto";
            Cmd.CommandText += " LEFT JOIN tblNhienLieu AS nl ON oto.[IdNhienLieu] = nl.[IdNhienLieu]";
            Cmd.CommandText += " LEFT JOIN [tblDongXe] AS dx ON oto.[IdDongXe] = dx.[IdDongXe]";
            Cmd.CommandText += " LEFT JOIN [tblHangXe] AS hx ON oto.[IdHangXe] = hx.[IdHangXe]";
            Cmd.CommandText += " LEFT JOIN [tblSoCho] AS sc ON oto.[IdSoCho] = sc.[IdSoCho]";
            Cmd.CommandText += " LEFT JOIN [tblSoCua] AS scu ON oto.[IdSoCua] = scu.[IdSoCua]";
            Cmd.CommandText += " LEFT JOIN [tblMauSac] AS ms ON oto.[IdMauSac] = ms.[IdMauSac]";
            Cmd.CommandText += " LEFT JOIN [tblTinhThanh] AS tit ON oto.[IdTinhThanh] = tit.[IdTinhThanh]";
            Cmd.CommandText += " LEFT JOIN [tblKieuDang] AS kd ON oto.[IdKieuDang] = kd.[IdKieuDang]";
            Cmd.CommandText += " LEFT JOIN [tblThanhVien] AS tv ON oto.[IdMember] = tv.[IdThanhVien]";
           // Cmd.CommandText += " LEFT JOIN [tblHopSo] AS hs ON oto.[IdHopSo] = hs.[IdHopSo]";
            Cmd.CommandText += " WHERE 1=1";

            if (searchKey.Trim() != "")
            {
                Cmd.CommandText += " AND UPPER(LTRIM(RTRIM(oto.IdNameOto))) LIKE N'%'+UPPER(LTRIM(RTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            }

            if (idHangXe != 0)
            {
                Cmd.CommandText += " AND oto.IdHangXe = @IdHangXe";
                Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = idHangXe;
            }

            if (idDongXe != 0)
            {
                Cmd.CommandText += " AND oto.IdDongXe = @IdDongXe";
                Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = idDongXe;
            }

            if (idTinhThanh != 0)
            {
                Cmd.CommandText += " AND oto.IdTinhThanh = @IdTinhThanh";
                Cmd.Parameters.Add("IdTinhThanh", SqlDbType.Int).Value = idTinhThanh;
            }

            if (idTinhTrang < 2)
            {
                Cmd.CommandText += " AND oto.IdTinhTrang = @IdTinhTrang";
                Cmd.Parameters.Add("IdTinhTrang", SqlDbType.Int).Value = idTinhTrang;
            }

            Cmd.CommandText += " ORDER BY oto.[NgayDang] DESC";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return new DataTable(); ;
        }
    }
    #endregion

    public int insert(String IdNameOto, String Mota, float GiaBan, String NamSanXuat, int IdMember,
                int IdTinhTrang, int IdXuatXu, int IdHopSo, int IdKieuDang, int IdNhienLieu,
                int IdTinhThanh, int IdMauSac, int IdSoCho, int IdSoCua, int IdHangXe, int IdDongXe,
                String img1 = "",String img2 = "",String img3 = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO [tblOto](";
            Cmd.CommandText += "[IdNameOto],[IdTinhTrang],[IdXuatXu],[IdHopSo],[NamSanXuat],[IdKieuDang],[IdNhienLieu]";
            Cmd.CommandText += ",[IdTinhThanh],[IdMauSac],[IdSoCho],[IdSoCua],[IdHangXe],[IdDongXe],[GiaBan],[Mota],[IdMember]";
            Cmd.CommandText += ",NameImage1,NameImage2,NameImage3) VALUES(";
            Cmd.CommandText += "@IdNameOto,@IdTinhTrang,@IdXuatXu,@IdHopSo,";
            Cmd.CommandText += "@NamSanXuat,@IdKieuDang,@IdNhienLieu,";
            Cmd.CommandText += "@IdTinhThanh,@IdMauSac,@IdSoCho,@IdSoCua,";
            Cmd.CommandText += "@IdHangXe,@IdDongXe,@GiaBan,@Mota,@IdMember,";
            Cmd.CommandText += "@img1,@img2,@img3) SELECT CAST(scope_identity() AS int)";

            Cmd.Parameters.Add("IdNameOto", SqlDbType.NVarChar).Value = IdNameOto;
            Cmd.Parameters.Add("Mota", SqlDbType.NText).Value = Mota;
            Cmd.Parameters.Add("GiaBan", SqlDbType.Float).Value = GiaBan;
            Cmd.Parameters.Add("IdMember", SqlDbType.Int).Value = IdMember;
            Cmd.Parameters.Add("NamSanXuat", SqlDbType.NVarChar).Value = NamSanXuat;

            Cmd.Parameters.Add("IdTinhTrang", SqlDbType.Int).Value = IdTinhTrang;
            Cmd.Parameters.Add("IdXuatXu", SqlDbType.Int).Value = IdXuatXu;
            Cmd.Parameters.Add("IdHopSo", SqlDbType.Int).Value = IdHopSo;
            Cmd.Parameters.Add("IdKieuDang", SqlDbType.Int).Value = IdKieuDang;
            Cmd.Parameters.Add("IdNhienLieu", SqlDbType.Int).Value = IdNhienLieu;
            Cmd.Parameters.Add("IdTinhThanh", SqlDbType.Int).Value = IdTinhThanh;
            Cmd.Parameters.Add("IdMauSac", SqlDbType.Int).Value = IdMauSac;
            Cmd.Parameters.Add("IdSoCho", SqlDbType.Int).Value = IdSoCho;
            Cmd.Parameters.Add("IdSoCua", SqlDbType.Int).Value = IdSoCua;
            Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = IdHangXe;
            Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = IdDongXe;

            Cmd.Parameters.Add("img1", SqlDbType.NVarChar).Value = img1;
            Cmd.Parameters.Add("img2", SqlDbType.NVarChar).Value = img2;
            Cmd.Parameters.Add("img3", SqlDbType.NVarChar).Value = img3;

            int ret = (int)Cmd.ExecuteScalar();
            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }

}