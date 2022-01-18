using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NotificationEntities.Model;

public class Blog : INotifyPropertyChanged, INotifyPropertyChanging
{
    public int BlogId { get; set; }

    private string _url;

    public string Url
    {
        get => _url;
        set
        {   
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Url)));
            _url = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
        }
    }

    public IList<Post> Posts { get; } = new ObservableCollection<Post>();
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;
}