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
    public DataTable getData(string searchKey = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT 0 AS TT, * FROM [tblOto] ";

            if (searchKey.Trim() != "")
            {
                Cmd.CommandText += " WHERE UPPER(LTRIM(RTRIM(IdNameOto))) LIKE N'%'+UPPER(LTRIM(RTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
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

    public int insert(String IdNameOto, String Mota, float GiaBan, String NamSanXuat, int IdMember,
                int IdTinhTrang, int IdXuatXu, int IdHopSo, int IdKieuDang, int IdNhienLieu,
                int IdTinhThanh, int IdMauSac, int IdSoCho, int IdSoCua, int IdHangXe, int IdDongXe)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO [tblOto](";
            Cmd.CommandText += "[IdNameOto],[IdTinhTrang],[IdXuatXu],[IdHopSo],[NamSanXuat],[IdKieuDang],[IdNhienLieu]";
            Cmd.CommandText += ",[IdTinhThanh],[IdMauSac],[IdSoCho],[IdSoCua],[IdHangXe],[IdDongXe],[GiaBan],[Mota],[IdMember]";
            Cmd.CommandText += ") VALUES(";
            Cmd.CommandText += "@IdNameOto,@IdTinhTrang,@IdXuatXu,@IdHopSo,";
            Cmd.CommandText += "@NamSanXuat,@IdKieuDang,@IdNhienLieu,";
            Cmd.CommandText += "@IdTinhThanh,@IdMauSac,@IdSoCho,@IdSoCua,";
            Cmd.CommandText += "@IdHangXe,@IdDongXe,@GiaBan,@Mota,@IdMember";
            Cmd.CommandText += ") SELECT CAST(scope_identity() AS int)";

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