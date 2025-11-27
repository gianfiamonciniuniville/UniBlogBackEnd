namespace UniBlog.Domain.Entities;

public class Comment : Entity
{
    public int PostId { get; set; }
    public Post? Post { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string Content { get; set; } = string.Empty;
}