using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IUserPostsService : IBasePostsService
    {
        Post Delete(Post post);

        Post Create(Post post);

        Post Edit(Post post);
        List<Post> GetByAuthorId(string authorId);
    }
}
