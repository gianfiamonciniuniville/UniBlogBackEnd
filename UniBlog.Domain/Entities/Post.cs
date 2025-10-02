namespace UniBlog.Domain.Entities;

public sealed class Post: Entity
{
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }
    public bool Published { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ViewCount { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Like> Likes { get; set; }
}