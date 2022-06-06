using BlogPost.Data;
using BlogPost.Models;
using BlogPost.ViewModels;
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

        public Post Approve(int id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(m => m.Id == id);
          
            return post;
        }

        public Post Reject(int? id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(m => m.Id == id);

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
    }
}
