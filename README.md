# MyBlog
ASP.NET  MVC5  系列学习


前言：接触MVC 也好几年了，乱七八糟学了一大堆，始终没有系统的整理过，这样的学习效果实在太差，最近看到一篇文章 [ASP.NET没有魔法](http://www.cnblogs.com/selimsong/p/7641799.html) 启发很大，把之前了解到的基本上都重新串到了一起，但是光看还是不够过瘾的。决定自己也写点东西算是对之前学习的总结吧。

---

### ASP.NET MVC 的生命周期

   Http请求由ASP.NET运行时接管，HttpRuntime利用HttpApplicationFactory 创建或从HttpApplication对象池中取出。
   同时 ASP.NET 会根据配置文件来初始化注册的HttpModule,HttpModule在初始化时会订阅HttpApplication中的事件来实现对Http请求的处理。
   在ASP.NET MVC5中，Global.asax文件中定义了MvcApplication类，此类继承自HttpApplication。
   Http请求由此从IIS进入到了ASP.NET MVC 中，后续进行MVC的处理

流程可以看图如下：[源地址](https://www.jianshu.com/p/848fda7f79e0)

![MVC流程图](./Doc/MVC/img/MVC流程.png)


从上图可以看出ASP.NET MVC的处理主要有以下几个流程

1. 路由处理

2. Controller 初始化

3. Action 调用

4. 视图引擎渲染

5. 响应结果返回给IIS

更详细的流程请参考 [MVC流程](https://www-asp.azureedge.net/v-2016-09-01-001/media/4773381/lifecycle-of-an-aspnet-mvc-5-application.pdf)

---

## 路由处理

1. MVC第一次启动时，将MVC程序的路由信息加入到路由表中 [路由注册](./Doc/MVC/路由注册.md)

2. Http请求到达路由模块依次触发MVC事件进行处理 [MVC事件](./Doc/MVC/MVC启动.md)

3. 



***

[MVC处理请求的执行顺序](./Doc/MVC/MVC启动.md)

## MVC路由注册
[路由注册](./Doc/MVC/路由注册.md)

## 未完待续...

