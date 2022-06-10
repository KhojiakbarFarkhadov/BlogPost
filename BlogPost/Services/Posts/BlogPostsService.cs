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

        //public Post GetById(int id)
        //{
        //    var post = _context.Posts
        //      .FirstOrDefault(m => m.Id == id);

        //    return post;
        //}
        public List<Post> GetAllApproved()
        {
            return _context.Posts.Where(m => m.Status == "Approved").ToList();
        }
    }
}
