using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog.Models
{
    public class MyBlogControllerFactory :DefaultControllerFactory
    {
        private readonly ILifetimeScope _container;
        public MyBlogControllerFactory(ILifetimeScope container)
        {
            _container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                return (IController)_container.Resolve(controllerType);
            }
            catch { }
            return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}