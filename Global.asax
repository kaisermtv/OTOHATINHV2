<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        
        routes.MapPageRoute("trangchu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("trangchu1", "{name}-post{id}", "~/ViewOto.aspx");
        routes.MapPageRoute("trangchu2", "trang-chu/{name}-post{id}", "~/ViewOto.aspx");
        
        routes.MapPageRoute("tintuc", "tin-tuc", "~/News.aspx");
        routes.MapPageRoute("tintuc1", "tin-tuc/{id}", "~/News.aspx");
        routes.MapPageRoute("tintuc2", "tin-tuc/{name}-post{id}", "~/View.aspx");

        routes.MapPageRoute("dangnhap", "dang-nhap", "~/Member/Login.aspx");
        
        
    }

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        
    }

    void Application_Error(object sender, EventArgs e)
    {
    }

       
</script>
