namespace UniBlog.Domain.Entities;

public sealed class Post: Entity
{
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; } // PostStatus Enum
    public int ViewCount { get; set; }
}