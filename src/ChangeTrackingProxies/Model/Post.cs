namespace ChangeTrackingProxies.Model;

public class Post 
{
    public virtual int PostId { get; set; }

    public virtual string Title { get; set; }

    public virtual string Content { get; set; }

    public virtual int BlogId { get; set; }
}