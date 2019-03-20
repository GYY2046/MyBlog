using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model,string returnUrl)
        {
            
            if (ModelState.IsValid)
            {                
                var userManager = new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(new BlogIdentityDbContext()));
                var sigInManager = new SignInManager<IdentityUser, string>(userManager, this.HttpContext.GetOwinContext().Authentication);
                var result = await sigInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);                
                return RedirectToAction("Index", "Home");
            }
            else
                return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName };
                var userManager = new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(new BlogIdentityDbContext()));
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}