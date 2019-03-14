using BlogModel;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository_MySQL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BlogContext :DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, BlogRepository_MySQL.Migrations.Configuration>());
            modelBuilder.Entity<Post>().HasKey(r => r.Id);
            modelBuilder.Entity<Post>().Property(r => r.Title)
                .HasMaxLength(20);
            modelBuilder.Entity<Post>().Property(r => r.Content)
                .HasMaxLength(2000);
            //.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
        }
        public DbSet<Post> Posts { get; set; }
    }
}
