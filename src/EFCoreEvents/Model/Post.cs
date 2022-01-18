namespace EFCoreEvents.Model;

public class Post : IHasTimestamps 
{
    public int PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int BlogId { get; set; }
    
    public DateTime? Added { get; set; }
    
    public DateTime? Deleted { get; set; }
    
    public DateTime? Modified { get; set; }
}