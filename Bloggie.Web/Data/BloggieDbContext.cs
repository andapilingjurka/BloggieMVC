using Azure;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}