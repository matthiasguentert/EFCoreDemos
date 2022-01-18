namespace EFCoreEvents.Model;

public class Blog : IHasTimestamps
{
    public int BlogId { get; set; }

    public string Url { get; set; }

    public IList<Post> Posts { get; set; }
    
    public DateTime? Added { get; set; }
    
    public DateTime? Deleted { get; set; }
    
    public DateTime? Modified { get; set; }
}