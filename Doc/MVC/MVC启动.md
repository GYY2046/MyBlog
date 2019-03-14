## MVC启动顺序

　　1. BeginRequest 事件.

　　2. AuthenticateRequest 事件.

　　3. PostAuthenticateRequest 事件.

　　4. AuthorizeRequest 事件.

　　5. PostAuthorizeRequest 事件.

　　6. ResolveRequestCache 事件.

　　7. PostResolveRequestCache 事件.

　　8. MapRequestHandler 事件. 根据请求文件的拓展名来选择一个适合的处理器，这个处理器可以是非托管代码编写的模块如StaticFileModule或者是托管代码的模块如PageHandlerFactory（它用来处理.aspx文件）. 

　　9. PostMapRequestHandler 事件.

　　10. AcquireRequestState 事件.

　　11. PostAcquireRequestState 事件.

　　12. PreRequestHandlerExecute 事件.

　　13. 调用处理器的ProcessRequest方法 (或者是异步版本的).

　　14. PostRequestHandlerExecute 事件.

　　15. ReleaseRequestState 事件.

　　16. PostReleaseRequestState 事件.

　　17. 如果定义了过滤器则执行过滤器对相应信息进行过滤.

　　18. UpdateRequestCache 事件.

　　19. PostUpdateRequestCache 事件.

　　20. LogRequest 事件.

　　21. PostLogRequest 事件.

　　22. EndRequest 事件.

　　23. PreSendRequestHeaders 事件.

　　24. PreSendRequestContent 事件.

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