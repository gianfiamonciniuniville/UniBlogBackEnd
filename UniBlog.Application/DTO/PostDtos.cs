namespace UniBlog.Application.DTO;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int BlogId { get; set; }
    public BlogShortDto Blog { get; set; } = new BlogShortDto();
    public bool Published { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ViewCount { get; set; }
    public UserShortDto? Author { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; } = new List<CommentDto>();
    public IEnumerable<LikeDto> Likes { get; set; } = new List<LikeDto>();
}

public class PostCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int BlogId { get; set; }
}

public class PostUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}
