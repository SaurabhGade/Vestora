using Microsoft.AspNetCore.Identity;
using Vestora.DAL.Entities;
using Vestora.DAL.Users;
using Vestora.DTO.Users;

namespace Vestora.BO.Users;

public class UserBO : IUserBO
{
    private readonly IUserDAL _userDAL;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserBO(
        IUserDAL userDAL,
        IPasswordHasher<User> passwordHasher)
    {
        _userDAL = userDAL;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResponseDTO> RegisterAsync(
        RegisterRequestDTO request,
        CancellationToken cancellationToken = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(email))
        {
            return new RegisterResponseDTO
            {
                Success = false,
                Message = "Email is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return new RegisterResponseDTO
            {
                Success = false,
                Message = "Password is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            return new RegisterResponseDTO
            {
                Success = false,
                Message = "First name is required."
            };
        }

        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            return new RegisterResponseDTO
            {
                Success = false,
                Message = "Last name is required."
            };
        }

        var emailExists =
            await _userDAL.EmailExistsAsync(
                email,
                cancellationToken);

        if (emailExists)
        {
            return new RegisterResponseDTO
            {
                Success = false,
                Message = "An account with this email already exists."
            };
        }

        var user = new User
        {
            Email = email,

            FirstName = request.FirstName.Trim(),

            MiddleName =
                string.IsNullOrWhiteSpace(request.MiddleName)
                    ? null
                    : request.MiddleName.Trim(),

            LastName = request.LastName.Trim(),

            PhoneNumber =
                string.IsNullOrWhiteSpace(request.PhoneNumber)
                    ? null
                    : request.PhoneNumber.Trim(),

            DateOfBirth = request.DateOfBirth,

            IsActive = true,

            EmailVerified = false,

            PhoneVerified = false,

            CreatedAt = DateTime.UtcNow,

            UpdatedAt = DateTime.UtcNow
        };

        user.PasswordHash =
            _passwordHasher.HashPassword(
                user,
                request.Password);

        var createdUser =
            await _userDAL.CreateAsync(
                user,
                cancellationToken);

        return new RegisterResponseDTO
        {
            Success = true,

            UserId = createdUser.UserId,

            Message = "Account created successfully."
        };
    }

    public async Task<LoginResponseDTO> LoginAsync(
        LoginRequestDTO request,
        CancellationToken cancellationToken = default)
    {
        var email =
            request.Email.Trim().ToLowerInvariant();

        var user =
            await _userDAL.GetByEmailAsync(
                email,
                cancellationToken);

        if (user == null)
        {
            return new LoginResponseDTO
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        if (!user.IsActive)
        {
            return new LoginResponseDTO
            {
                Success = false,
                Message = "Your account is inactive."
            };
        }

        var passwordResult =
            _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

        if (passwordResult ==
            PasswordVerificationResult.Failed)
        {
            return new LoginResponseDTO
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        user.LastLoginAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        await _userDAL.UpdateAsync(
            user,
            cancellationToken);

        return new LoginResponseDTO
        {
            Success = true,

            UserId = user.UserId,

            Email = user.Email,

            FirstName = user.FirstName,

            Message = "Login successful."
        };
    }
}