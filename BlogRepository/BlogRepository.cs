using BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class BlogRepository
    {
        public List<Post> GetAll()
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.ToList();
            }
            //throw new NotImplementedException();
        }
        public Post GetById (int id)
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.Find(id);
            }
            //throw new NotImplementedException();
        }
    }
}
