# MyBlog
ASP.NET  MVC5系列学习
1. ASP.NET MVC  系统学习
---
### 19-03-14进度
EF  迁移

### MVC 路由

1. MVC程序启动

2. 执行 Global.asax的 Application_Start 方法

```C#
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    BundleConfig.RegisterBundles(BundleTable.Bundles);
}
```

3. 路由注册相关的代码为 **RouteConfig.RegisterRoutes(RouteTable.Routes)**

4. 实际方法为 App_Start 下面的
```C# 
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        namespaces:new[] { "MyBlog.Controllers"}
    );
}
```

5. 此方法使用RouteCollection  的MapRoute 方法进行路由注册

6. 反编译MVC源码观察 MapRoute方法
```C#
public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
{
    if (routes == null)
    {
        throw new ArgumentNullException("routes");
    }
    if (url == null)
    {
        throw new ArgumentNullException("url");
    }
    Route route = new Route(url, new MvcRouteHandler())
    {
        Defaults = CreateRouteValueDictionaryUncached(defaults),
        Constraints = CreateRouteValueDictionaryUncached(constraints),
        DataTokens = new RouteValueDictionary()
    };
    ConstraintValidation.Validate(route);
    if (namespaces != null && namespaces.Length != 0)
    {
        route.DataTokens["Namespaces"] = namespaces;
    }
    routes.Add(name, route);
    return route;
}

```

7. 主要是创建了一个**Route**对象 

    7.1 new 了一个 **MVCRouteHandler** 传给了当前的 **RouteHandler** 
    
    7.2 初始化了 当前**Route** 的成员 **Defaluts**、 **Constraints**、**DateTokens**，
    
    7.3 将此 **Route** 加入到当前的 **RouteCollection** 

    Route 初始化代码如下：
```C#
public Route(string url, IRouteHandler routeHandler)
{
	Url = url;
	RouteHandler = routeHandler;
}
```