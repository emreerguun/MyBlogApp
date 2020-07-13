using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category GetById(int categoryId);
        void AddCategory(Category entity);
        void UpdateCategory(Category entity);
        void DeleteCategory(int categoryId);
        void SaveCategory(Category entity);
    }
}
