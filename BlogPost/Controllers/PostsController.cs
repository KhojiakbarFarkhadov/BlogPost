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
        private readonly PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var curUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = _postsService.GetAllApproved(curUserID);
            return View(model);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var post = _postsService.GetById(id.Value);
            return View(post);
        }
    }
}


