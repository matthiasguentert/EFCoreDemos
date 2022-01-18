using ChangeTrackingProxies.Data;
using ChangeTrackingProxies.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangeTrackingProxies.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : Controller
{
    private readonly TestDbContext _context;

    public BlogsController(TestDbContext context) => _context = context;

    [HttpGet]
    public IEnumerable<Blog> GetBlogs()
    {
        return _context.Blogs.Include(b => b.Posts);
    }

    [HttpPost]
    public async Task<ActionResult<Blog>> CreateBlog([FromBody] Blog blog)
    {
        var entity = _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();

        return Ok(entity.Entity);
    }
}