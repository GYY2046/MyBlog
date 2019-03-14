using BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogRepository_MySQL;
namespace BlogBussinessLogic
{
    public class BlogManager
    {
        private BlogRepository_MySQL.BlogRepository repository = new BlogRepository_MySQL.BlogRepository();

        public List<Post> GetAllPosts()
        {
            return repository.GetAll();
        }
        public Post GetPostById(int id)
        {
            return repository.GetById(id);
        }
        public void UpdatePost(Post post)
        {
            repository.Update(post);
        }
        public void Insert(Post post)
        {
            repository.Insert(post);
        }
        public void Delete(Post post)
        {
            repository.Delete(post);
        }
    }
}
