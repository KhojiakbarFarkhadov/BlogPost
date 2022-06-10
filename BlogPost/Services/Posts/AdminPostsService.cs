using BlogPost.Data;
using BlogPost.Models;
using BlogPost.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Services.Posts
{
    public class AdminPostsService : BasePostsService, IAdminPostsService
    {
        public AdminPostsService(ApplicationDbContext context) : base(context)
        {
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

        public List<Post> GetAll()
        {
            return _context.Posts
                        .Include(p => p.Author)
                        .Where(m => m.Status == "Waiting for approval").ToList();
        }
    }
}
