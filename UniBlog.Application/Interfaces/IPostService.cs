using UniBlog.Domain.Entities;

namespace UniBlog.Application.Interfaces;

public interface IPostService
{
    public IEnumerable<Post> ListAll();
}