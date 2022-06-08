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

        public Post Approve(Post post)
        {
            _context.Posts
                .Include(p => p.Author);
                 post.Status = "Approved";
                _context.SaveChanges();
           
            return post;
        }

        public Post Reject(Post post)
        {
            _context.Posts
                .Include(p => p.Author);
                 post.Status = "Rejected";
                 _context.SaveChanges();

            return post;
        }

        public List<Post> GetForAdmin()
        {
            return _context.Posts
                        .Include(p => p.Author)
                        .Where(m => m.Status == "Waiting for approval").ToList();
        }
    }
}
