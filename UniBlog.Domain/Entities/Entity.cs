namespace UniBlog.Domain.Entities;

public abstract class Entity
{
    public int Id { get; set; } // setter should maybe be protected? only public so unit tests are easier
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
}