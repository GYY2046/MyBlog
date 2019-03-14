using BlogBussinessLogic;
using BlogModel;
using MyBlog.Areas.Admin.Models;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.Admin.Controllers
{
    public class PostManagementController : Controller
    {
        private BlogManager _manager = new BlogManager();
        // GET: Admin/PostManagement
        public ActionResult Index()
        {
            var posts = _manager.GetAllPosts().Select(post => new PostMaintainViewModel {
                Id = post.Id,
                Content = post.Content,
                Title = post.Title
            }).ToList();
            var postList = new PostMaitainListViewModel {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };
            return View(postList);
        }

        public ActionResult Update(int id)
        {
            var post = _manager.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = new PostMaintainViewModel
            {
                Id = post.Id,
                Content = post.Content,
                Title = post.Title
            };
            return View(postViewModel);
        }
        [HttpPost]
        public ActionResult Update(PostMaintainViewModel postModel)
        {
            var post = _manager.GetPostById(postModel.Id);
            post.Content = postModel.Content;
            post.Title = postModel.Title;
            post.ModifyDate = DateTime.Now;
            _manager.UpdatePost(post);
            return RedirectToAction("Index");
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(PostViewModel model)
        {
            model.Id = 11;
            model.CreateDate = DateTime.Now;
            model.ModifyDate = DateTime.Now;
            var post = new Post{
               Id = model.Id,
               Title =model.Title,
               Author = model.Author,
               Content = model.Content,
               CreateDate = model.CreateDate,
               ModifyDate = model.ModifyDate
            };
            _manager.Insert(post);
            return RedirectToAction("Index");
        }
    }
}