using EFCoreEvents.Data;

namespace EFCoreEvents.Model;

public class Post : IHasTimestamps 
{
    public virtual int PostId { get; set; }

    public virtual string Title { get; set; }

    public virtual string Content { get; set; }

    public virtual int BlogId { get; set; }
    
    public DateTime? Added { get; set; }
    public DateTime? Deleted { get; set; }
    public DateTime? Modified { get; set; }
}