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
using BlogPost.Services;
using BlogPost.Services.Posts;

namespace BlogPost.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PostsService _postsService;
        private readonly AdminPostsService _adminPostsService;

         public AdminController(ApplicationDbContext context, PostsService postsService, AdminPostsService adminPostsService)
        {
            _context = context;
            _postsService = postsService;
            _adminPostsService = adminPostsService;
        }


        // GET: Admin/Admin
        public async Task<IActionResult> Index()
        {
            var posts = _context.Posts.Include(p => p.Author);
            return View(await posts.ToListAsync());
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var post = _postsService.GetById(id.Value);

            return View(post);
        }

        // POST: Admin/Posts/Approve/5
        //[HttpPost]
        public async Task <IActionResult> Approve(int? id)
        {
            var post = _adminPostsService.Approve(id.Value);
            
            return Ok();
        }


        // POST: Admin/Posts/Reject/5
        //[HttpPost]
        public async Task<IActionResult> Reject(int? id)
        {
            var post = _adminPostsService.Reject(id.Value);

            return Ok();
        }
    }
}
