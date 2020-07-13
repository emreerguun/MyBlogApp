using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;

namespace MyBlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository _repo)
        {
            repository = _repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(repository.GetAll());
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Category entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.AddCategory(entity);
        //        return RedirectToAction("List");
        //    }
        //    return View(entity);
        //}



        public IActionResult AddOrUpdate(int? id)
        {
            if (id==null)
            {
                return View(new Category());
            }
            else
            {
                return View(repository.GetById((int)id));
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Category entity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(entity);
                TempData["message"] = $"{entity.Name} kayıt edildi.";
                return RedirectToAction("List");
            }
            return View(entity);
        }

        public IActionResult Delete(int id)
        {
                repository.DeleteCategory(id);
                return RedirectToAction("List");
        }
    }
}