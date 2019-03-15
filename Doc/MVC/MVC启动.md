## MVC 事件

[参考地址](https://www.cnblogs.com/darrenji/p/3795661.html)

HttpRuntime维护着一个HttpApplication池，当有HTTP请求过来，从池中选取可用的HttpApplication处理请求


1、BeginRequest：HTTP管道开始处理请求时，会触发BeginRequest事件

2、AuthenticateRequest：安全模块对请求进行身份验证时触发该事件

3、PostAuthenticateRequest：安全模块对请求进行身份验证后触发该事件

4、AuthorizeRequest：安全模块对请求进程授权时触发该事件

5、PostAuthorizeRequest：安全模块对请求进程授权后触发该事件

6、ResolveRequestCache：缓存模块利用缓存直接对请求进程响应时触发该事件

7、PostResolveRequestCache：缓存模块利用缓存直接对请求进程响应后触发该事件

8、PostMapRequestHandler：对于访问不同的资源类型，ASP.NET具有不同的HttpHandler对其进程处理。对于每个请求，ASP.NET会根据扩展名选择匹配相应的HttpHandler类型，成功匹配后触发该事件

9、AcquireRequestState：状态管理模块获取基于当前请求相应的状态(比如SessionState)时触发该事件

10、PostAcquireRequestState：状态管理模块获取基于当前请求相应的状态(比如SessionState)后触发该事件

11、PreRequestHandlerExecute：在实行HttpHandler前触发该事件

12、PostRequestHandlerExecute：在实行HttpHandler后触发该事件

13、ReleaseRequestState：状态管理模块释放基于当前请求相应的状态时触发该事件

14、PostReleaseRequestState：状态管理模块释放基于当前请求相应的状态后触发该事件

15、UpdateRequestCache：缓存模块将HttpHandler处理请求得到的相应保存到输出缓存时触发该事件

16、PostUpdateRequestCache：缓存模块将HttpHandler处理请求得到的相应保存到输出缓存后触发该事件

17、LogRequest：为当前请求进程日志记录时触发该事件

18、PostLogReques：为当前请求进程日志记录后触发该事件

19、EndRequest：整个请求处理完成后触发该事件


---
在ASP.NET程序中可以通过Global.asax文件来注册这些事件，一般创建ASP.NET应用程序项目时将会自动创建一个Global.asax文件，比如MVC应用中的Global.asax：
```C#
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
```        