using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IBasePostsService
    {
        Post GetById(int id);
    }
}
