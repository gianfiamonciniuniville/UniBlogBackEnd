namespace UniBlog.Domain.Entities;

public sealed class User: Entity
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public string Role { get; set; } = string.Empty; // Role Enum
    public IEnumerable<Blog> Blogs { get; set; } = new List<Blog>();
    public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    public IEnumerable<Like> Likes { get; set; } = new List<Like>();
}