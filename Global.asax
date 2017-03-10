<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        
        routes.MapPageRoute("trangchu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("tintuc", "tin-tuc", "~/News.aspx");
        routes.MapPageRoute("tintuc1", "tin-tuc/{id}", "~/News.aspx");
        
        
        routes.MapPageRoute("chuyenmuc", "{name}/{id}", "~/NewsCategory.aspx");
        routes.MapPageRoute("vanban", "{name}-document{id}", "~/Document/Default.aspx");
        routes.MapPageRoute("thongbao", "{name}-notice{id}", "~/Detailt.aspx");
        routes.MapPageRoute("chitiettintuc", "{name}-post{id}", "~/NewsDetailt.aspx");
        routes.MapPageRoute("danhsach", "{name}-list{id}", "~/ListCategory.aspx");
        routes.MapPageRoute("danhsachchitiet", "{name}-detail{id}", "~/ListCategoryDetail.aspx");
        routes.MapPageRoute("danhsachchitietbaiviet", "{name}-content{id}", "~/ListNewsDetail.aspx");
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
