using System.Collections.ObjectModel;
using EFCoreEvents.Data;

namespace EFCoreEvents.Model;

public class Blog : IHasTimestamps
{
    public virtual int BlogId { get; set; }

    public virtual string Url { get; set; }

    public virtual IList<Post> Posts { get; } = new ObservableCollection<Post>();
    
    public DateTime? Added { get; set; }
    public DateTime? Deleted { get; set; }
    public DateTime? Modified { get; set; }
}