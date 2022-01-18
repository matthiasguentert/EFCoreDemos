using System.ComponentModel;

namespace NotificationEntities.Model;

public class Post : INotifyPropertyChanged, INotifyPropertyChanging
{
    public int PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int BlogId { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;
}