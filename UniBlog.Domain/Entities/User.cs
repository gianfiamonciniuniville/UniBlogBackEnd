namespace UniBlog.Domain.Entities;

public sealed class User: Entity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public string Role { get; set; } // Role Enum
    public IEnumerable<Blog> Blogs { get; set; }
}