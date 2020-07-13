using Microsoft.EntityFrameworkCore;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogApp.Data.Concrete.EFCore
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
