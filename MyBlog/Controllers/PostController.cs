using BlogBussinessLogic;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private BlogManager _manager;
        public PostController(BlogManager blog)
        {
            _manager = blog;
        }
        // GET: Post
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
    }
}