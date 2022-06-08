using BlogPost.Data;
using BlogPost.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Services
{
    public class PostsService
    {
        private readonly ApplicationDbContext _context;

        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post GetById(int id)
        {

            var post = _context.Posts
              .FirstOrDefault(m => m.Id == id);

            return post;
        }
        public Post Delete(Post post)
        {
             _context.Posts.Remove(post);
             _context.SaveChanges();

            return post; 
        }

        public Post Create(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();

            return post;
        }

        public Post Edit(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();

            return post;
        }

        public List<Post> GetAllApproved()
        {
           return _context.Posts.Where(m => m.Status == "Approved").ToList();
           
        }

        public List<Post> GetByAuthorId(string authorId)
        {
            return _context.Posts.Where(m => m.AuthorId == authorId).ToList();
        }
    }
}
