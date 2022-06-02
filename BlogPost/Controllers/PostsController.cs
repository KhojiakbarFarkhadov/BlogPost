using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPost.Data;
using BlogPost.Models;
using Microsoft.AspNetCore.Authorization;
using BlogPost.ViewModels;
using System.Security.Claims;

namespace BlogPost.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var curUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await _context.Posts
                            .Where(a => a.AuthorId == curUserID)
                            .ToListAsync();
            return View(model);
        }

        // GET: Posts/Details/5
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
    }
}


