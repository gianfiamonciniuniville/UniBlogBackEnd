namespace UniBlog.Application.DTO;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public UserShortDto? User { get; set; }
}

public class CommentCreateDto
{
    public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
    public int UserId { get; set; }
}
