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
    #region method delData
    public void delData(int Id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE tblOto WHERE [IdOto] = @id";
            Cmd.Parameters.Add("id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            this.SQLClose();
        }
        catch
        {

        }
    }
    #endregion

    #region getOto
    public DataRow getOtoById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM [tblOto] WHERE [IdOto] = @id";
            Cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

            DataRow ret = this.findFirst(Cmd);

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    #endregion

    #region getData
    public DataTable getData(string searchKey = "",int idtrangthai = 4, int idHangXe = 0,int idDongXe = 0)
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

            if (idtrangthai != 4)
            {
                Cmd.CommandText += " AND IdTrangThai = @IdTrangThai";
                Cmd.Parameters.Add("IdTrangThai", SqlDbType.Int).Value = idtrangthai;
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
          //  this.ErrorCode = ex.HResult;
            return new DataTable(); ;
        }
    }
    #endregion

    #region getDataShowHome
    public DataTable getDataShowHome(string searchKey = "", int idHangXe = 0, int idDongXe = 0,int idTinhThanh = 0,int idTinhTrang = 2,int idKieuDang= 0,int namsx = 0,int IdMucGia = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT REPLACE(REPLACE(CAST(oto.[IdTinhTrang] AS varchar),'1',N'Cũ'),'0',N'Mới') AS TinhTrang";
            Cmd.CommandText += ",(CASE WHEN oto.[NameImage1] = '' THEN (CASE WHEN oto.[NameImage2] = '' THEN (CASE WHEN oto.[NameImage3] = '' THEN (CASE WHEN oto.[NameImage4] = '' THEN oto.[NameImage5] else oto.[NameImage4] END ) else oto.[NameImage3] END ) else oto.[NameImage2] END ) else oto.[NameImage1] END ) AS img";
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
            Cmd.CommandText += " WHERE oto.IdTrangThai = 1";

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
            if (idKieuDang > 0)
            {
                Cmd.CommandText += " AND oto.IdKieuDang = @idKieuDang";
                Cmd.Parameters.Add("idKieuDang", SqlDbType.Int).Value = idKieuDang;
            }

            if (namsx > 0)
            {
                NamSanXuat objNamSanXuat = new NamSanXuat();
                DataTable objData = objNamSanXuat.getDataById(namsx);
                if(objData.Rows.Count > 0)
                {
                    int tunam = 0;
                    try
                    {
                        tunam = Int32.Parse(objData.Rows[0]["TuNam"].ToString());
                    }
                    catch { }
                    
                    if (tunam != 0)
                    {
                        Cmd.CommandText += " AND oto.NamSanXuat >= @TuNam";
                        Cmd.Parameters.Add("TuNam", SqlDbType.Int).Value = tunam;
                    }

                    int dennam = 0;
                    try
                    {
                        dennam = Int32.Parse(objData.Rows[0]["DenNam"].ToString());
                    }
                    catch { }
                    if (dennam != 0)
                    {
                        Cmd.CommandText += " AND oto.NamSanXuat <= @DenNam";
                        Cmd.Parameters.Add("DenNam", SqlDbType.Int).Value = dennam;
                    }

                }

            }

            if(IdMucGia > 0)
            {
                MucGia objMucGia = new MucGia();
                DataTable objData = objMucGia.getDataById(IdMucGia);
                if (objData.Rows.Count > 0)
                {
                    float tugia = 0;
                    try
                    {
                        tugia = float.Parse(objData.Rows[0]["TuGia"].ToString());
                    }
                    catch { }
                    if ( tugia != 0)
                    {
                        Cmd.CommandText += " AND oto.GiaBan >= @TuGia";
                        Cmd.Parameters.Add("TuGia", SqlDbType.Float).Value = tugia;
                    }

                    float dengia = 0;
                    try
                    {
                        dengia = float.Parse(objData.Rows[0]["DenGia"].ToString());
                    }
                    catch { }
                    if (dengia != 0)
                    {
                        Cmd.CommandText += " AND oto.GiaBan <= @DenGia";
                        Cmd.Parameters.Add("DenGia", SqlDbType.Float).Value = dengia;
                    }

                }
            }

            Cmd.CommandText += " ORDER BY oto.[NgayDang] DESC";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
        //    this.ErrorCode = ex.HResult;
            return new DataTable();
        }
    }
    #endregion

    #region getDataLienQuan
    public DataTable getDataLienQuan(int limit = 5, int tinlq = 0, int idDongXe = 0)
    {
        try
        {
            String lmt = "";
            if(limit != 0)
            {
                lmt = " TOP " + limit;
            }

            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT" + lmt + " REPLACE(REPLACE(CAST(oto.[IdTinhTrang] AS varchar),'1',N'Cũ'),'0',N'Mới') AS TinhTrang";
            Cmd.CommandText += ",(CASE WHEN oto.[NameImage1] = '' THEN (CASE WHEN oto.[NameImage2] = '' THEN (CASE WHEN oto.[NameImage3] = '' THEN (CASE WHEN oto.[NameImage4] = '' THEN oto.[NameImage5] else oto.[NameImage4] END ) else oto.[NameImage3] END ) else oto.[NameImage2] END ) else oto.[NameImage1] END ) AS img";
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
            Cmd.CommandText += " WHERE oto.IdTrangThai = 1";

            if (tinlq != 0)
            {
                Cmd.CommandText += " AND oto.[IdOto] != @tinlq";
                Cmd.Parameters.Add("tinlq", SqlDbType.Int).Value = tinlq;
            }

            if (idDongXe != 0)
            {
                Cmd.CommandText += " AND oto.IdDongXe = @IdDongXe";
                Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = idDongXe;
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
            return new DataTable();
        }
    }
    #endregion

    #region getDataShowHomeById
    public DataRow getDataShowHomeById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT REPLACE(REPLACE(CAST(oto.[IdTinhTrang] AS varchar),'1',N'Cũ'),'0',N'Mới') AS TinhTrang";
            Cmd.CommandText += ",(CASE WHEN oto.[NameImage1] = '' THEN (CASE WHEN oto.[NameImage2] = '' THEN (CASE WHEN oto.[NameImage3] = '' THEN (CASE WHEN oto.[NameImage4] = '' THEN oto.[NameImage5] else oto.[NameImage4] END ) else oto.[NameImage3] END ) else oto.[NameImage2] END ) else oto.[NameImage1] END ) AS img";
            Cmd.CommandText += ",REPLACE(REPLACE(CAST(oto.[IdXuatXu] AS varchar),'1',N'Trong nước'),'0',N'Nhập khẩu') AS XuatXu";
            Cmd.CommandText += ",oto.[IdOto],oto.[IdNameOto],oto.[NgayDang],oto.[GiaBan],nl.[NameNhienLieu],dx.[NameDongXe]";
            Cmd.CommandText += ",hx.[NameHangXe],sc.[NameSoCho],scu.[NameSoCua],ms.[NameMauSac],tit.NameTinhThanh,kd.NameKieuDang";
            Cmd.CommandText += ",oto.NamSanXuat,tv.[Phone],oto.Mota,oto.NameImage1,oto.NameImage2,oto.NameImage3,oto.IdDongXe";
            Cmd.CommandText += ",oto.NameImage4,oto.NameImage5";
            Cmd.CommandText += ",REPLACE(REPLACE(CAST(oto.[IdHopSo] AS varchar),'1',N'Hộp số sàn'),'0',N'Hộp số tự động') AS HopSo";
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
            Cmd.CommandText += " WHERE oto.[IdOto] = @id AND IdTrangThai = 1";
            Cmd.Parameters.Add("id", SqlDbType.Int).Value = id;


            DataRow ret = this.findFirst(Cmd);

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    #endregion

    #region insert
    public int insert(String IdNameOto, String Mota, float GiaBan, String NamSanXuat, int IdMember,
                int IdTinhTrang, int IdXuatXu, int IdHopSo, int IdKieuDang, int IdNhienLieu,
                int IdTinhThanh, int IdMauSac, int IdSoCho, int IdSoCua, int IdHangXe, int IdDongXe,
                String img1 = "", String img2 = "", String img3 = "", String img4 = "", String img5 = "",
                String NgayHienThi = "",String HienThiDenNgay = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO [tblOto](";
            Cmd.CommandText += "[IdNameOto],[IdTinhTrang],[IdXuatXu],[IdHopSo],[NamSanXuat],[IdKieuDang],[IdNhienLieu]";
            Cmd.CommandText += ",[IdTinhThanh],[IdMauSac],[IdSoCho],[IdSoCua],[IdHangXe],[IdDongXe],[GiaBan],[Mota],[IdMember]";
            Cmd.CommandText += ",NameImage1,NameImage2,NameImage3,NameImage4,NameImage5,NgayHienThi,HienThiDenNgay) VALUES(";
            Cmd.CommandText += "@IdNameOto,@IdTinhTrang,@IdXuatXu,@IdHopSo,";
            Cmd.CommandText += "@NamSanXuat,@IdKieuDang,@IdNhienLieu,";
            Cmd.CommandText += "@IdTinhThanh,@IdMauSac,@IdSoCho,@IdSoCua,";
            Cmd.CommandText += "@IdHangXe,@IdDongXe,@GiaBan,@Mota,@IdMember,";
            Cmd.CommandText += "@img1,@img2,@img3,@img4,@img5,@NgayHienThi,@HienThiDenNgay) SELECT CAST(scope_identity() AS int)";

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
            Cmd.Parameters.Add("img4", SqlDbType.NVarChar).Value = img4;
            Cmd.Parameters.Add("img5", SqlDbType.NVarChar).Value = img5;

            Cmd.Parameters.Add("NgayHienThi", SqlDbType.NVarChar).Value = NgayHienThi;
            Cmd.Parameters.Add("HienThiDenNgay", SqlDbType.NVarChar).Value = HienThiDenNgay;

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
    #endregion

    #region update
    public bool update(int id,String IdNameOto, String Mota, float GiaBan, String NamSanXuat,
                int IdTinhTrang, int IdXuatXu, int IdHopSo, int IdKieuDang, int IdNhienLieu,
                int IdTinhThanh, int IdMauSac, int IdSoCho, int IdSoCua, int IdHangXe, int IdDongXe,
                String img1, String img2, String img3, String img4, String img5,int IdTrangThai,String NgayHienThi,String HienThiDenNgay)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE [tblOto] SET";
            Cmd.CommandText += " [IdNameOto] = @IdNameOto , [IdTinhTrang] = @IdTinhTrang , [IdXuatXu] = @IdXuatXu ,";
            Cmd.CommandText += " [IdHopSo] = @IdHopSo , [NamSanXuat] = @NamSanXuat, [IdKieuDang] = @IdKieuDang,";
            Cmd.CommandText += " [IdNhienLieu] = @IdNhienLieu, [IdTinhThanh] = @IdTinhThanh, [IdMauSac] = @IdMauSac,";
            Cmd.CommandText += " [IdSoCho] = @IdSoCho, [IdSoCua] = @IdSoCua, [IdHangXe] = @IdHangXe, [IdDongXe] = @IdDongXe,";
            Cmd.CommandText += " [GiaBan] = @GiaBan, [Mota] = @Mota,[IdTrangThai] = @IdTrangThai, ";
            Cmd.CommandText += " NameImage1 = @img1, NameImage2 = @img2, NameImage3 = @img3, NameImage4 = @img4, NameImage5 = @img5,";
            Cmd.CommandText += " NgayHienThi = @NgayHienThi, HienThiDenNgay = @HienThiDenNgay WHERE [IdOto] = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            Cmd.Parameters.Add("IdNameOto", SqlDbType.NVarChar).Value = IdNameOto;
            Cmd.Parameters.Add("Mota", SqlDbType.NText).Value = Mota;
            Cmd.Parameters.Add("GiaBan", SqlDbType.Float).Value = GiaBan;
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
            Cmd.Parameters.Add("IdTrangThai", SqlDbType.Int).Value = IdTrangThai;

            Cmd.Parameters.Add("img1", SqlDbType.NVarChar).Value = img1;
            Cmd.Parameters.Add("img2", SqlDbType.NVarChar).Value = img2;
            Cmd.Parameters.Add("img3", SqlDbType.NVarChar).Value = img3;
            Cmd.Parameters.Add("img4", SqlDbType.NVarChar).Value = img4;
            Cmd.Parameters.Add("img5", SqlDbType.NVarChar).Value = img5;

            Cmd.Parameters.Add("NgayHienThi", SqlDbType.NVarChar).Value = NgayHienThi;
            Cmd.Parameters.Add("HienThiDenNgay", SqlDbType.NVarChar).Value = HienThiDenNgay;

            int ret = Cmd.ExecuteNonQuery();
            this.SQLClose();

            if (ret != 0) return true;
        } catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
        }
        return false;
    }
    #endregion
}