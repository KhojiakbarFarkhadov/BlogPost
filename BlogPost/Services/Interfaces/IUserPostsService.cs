using BlogPost.Models;

namespace BlogPost.Services.Interfaces
{
    public interface IUserPostsService
    {
        Post GetById(int id);

        Post Delete(Post post);

        Post Create(Post post);

        Post Edit(Post post);
        List<Post> GetByAuthorId(string authorId);
    }
}
