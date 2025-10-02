using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUserNameAsync(string userName);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
}