
using BlogPost.Data;
using BlogPost.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.Controllers
{
    public class JustController : Controller
    {
        ApplicationDbContext _context;
        public JustController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET : /Post
        public IActionResult Index()
        {
            return View(Repository.AllPost);
        }

        public IActionResult Create()
        {
            return View();
        }
        // Post
        [HttpPost]
        public  IActionResult Create(Post post)
        {
            Repository.Create(post);
            return View("Thanks", post);
        }
        // Put
        public IActionResult Update(string etitle)
        {
            Post post =  Repository.AllPost.Where(e => e.Title == etitle).FirstOrDefault();
            return View(post);
        }
       
        [HttpPost]
        public IActionResult Update(Post post, string etitle, string etext, DateTime eDate)
        {
            Repository.AllPost.Where(e => e.Title == etitle).FirstOrDefault().Title = post.Title;
            return RedirectToAction("Index");
        }

        //Delete 
        [HttpPost]
        public IActionResult Delete(string emptitle)
        {
            Post post = Repository.AllPost.Where(e => e.Title == emptitle).FirstOrDefault();
            Repository.Delete(post);
            return RedirectToAction("Index");
        }
    }
}
