using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPost.Data;
using BlogPost.Models;
using BlogPost.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BlogPost.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Users/User
        public async Task<IActionResult> Index()
        {
            var curUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await _context.Posts
                            .Where(a => a.AuthorId == curUserID)
                            .ToListAsync();
            return View(model);
        }

        // GET: Users/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Users/User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(/*[Bind("Id,Title,Text,DateCreated,AuthorId,Status,PostType")]*/ PostCreateVM postVM)
        {
            if (ModelState.IsValid)
            {
                var curUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var post = new Post();
                post.Title = postVM.Title;
                post.Text = postVM.Text;
                post.DateCreated = DateTime.Now;
                post.AuthorId = curUserID;
                if(postVM.PostType == "Draft")
                {
                    post.Status = "Draft";
                }
                else
                {
                    post.Status = "Waiting for approval";
                }
              
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(postVM);
        }

        // GET: Users/User/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Users/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id,/* [Bind("Id,Title,Text,DateCreated,AuthorId,Status,PostType")]*/ Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var curUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                post.AuthorId = curUserID;
                post.DateCreated = DateTime.Now;
                if (post.Status == "Draft")
                {
                    post.Status = "Draft";
                }
                else
                {
                    post.Status = "Waiting for approval";
                }

                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id) )
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Users/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Users/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
