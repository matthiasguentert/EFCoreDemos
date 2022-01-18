using EFCoreEvents.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreEvents.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.StateChanged += UpdateTimestamps;
        ChangeTracker.Tracked += UpdateTimestamps;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
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

    private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is not IHasTimestamps entityWithTimestamps) return;
        
        switch (e.Entry.State)
        {
            case EntityState.Deleted: // fire notification
                entityWithTimestamps.Deleted = DateTime.UtcNow;
                Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                break;
            case EntityState.Modified: // fire notification
                entityWithTimestamps.Modified = DateTime.UtcNow;
                Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                break;
            case EntityState.Added: 
                entityWithTimestamps.Added = DateTime.UtcNow;
                Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                break;
            case EntityState.Detached:
                Console.WriteLine($"Entity detached : {e.Entry.Entity}");
                break;
            case EntityState.Unchanged:
                Console.WriteLine($"Entity is unchanged : {e.Entry.Entity}");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }
}