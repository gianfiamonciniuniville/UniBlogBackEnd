using UniBlog.Domain.Entities;

namespace UniBlog.Application.DTO;

public class UserDto(User user)
{
    public int Id { get; set; } = user.Id;
    public string UserName { get; set; } = user.UserName;
    public string Email { get; set; } = user.Email;
    public string? ProfileImageUrl { get; set; } = user.ProfileImageUrl;
    public string? Bio { get; set; } = user.Bio;
    public string Role { get; set; } = user.Role;
}

public class UserShortDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string? ProfileImageUrl { get; set; }
}

public class RegisterUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UpdateUserProfileDto
{
    public string? Bio { get; set; }
    public string? ProfileImageUrl { get; set; }
}

public class ChangeUserPasswordDto
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}

public class AuthResponseDto(string token, UserDto user)
{
    public string Token { get; set; } = token;
    public UserDto User { get; set; } = user;
}