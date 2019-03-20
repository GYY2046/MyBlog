using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class BlogIdentityDbContext :IdentityDbContext<IdentityUser>
    {
        public BlogIdentityDbContext()
            : base("BlogContext",false)
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogIdentityDbContext, Migrations.Configuration>());
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => r.RoleId).HasKey(r => r.UserId);
            modelBuilder.Entity<IdentityUserLogin>().HasKey(r => r.UserId);
            //base.OnModelCreating(modelBuilder);
        }
    }
}