using ChangeTrackingProxies.Model;
using Microsoft.EntityFrameworkCore;

namespace ChangeTrackingProxies.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Making use of notification entities
        builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);        
        
        var posts = new List<Post>
        {
            new Post { PostId = 1, BlogId = 1, Title = "Post1", Content = "Content" },
            new Post { PostId = 2, BlogId = 1, Title = "Post2", Content = "Content" },
            new Post { PostId = 3, BlogId = 1, Title = "Post3", Content = "Content" },
            new Post { PostId = 4, BlogId = 1, Title = "Post4", Content = "Content" },
        };

        var blog = new Blog
        {
            BlogId = 1,
            Url = "https://foobar.com",
        };

        builder.Entity<Blog>().HasData(blog);
        builder.Entity<Post>().HasData(posts);
    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }
}