﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class HangXe : DataClass
{

	#region method HangXe
    public HangXe()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IdHangXe, string NameHangXe, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblHangXe WHERE IdHangXe = @IdHangXe) ";
            sqlQuery += "BEGIN INSERT INTO tblHangXe(NameHangXe,State) VALUES(@NameHangXe,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblHangXe SET NameHangXe = @NameHangXe, State = @State WHERE IdHangXe = @IdHangXe END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = IdHangXe;
            Cmd.Parameters.Add("NameHangXe", SqlDbType.NVarChar).Value = NameHangXe;
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
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(LTRIM(RTRIM(NameHangXe))) LIKE N'%'+UPPER(LTRIM(RTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblHangXe WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IdHangXe)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IdHangXe", SqlDbType.Int).Value = IdHangXe;
            Cmd.CommandText = "SELECT * FROM tblHangXe WHERE IdHangXe = @IdHangXe";
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

    #region method getIdByName
    public int getIdByName(string NameHangXe)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("NameHangXe", SqlDbType.NVarChar).Value = NameHangXe;
            Cmd.CommandText = "SELECT TOP 1 IdHangXe AS Id FROM tblHangXe WHERE NameHangXe = @NameHangXe";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            return int.Parse(objTable.Rows[0]["Id"].ToString());
        }
        catch
        {
            return 0;
        }
     
    }
    #endregion

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox(String noselect = "Không chọn" )
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IdHangXe, NameHangXe FROM tblHangXe";
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

    #region method getDataToRightElemant
    public DataTable getDataToRightElemant()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT IdHangXe, NameHangXe,(SELECT COUNT(tblOto.IdHangXe) FROM tblOto WHERE tblOto.IdHangXe = tblHangXe.IdHangXe) AS CountItem FROM tblHangXe";

            DataTable ret = this.findAll(Cmd);
            this.SQLClose();

            return ret;
        }
        catch
        {
            return new DataTable();
        }
        
    }
    #endregion

    #region method delData
    public void delData(int IDHangXe)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblHangXe WHERE IDHangXe = @IDHangXe ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDHangXe", SqlDbType.Int).Value = IDHangXe;
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