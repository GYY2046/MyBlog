using Autofac;
using BlogBussinessLogic;
using MyBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public static class MyBlogContainer
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BlogManager>();
            builder.RegisterType<PostController>();
            var container = builder.Build();
            return container;
        }
    }
}