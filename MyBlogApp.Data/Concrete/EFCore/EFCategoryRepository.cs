using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Concrete.EFCore
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private BlogContext context;
        public EFCategoryRepository(BlogContext _context)
        {
            context = _context;
        }

        public void AddCategory(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category!=null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int categoryId)
        {
            return context.Categories.FirstOrDefault(x=>x.CategoryId==categoryId);

        }

        public void SaveCategory(Category entity)
        {
            if (entity.CategoryId==0)
            {
                context.Categories.Add(entity);
            }
            else
            {
                var category = GetById(entity.CategoryId);
                if (category!=null)
                {
                    category.Name = entity.Name;
                }
            }
            context.SaveChanges();
        }

        public void UpdateCategory(Category entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
