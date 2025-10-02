using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class LikeService(ILikeRepository likeRepository, IUserRepository userRepository) : ILikeService
{
    public async Task<LikeDto> Create(LikeCreateDto likeDto)
    {
        var existingLike = await likeRepository.GetByPostAndUserAsync(likeDto.PostId, likeDto.UserId);
        if (existingLike != null)
        {
            throw new Exception("User has already liked this post.");
        }

        var like = new Like
        {
            PostId = likeDto.PostId,
            UserId = likeDto.UserId
        };

        var createdLike = await likeRepository.CreateAsync(like);
        var user = await userRepository.GetByIdAsync(createdLike.UserId);

        return new LikeDto
        {
            Id = createdLike.Id,
            User = user != null ? new UserShortDto { Id = user.Id, UserName = user.UserName, ProfileImageUrl = user.ProfileImageUrl } : null
        };
    }

    public async Task<bool> Delete(int id)
    {
        return await likeRepository.DeleteAsync(id);
    }
}
