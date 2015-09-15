using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication11.Models;
using WebApplication11.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepo _repo;

        public HomeController(IBlogRepo repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var post = _repo.GetBlogPost();

            return View(post);
        }
    }
}
