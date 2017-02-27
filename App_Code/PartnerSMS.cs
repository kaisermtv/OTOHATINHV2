using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class PartnerSMS
{
    #region method PartnerSMS
    public PartnerSMS()
    {
    } 
    #endregion

    #region method sendSMSPartnerByGroup
    public void sendSMSPartnerByGroup(string SMSContent, int GroupId, string UserName)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "SELECT PartnerId, Account FROM tblPartnerGroupDetailt, tblPartner WHERE tblPartnerGroupDetailt.PartnerId = tblPartner.Id AND GroupId = @GroupId";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.CommandText = sqlQuery;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                this.setData(SMSContent, int.Parse(Rd["PartnerId"].ToString()), Rd["Account"].ToString(), UserName);
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
    }
    #endregion

    #region method setData
    public void setData(string SMSContent, int PartnerId, string PartnerAccount, string UserName)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "INSERT INTO tblPartnerSMS(SMSContent,PartnerId,PartnerAccount,UserName,DayCreate,State) VALUES(@SMSContent,@PartnerId,@PartnerAccount,@UserName,getdate(),0)";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("SMSContent", SqlDbType.NVarChar).Value = SMSContent;
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
    }
    #endregion

    #region method getData
    public DataTable getData(string UserName)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *, (SELECT Name FROM tblPartner WHERE Id = PartnerId) AS PartnerName, REPLACE(REPLACE(CAST(State AS nvarchar),'1','Đã xem'),'0','Chưa xem') AS StateName FROM [dbo].[tblPartnerSMS] WHERE UserName = @UserName ORDER BY DayCreate DESC";
            Cmd.Parameters.Add("UserName",SqlDbType.NVarChar).Value = UserName;
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
}