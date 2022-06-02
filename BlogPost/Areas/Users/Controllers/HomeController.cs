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

namespace BlogPost.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/Home
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
