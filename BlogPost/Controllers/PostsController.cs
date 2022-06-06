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
using BlogPost.Services;

namespace BlogPost.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PostsService _postsService;

        public PostsController(ApplicationDbContext context, PostsService postsService)
        {
            _context = context;
            _postsService = postsService;
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

            var post = _postsService.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}


