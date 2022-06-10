using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IBlogPostsService
    {
        Post GetById(int id);

        List<Post> GetAllApproved();
    }
}
