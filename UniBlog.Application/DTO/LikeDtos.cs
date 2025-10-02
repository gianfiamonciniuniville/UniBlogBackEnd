namespace UniBlog.Application.DTO;

public class LikeDto
{
    public int Id { get; set; }
    public UserShortDto? User { get; set; }
}

public class LikeCreateDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
}
