<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        RouteValueDictionary rvdId = new RouteValueDictionary { { "id", "[0-9]*" }};
        RouteValueDictionary rvdSearch = new RouteValueDictionary { { "Search", ".*" } };
        
        
        routes.MapPageRoute("trangchu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("trangchu1", "{name}-post{id}", "~/ViewOto.aspx", false, rvdId);
        routes.MapPageRoute("trangchu2", "{name}-hx{hangxe}", "~/Default.aspx");
        routes.MapPageRoute("trangchu3", "trang-chu/{name}-post{id}", "~/ViewOto.aspx", false, rvdId);
        routes.MapPageRoute("trangchu4", "trang-chu/{name}-hx{hangxe}", "~/Default.aspx");

        routes.MapPageRoute("tintuc", "tin-tuc", "~/News.aspx");
        routes.MapPageRoute("tintuc1", "tin-tuc/cat-{id}", "~/News.aspx",false,rvdId);
        routes.MapPageRoute("tintuc2", "tin-tuc/cat-{id}/{Search}", "~/News.aspx", false, rvdId, rvdSearch);
        routes.MapPageRoute("tintuc3", "tin-tuc/{name}-post{id}", "~/View.aspx", false, rvdId);

        routes.MapPageRoute("dangnhap", "dang-nhap", "~/Member/Login.aspx");
        routes.MapPageRoute("dangky", "dang-ky", "~/Member/Register.aspx");

        routes.MapPageRoute("lienhe", "lien-he", "~/Contact.aspx");
        
        
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
