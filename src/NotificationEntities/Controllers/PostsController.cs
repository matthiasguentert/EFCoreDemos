using Microsoft.AspNetCore.Mvc;
using NotificationEntities.Data;
using NotificationEntities.Model;

namespace NotificationEntities.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : Controller
{
    private readonly TestDbContext _context;

    public PostsController(TestDbContext context) => _context = context;

    [HttpGet]
    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateBlog([FromBody] Post post)
    {
        var entity = _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return Ok(entity.Entity);
    }
}