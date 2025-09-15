using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class PostSerivce(IPostRepository postRepository): IPostService
{
    public IEnumerable<Post> ListAll()
    {
        return postRepository.ListAllPosts();
    }
}