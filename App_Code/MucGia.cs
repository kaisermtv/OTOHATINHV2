using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class MucGia : DataClass
{
	#region method MucGia
    public MucGia()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IdMucGia, string NameMucGia, bool State,float tugia = 0,float dengia = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblMucGia WHERE IdMucGia = @IdMucGia) ";
            Cmd.CommandText += "BEGIN INSERT INTO tblMucGia(NameMucGia,State,TuGia,DenGia) VALUES(@NameMucGia,@State,@TuGia,@DenGia) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblMucGia SET NameMucGia = @NameMucGia, State = @State, TuGia = @TuGia, DenGia = @DenGia WHERE IdMucGia = @IdMucGia END";

            Cmd.Parameters.Add("IdMucGia", SqlDbType.Int).Value = IdMucGia;
            Cmd.Parameters.Add("TuGia", SqlDbType.Float).Value = tugia;
            Cmd.Parameters.Add("DenGia", SqlDbType.Float).Value = dengia;
            Cmd.Parameters.Add("NameMucGia", SqlDbType.NVarChar).Value = NameMucGia;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.ExecuteNonQuery();
            this.SQLClose();

            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameMucGia))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblMucGia WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IdMucGia)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IdMucGia", SqlDbType.Int).Value = IdMucGia;
            Cmd.CommandText = "SELECT * FROM tblMucGia WHERE IdMucGia = @IdMucGia";
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
    public DataTable getDataCategoryToCombobox(String noselect = "Không chọn")
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IdMucGia, NameMucGia FROM tblMucGia";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];

            if (noselect != "")
                objTable.Rows.Add(0, noselect);
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delData
    public void delData(int IDMucGia)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblMucGia WHERE IDMucGia = @IDMucGia ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDMucGia", SqlDbType.Int).Value = IDMucGia;
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