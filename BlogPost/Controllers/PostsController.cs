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
using BlogPost.Services.Interfaces;

namespace BlogPost.Controllers
{
    public class PostsController : Controller
    {
        private readonly IBlogPostsService _blogPostsService;

        public PostsController(IBlogPostsService blogPostsService)
        {
            _blogPostsService = blogPostsService;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var model = _blogPostsService.GetAllApproved();
            
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var post = _blogPostsService.GetApprovedById(id.Value);
            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}


