using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TinTuc
/// </summary>
public class TinTuc :DataClass
{
    #region getDataById
    public DataRow getDataById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM [tblNews] WHERE [Id] = @id";
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

    #region method delData
    public void delData(int Id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE tblNews WHERE [Id] = @id";
            Cmd.Parameters.Add("id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            this.SQLClose();
        }
        catch
        {

        }
    }
    #endregion

    #region method setData
    public int setData(int ID, string Title,String Author , int IdCategory, String Describe, String Content, String ImgUrl)
    {
        int tmpValue = 0;
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblNews WHERE Id = @ID) ";
            Cmd.CommandText += "BEGIN INSERT INTO tblNews([CatId],[Title],Author,[ShortContent],[Content],[ImgUrl],[UserPost],State,[DayPost]) VALUES(@IdCategory,@Title,@Author,@Describe,@Content,@ImgUrl,@UserPost,1,getdate()) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblNews SET CatId = @IdCategory,Title = @Title,Author = @Author,ShortContent = @Describe,[Content] = @Content,ImgUrl = @ImgUrl  WHERE Id = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID;
            Cmd.Parameters.Add("IdCategory", SqlDbType.Int).Value = IdCategory;
            Cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = Title;
            Cmd.Parameters.Add("Author", SqlDbType.NVarChar).Value = Author;
            Cmd.Parameters.Add("Describe", SqlDbType.NVarChar).Value = Describe;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("ImgUrl", SqlDbType.NVarChar).Value = ImgUrl;
            Cmd.Parameters.Add("UserPost", SqlDbType.NVarChar).Value = HttpContext.Current.Session["ACCOUNT"];

            Cmd.ExecuteNonQuery();

            this.SQLClose();

            tmpValue = 1;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region getTopShowHome
    public DataTable getTopShowHome(int idCaterogi = 0, int limit = 5, String searchKey = "",int tinlq = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            String lt = (limit == 0) ? "" : "TOP " + limit;
            Cmd.CommandText = "SELECT " + lt + " [Id],[Title],[ShortContent],[ImgUrl],[DayPost] FROM [tblNews] ";
            //Cmd.Parameters.Add("top", SqlDbType.Int).Value = limit;
            Cmd.CommandText += " WHERE [State] = 1";
            if (idCaterogi != 0)
            {
                Cmd.CommandText += " AND [CatId] = @catid";
                Cmd.Parameters.Add("catid", SqlDbType.Int).Value = idCaterogi;
            }

            if (tinlq != 0)
            {
                Cmd.CommandText += " AND [Id] != @tinlq";
                Cmd.Parameters.Add("tinlq", SqlDbType.Int).Value = tinlq;
            }

            if (searchKey.Trim() != "")
            {
                Cmd.CommandText += " AND UPPER(LTRIM(RTRIM([Title]))) LIKE N'%'+UPPER(LTRIM(RTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            }

            Cmd.CommandText += " ORDER BY [DayPost] DESC";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            return ret;
        } catch(Exception ex)
        {
            Message = ex.Message;
            ErrorCode = ex.HResult;
            return new DataTable();
        }
    }
    #endregion
}