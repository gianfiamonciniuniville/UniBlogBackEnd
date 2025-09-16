namespace UniBlog.Domain.Entities;

public class Blog: Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}