namespace UniBlog.Domain.Entities;

public class Blog: Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public User? User { get; set; }
    public int UserId { get; set; }
    public IEnumerable<Post> Posts { get; set; } = new List<Post>();
}