using BlogModel;
using BlogRepository.MySQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository_MySQL
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
        public Post GetById(int id)
        {
            using (var dbcontext = new BlogContext())
            {
                return dbcontext.Posts.Find(id);
            }
            //throw new NotImplementedException();
        }
        public void Update(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Entry(post).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
        }

        public void Insert(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Posts.Add(post);                
                dbcontext.SaveChanges();
            }
        }
        public void Delete(Post post)
        {
            using (var dbcontext = new BlogContext())
            {
                dbcontext.Posts.Remove(post);
                dbcontext.SaveChanges();
            }
        }
    }
}
