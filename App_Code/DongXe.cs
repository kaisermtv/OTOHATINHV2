using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DongXe
{
	#region method DongXe
    public DongXe()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IdDongXe, string NameDongXe, int IdHangXe, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblDongXe WHERE IdDongXe = @IdDongXe) ";
            sqlQuery += "BEGIN INSERT INTO tblDongXe(NameDongXe,IdHangXe,State) VALUES(@NameDongXe,@IdHangXe,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblDongXe SET NameDongXe = @NameDongXe, IdHangXe = @IdHangXe, State = @State WHERE IdDongXe = @IdDongXe END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = IdDongXe;
            Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = IdHangXe;
            Cmd.Parameters.Add("NameDongXe", SqlDbType.NVarChar).Value = NameDongXe;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getData
    public DataTable getData(int IdHangXe, string searchKey)
    {
        string sqlQuery = "", sqlQueryHangXe = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameDongXe))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        if (IdHangXe > 0)
        {
            sqlQueryHangXe = " AND tblDongXe.IdHangXe = @IdHangXe";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = IdHangXe;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(tblDongXe.State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblDongXe, tblHangXe WHERE tblDongXe.IdHangXe = tblHangXe.IdHangXe " + sqlQuery + sqlQueryHangXe;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataById
    public DataTable getDataById(int IdDongXe)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = IdDongXe;
            Cmd.CommandText = "SELECT * FROM tblDongXe WHERE IdDongXe = @IdDongXe";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IdDongXe, NameDongXe FROM tblDongXe";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0, "Không chọn");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delData
    public void delData(int IdDongXe)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblDongXe WHERE IdDongXe = @IdDongXe ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IdDongXe", SqlDbType.Int).Value = IdDongXe;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion
}