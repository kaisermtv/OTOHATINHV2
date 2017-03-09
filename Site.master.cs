using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    #region declare objects
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    private Category objCategory = new Category();
    private DataTable objTableMenuHorizontal = new DataTable();
    public string strMenuHorizontal = "", strAction = "";
    #endregion

    #region method Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    } 
    #endregion

    #region method master_Page_PreLoad
    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    } 
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["THANHVIEN"] == null)
        {
            strAction =  "<a href=\"/Member/Register.aspx\">";
            strAction += "<img src=\"../Images/btnRegister.png\" alt=\"Đăng nhập\"></a>";
            strAction += "<a href=\"/Member/Login.aspx\">";
            strAction += "<img src=\"../Images/btnLogin.png\" alt=\"Đăng nhập\"></a>";
        }
        else
        {
            strAction = "<a href=\"#\">";
            strAction += "<img src=\"../Images/btnAccount.png\" alt=\"Đăng nhập\">&nbsp;Xin chào " + Session["THANHVIEN"].ToString();
            strAction += "</a>";
            strAction += "&nbsp;&nbsp;&nbsp;";
            strAction += "<a href=\"/Member/Logout.aspx\">";
            strAction += "<img src=\"../Images/btnLogout.png\" alt=\"Thoat\">&nbsp;Thoát";
            strAction += "</a>";
        }
        //if (!Page.IsPostBack)
        //{
            this.objTableMenuHorizontal = this.objCategory.getDataForHorizontal();
            if (this.objTableMenuHorizontal.Rows.Count > 0)
            {
                for (int i = 0; i < this.objTableMenuHorizontal.Rows.Count; i++)
                {
                    String urls ="";
                    if(this.objTableMenuHorizontal.Rows[i]["MenuUrl"] != null && this.objTableMenuHorizontal.Rows[i]["MenuUrl"].ToString() != "")
                    {
                        urls = this.objTableMenuHorizontal.Rows[i]["MenuUrl"].ToString();
                    }
                    else
                    {
                        urls = "/news.aspx?id=" + this.objTableMenuHorizontal.Rows[i]["Id"].ToString();
                    }
                    

                    this.strMenuHorizontal += "<li><a runat=\"server\" href=\"" + urls + "\">" + this.objTableMenuHorizontal.Rows[i]["Name"].ToString() + "</a></li>";
                }
            }


        //}
    } 
    #endregion

    #region method Unnamed_LoggingOut
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    } 
    #endregion

    #region method btnPost_Click
    protected void btnPost_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Member/Post.aspx");
    } 
    #endregion
}