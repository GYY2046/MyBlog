using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class MyBlogDependencyResolver :IDependencyResolver
    {
        private readonly ILifetimeScope _container;
        public MyBlogDependencyResolver(ILifetimeScope container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                var instance = _container.Resolve(serviceType);
                return instance;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                var enumberableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
                var instance = _container.Resolve(enumberableServiceType);
                return (IEnumerable<object>)instance;
            } catch
            {
                return null;
            }
        }
    }
}