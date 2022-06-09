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
using BlogPost.Services.Interfaces;

namespace BlogPost.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IPostsService _postsService;
        private readonly IAdminPostsService _adminPostsService;

         public AdminController(IPostsService postsService, IAdminPostsService adminPostsService)
        {
            _postsService = postsService;
            _adminPostsService = adminPostsService;
        }


        // GET: Admin/Admin
        public async Task<IActionResult> Index()
        {
            var posts = _adminPostsService.GetForAdmin();
            return View(posts);
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var post = _postsService.GetById(id.Value);
            
            if (post == null)
            {
                return NotFound();
            }
            
            return View(post);
        }

        // POST: Admin/Posts/Approve/5
        //[HttpPost]
        public async Task <IActionResult> Approve(int? id)
        {
            var post = _postsService.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }

            post = _adminPostsService.Approve(post);
            
            return Ok();
        }


        // POST: Admin/Posts/Reject/5
        //[HttpPost]
        public async Task<IActionResult> Reject(int? id)
        {
            var post = _postsService.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }

            post = _adminPostsService.Reject(post);

            return Ok();
        }
    }
}
