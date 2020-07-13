using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Concrete.EFCore
{
    public class EFBlogRepository : IBlogRepository
    {
        private BlogContext context;

        public EFBlogRepository(BlogContext _context)
        {
            context = _context;
        }
        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = context.Blogs.FirstOrDefault(x=>x.BlogId==blogId);
            if (blog!=null)
            {
                context.Remove(blog);
                context.SaveChanges();
            }
        }

        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }

        public Blog GetById(int blogId)
        {
            return context.Blogs.FirstOrDefault(x => x.BlogId == blogId);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.BlogId==0)
            {
                entity.Date = DateTime.Now;
                context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetById(entity.BlogId);
                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Description = entity.Description;
                    blog.CategoryId = entity.CategoryId;
                    blog.Body = entity.Body;
                    if (entity.Image!=null)
                    {
                        blog.Image = entity.Image;
                    }
                    blog.isApproved = entity.isApproved;
                    blog.isHome = entity.isHome;
                    blog.isSlider = entity.isSlider;
                }
             
            }
            context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            var blog = GetById(entity.BlogId);
            if (blog!=null)
            {
                blog.Title = entity.Title;
                blog.Description = entity.Description;
                blog.CategoryId = entity.CategoryId;
                blog.Image = entity.Image;
                blog.isApproved = entity.isApproved;
                blog.isHome = entity.isHome;
            }
            context.SaveChanges();
        }
    }
}
