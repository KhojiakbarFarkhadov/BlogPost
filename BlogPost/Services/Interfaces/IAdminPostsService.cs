using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IAdminPostsService : IBasePostsService
    {
        Post Approve(Post post);
        Post Reject(Post post);
        List<Post> GetAll();
    }
}
