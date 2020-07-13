using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Data.Abstract;
using MyBlogApp.WebUI.Models;

namespace MyBlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }
        public IActionResult Index()
        {
            HomeBlogModel model = new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(i => i.isApproved && i.isHome).OrderByDescending(i=>i.Date).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(i => i.isApproved && i.isSlider).ToList();
            return View(model);
        }
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}