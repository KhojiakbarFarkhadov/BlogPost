using BlogPost.Data;
using BlogPost.Models;
using BlogPost.Services.Interfaces;

namespace BlogPost.Services.Posts
{
    public class BasePostsService : IBasePostsService
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
