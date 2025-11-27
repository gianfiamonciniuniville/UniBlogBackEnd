namespace UniBlog.Application.DTO;

public class BlogDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UserShortDto? User { get; set; }
    public IEnumerable<PostDto> Posts { get; set; } = new List<PostDto>();
}

public class BlogCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}

public class BlogUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class BlogShortDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
