using BlogPost.Data;
using BlogPost.Models;
using BlogPost.Services.Interfaces;

namespace BlogPost.Services.Posts
{
    public class BlogPostsService : BasePostsService, IBlogPostsService
    {
        public BlogPostsService(ApplicationDbContext context) : base(context)
        {
        }

        public List<Post> GetAllApproved()
        {
            return _context.Posts.Where(m => m.Status == "Approved").ToList();
        }

        public Post GetApprovedById(int id)
        {
            var post = _context.Posts
            .Where(m => m.Status == "Approved")
            .FirstOrDefault(m => m.Id == id);

            return post;
        }
    }
}
