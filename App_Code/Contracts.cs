using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Contracts :DataClass
{

    #region method getData
    public DataTable getData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(ISNULL(State,0) AS nvarchar),'1',N'Đã trả lời'),'0','-') AS StateName FROM tblContact";

            DataTable ret = this.findAll(Cmd);
            this.SQLClose();

            for (int i = 0; i < ret.Rows.Count; i++)
            {
                ret.Rows[i]["TT"] = (i + 1);
            }

            return ret;
        }
        catch
        {
            return new DataTable();
        }
    }
    #endregion

    #region method getData
    public DataTable getData(int Id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT * FROM tblContact WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            
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

    #region method setData
    public int addData(int Id, string FullName, string Email, string Title, string Question)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblContact WHERE Id = @Id) ";
            Cmd.CommandText += "BEGIN INSERT INTO tblContact(FullName,Email,Title,Question) VALUES(@FullName,@Email,@Title,@Question) END ";

            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = FullName;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = Title;
            Cmd.Parameters.Add("Question", SqlDbType.NVarChar).Value = Question;

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

    #region method setData
    public void setData(int Id, string Answer, bool State, DateTime DayPost, int UserAnswer)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblContact SET Answer = @Answer, State = @State, DayPost = @DayPost, UserAnswer = @UserAnswer WHERE Id = @Id";

            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Answer", SqlDbType.NText).Value = Answer;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("DayPost", SqlDbType.DateTime).Value = DayPost;
            Cmd.Parameters.Add("UserAnswer", SqlDbType.Int).Value = UserAnswer;
            
            Cmd.ExecuteNonQuery();
            this.SQLClose();
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
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "DELETE tblContact WHERE Id = @Id ";

            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;

            Cmd.ExecuteNonQuery();
            this.SQLClose();
        }
        catch
        {

        }
    }
    #endregion
}