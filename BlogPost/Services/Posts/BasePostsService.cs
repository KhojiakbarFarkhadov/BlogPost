using BlogPost.Data;
using BlogPost.Models;

namespace BlogPost.Services.Posts
{
    public class BasePostsService
    {
        protected readonly ApplicationDbContext _context;

        public BasePostsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Post GetById(int id)
        {
            var post = _context.Posts
              .FirstOrDefault(m => m.Id == id);

            return post;
        }
    }
}
