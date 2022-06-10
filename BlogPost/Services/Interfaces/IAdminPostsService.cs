using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IAdminPostsService
    {
        Post Approve(Post post);
        Post Reject(Post post);
        List<Post> GetAll();
        Post GetById(int id);
    }
}
