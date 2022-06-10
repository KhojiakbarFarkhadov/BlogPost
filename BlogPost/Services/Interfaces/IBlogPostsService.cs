using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IBlogPostsService : IBasePostsService
    {
        List<Post> GetAllApproved();
        Post GetApprovedById(int id);
    }
}
