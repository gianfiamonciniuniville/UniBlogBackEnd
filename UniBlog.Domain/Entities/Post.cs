namespace UniBlog.Domain.Entities;

public sealed class Post: Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
}