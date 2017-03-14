using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class NamSanXuat:DataClass
{
	#region method NamSanXuat
    public NamSanXuat()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IdNamSanXuat, string NameNamSanXuat, bool State,int tunam = 0,int demnam = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblNamSanXuat WHERE IdNamSanXuat = @IdNamSanXuat) ";
            Cmd.CommandText += "BEGIN INSERT INTO tblNamSanXuat(NameNamSanXuat,State,TuNam,DenNam) VALUES(@NameNamSanXuat,@State,@TuNam,@DenNam) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblNamSanXuat SET NameNamSanXuat = @NameNamSanXuat, State = @State, TuNam = @TuNam, Dennam = @DenNam WHERE IdNamSanXuat = @IdNamSanXuat END";

            Cmd.Parameters.Add("IdNamSanXuat", SqlDbType.Int).Value = IdNamSanXuat;
            Cmd.Parameters.Add("TuNam", SqlDbType.Int).Value = tunam;
            Cmd.Parameters.Add("DenNam", SqlDbType.Int).Value = demnam;
            Cmd.Parameters.Add("NameNamSanXuat", SqlDbType.NVarChar).Value = NameNamSanXuat;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameNamSanXuat))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblNamSanXuat WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IdNamSanXuat)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.Parameters.Add("IdNamSanXuat", SqlDbType.Int).Value = IdNamSanXuat;
            Cmd.CommandText = "SELECT * FROM tblNamSanXuat WHERE IdNamSanXuat = @IdNamSanXuat";

            DataTable objTable = this.findAll(Cmd);
            this.SQLClose();

            return objTable;
        }
        catch
        {
            return new DataTable();
        }
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
            Cmd.CommandText = "SELECT IdNamSanXuat, NameNamSanXuat FROM tblNamSanXuat";
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
    public void delData(int IDNamSanXuat)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblNamSanXuat WHERE IDNamSanXuat = @IDNamSanXuat ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNamSanXuat", SqlDbType.Int).Value = IDNamSanXuat;
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