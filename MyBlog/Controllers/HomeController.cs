using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private BlogBussinessLogic.BlogManager _manager = new BlogBussinessLogic.BlogManager();
        [Authorize]
        public ActionResult Index()
        {
            var posts = _manager.GetAllPosts().Select(p => new PostViewModel
            {
                Author = p.Author,
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreateDate = p.CreateDate,
                ModifyDate = p.ModifyDate
            }).ToList();
            var postsList = new PostListViewModel()
            {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };
            return View(postsList);
        }
        public ActionResult Get(int id)
        {
            var post = _manager.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = new PostViewModel {
                Id = post.Id,
                Author =post.Author,
                Title =post.Title,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ModifyDate = post.ModifyDate
            };
            return View(postViewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}