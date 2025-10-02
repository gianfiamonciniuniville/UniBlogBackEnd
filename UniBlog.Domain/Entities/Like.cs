namespace UniBlog.Domain.Entities;

public class Like: Entity
{
    public int PostId { get; set; }
    public Post? Post { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}