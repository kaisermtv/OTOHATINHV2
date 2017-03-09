using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Category
{
    #region method Category
    public Category()
    {

    }
    #endregion

    #region method getData
    public DataTable getData()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(ISNULL(MenuHorizontal,0) AS nvarchar),'1','Menu ngang'),'0','') AS MenuNgang, REPLACE(REPLACE(CAST(ISNULL(MenuVertical,0) AS nvarchar),'1',N'Menu dọc'),'0','') AS MenuDoc FROM tblCategory";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            objTable = ds.Tables[0];

        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataName
    public string getDataName(int Id)
    {
        string tmpValue = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCategory WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["Name"].ToString();
            }
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getDataIDByNewsId
    public string getDataIDByNewsId(int NewsId)
    {
        string tmpValue = "0";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCategory WHERE Id = (SELECT CatId FROM tblNews WHERE Id = @Id)";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = NewsId;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["Id"].ToString();
            }
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getDataNameByNewsId
    public string getDataNameByNewsId(int NewsId)
    {
        string tmpValue = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCategory WHERE Id = (SELECT CatId FROM tblNews WHERE Id = @Id)";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = NewsId;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["Name"].ToString();
            }
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getDataParent
    public DataTable getDataParent()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ISNULL(ParentId,0) = 0";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0,"Hiện tất cả");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataByParentId
    public DataTable getDataByParentId(int ParentId)
    {
        string sqlQueryParentId = "";
        if (ParentId > 0)
        {
            sqlQueryParentId = " AND ParentId = @ParentId";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(ISNULL(MenuHorizontal,0) AS nvarchar),'1','Menu ngang'),'0','') AS MenuNgang, REPLACE(REPLACE(CAST(ISNULL(MenuVertical,0) AS nvarchar),'1',N'Menu dọc'),'0','') AS MenuDoc FROM tblCategory WHERE 1 = 1 " + sqlQueryParentId;
            Cmd.Parameters.Add("ParentId",SqlDbType.Int).Value = ParentId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            objTable = ds.Tables[0];

        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataByMenu
    public DataTable getDataByMenu()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(ISNULL(MenuHorizontal,0) AS nvarchar),'1','Menu ngang'),'0','') AS MenuNgang, REPLACE(REPLACE(CAST(ISNULL(MenuVertical,0) AS nvarchar),'1',N'Menu dọc'),'0','') AS MenuDoc FROM tblCategory WHERE ISNULL(MenuHorizontal,0) = 1 OR ISNULL(MenuVertical,0) = 1 OR ISNULL(MenuOther,0) = 1";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            objTable = ds.Tables[0];

        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataForHorizontal
    public DataTable getDataForHorizontal()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name, MenuUrl FROM tblCategory WHERE ISNULL(ParentId,0) = 0 AND ISNULL(MenuHorizontal,0) = 1 ORDER BY MenuHorizontalIndex";
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

    #region method getDataForHorizontal
    public DataTable getDataForHorizontal(int ParentId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ParentId = @ParentId AND ISNULL(MenuHorizontal,0) = 1 ORDER BY MenuHorizontalIndex";
            Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
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

    #region method getDataForVertical
    public DataTable getDataForVertical()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ISNULL(ParentId,0) = 0 AND ISNULL(MenuVertical,0) = 1 ORDER BY MenuVerticalIndex";
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

    #region method getDataForVertical
    public DataTable getDataForVertical(int ParentId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ParentId = @ParentId AND ISNULL(MenuVertical,0) = 1 ORDER BY MenuVerticalIndex";
            Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
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

    #region method getDataForHomePage
    public DataTable getDataForHomePage()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ISNULL(ShowHomePC,0) = 1 ORDER BY ShowHomePCIndex";
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

    #region method checkForchildren
    public bool checkForchildren(int ParentId)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCategory WHERE ParentId = @ParentId";
            Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpValue = true;
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getDataIntoCombobox
    public DataTable getDataIntoCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE [MenuUrl] IS NULL OR [MenuUrl] = @menuurl ";
            Cmd.Parameters.Add("menuurl", SqlDbType.NVarChar).Value = "" ;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0,"Không chọn");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getData
    public DataTable getData(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCategory WHERE Id = @Id ";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
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

    #region method addData
    public int addData(int Id, int ParentId, string Name, bool ShowTaskBarMobile, int ShowTaskBarMobileIndex, bool ShowHomeMobile, int ShowHomeMobileIndex, bool MenuHorizontal, int MenuHorizontalIndex, bool MenuVertical, int MenuVerticalIndex)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblCategory WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblCategory(ParentId,Name,ShowTaskBarMobile,ShowTaskBarMobileIndex,ShowHomeMobile,ShowHomeMobileIndex,MenuHorizontal,MenuHorizontalIndex,MenuVertical,MenuVerticalIndex) VALUES(@ParentId,@Name,@ShowTaskBarMobile,@ShowTaskBarMobileIndex,@ShowHomeMobile,@ShowHomeMobileIndex,@MenuHorizontal,@MenuHorizontalIndex,@MenuVertical,@MenuVerticalIndex) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblCategory SET ParentId = @ParentId, Name = @Name, ShowTaskBarMobile = @ShowTaskBarMobile, ShowTaskBarMobileIndex = @ShowTaskBarMobileIndex, ShowHomeMobile = @ShowHomeMobile, ShowHomeMobileIndex = @ShowHomeMobileIndex, MenuHorizontal = @MenuHorizontal, MenuHorizontalIndex = @MenuHorizontalIndex, MenuVertical = @MenuVertical, MenuVerticalIndex = @MenuVerticalIndex WHERE Id = @Id END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("ShowTaskBarMobile", SqlDbType.Bit).Value = ShowTaskBarMobile;
            Cmd.Parameters.Add("ShowTaskBarMobileIndex", SqlDbType.Int).Value = ShowTaskBarMobileIndex;
            Cmd.Parameters.Add("ShowHomeMobile", SqlDbType.Bit).Value = ShowHomeMobile;
            Cmd.Parameters.Add("ShowHomeMobileIndex", SqlDbType.Int).Value = ShowHomeMobileIndex;

            Cmd.Parameters.Add("MenuHorizontal", SqlDbType.Bit).Value = MenuHorizontal;
            Cmd.Parameters.Add("MenuHorizontalIndex", SqlDbType.Int).Value = MenuHorizontalIndex;
            
            Cmd.Parameters.Add("MenuVertical", SqlDbType.Bit).Value = MenuVertical;
            Cmd.Parameters.Add("MenuVerticalIndex", SqlDbType.Int).Value = MenuVerticalIndex;

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

    #region method setMenuUrl
    public void setMenuUrl(int Id, string MenuUrl)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery += "UPDATE tblCategory SET MenuUrl = @MenuUrl WHERE Id = @Id OR ParentId = @Id";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("MenuUrl", SqlDbType.NVarChar).Value = MenuUrl;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region method delData
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblCategory WHERE Id = @Id ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region Mobile
    #region method getDataTaskbarMobileMenu
    public DataTable getDataTaskbarMobileMenu()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT CategoryID AS Id, CategoryName AS Name FROM [CATEGORIES] WHERE CategoryID IN (801,808,812,873,868) ORDER BY Showindex";
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

    #region method getDataShowHomeMobile
    public DataTable getDataShowHomeMobile()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT CategoryID AS Id, CategoryName AS Name FROM CATEGORIES WHERE CategoryID IN (758,703.792,702,800) ORDER BY CategoryOrder";
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
    #endregion
}