using System.Collections.ObjectModel;

namespace ChangeTrackingProxies.Model;

public class Blog
{
    public virtual int BlogId { get; set; }

    public virtual string Url { get; set; }

    public virtual IList<Post> Posts { get; } = new ObservableCollection<Post>();
}