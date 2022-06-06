using BlogPost.Data;
using BlogPost.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Services.Posts
{
    public class AdminPostsService
    {
        private readonly ApplicationDbContext _context;

        public AdminPostsService(ApplicationDbContext context)
        {
            _context = context;

        }

        public Post Approve(int id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(m => m.Id == id);

            return post;
        }

        public Post Reject(int? id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(m => m.Id == id);

            return post;
        }
    }
}
