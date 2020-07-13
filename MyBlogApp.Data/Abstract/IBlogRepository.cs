using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Abstract
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetAll();
        Blog GetById(int blogId);
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void DeleteBlog(int blogId);
        void SaveBlog(Blog entity);
    }
}
