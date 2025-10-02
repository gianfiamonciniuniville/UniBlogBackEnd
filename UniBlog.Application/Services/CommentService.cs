using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class CommentService(ICommentRepository commentRepository, IUserRepository userRepository) : ICommentService
{
    public async Task<CommentDto> Create(CommentCreateDto commentDto)
    {
        var comment = new Comment
        {
            Content = commentDto.Content,
            PostId = commentDto.PostId,
            UserId = commentDto.UserId
        };

        var createdComment = await commentRepository.CreateAsync(comment);
        var user = await userRepository.GetByIdAsync(createdComment.UserId);

        return new CommentDto
        {
            Id = createdComment.Id,
            Content = createdComment.Content,
            User = user != null ? new UserShortDto { Id = user.Id, UserName = user.UserName, ProfileImageUrl = user.ProfileImageUrl } : null
        };
    }

    public async Task<bool> Delete(int id)
    {
        return await commentRepository.DeleteAsync(id);
    }
}
