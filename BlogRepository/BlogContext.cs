using BlogModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class BlogContext : DbContext
    {
        public BlogContext():
            base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Boco_PC\Documents\my_blog.mdf;Integrated Security=True;Connect Timeout=30")
        { }
        public DbSet<Post> Posts { get; set; }
    }
}
