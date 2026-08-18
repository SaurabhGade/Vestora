using Microsoft.AspNetCore.Identity;
using Vestora.DAL.Entities;
using Vestora.DAL.Users;
using Vestora.DTO.Dashboard;
using Vestora.DTO.Users;

namespace Vestora.BO.Users;

public class UserBO : IUserBO
{
    private readonly IUserDAL m_objIUserDAL;
    private readonly IPasswordHasher<User> m_objIPasswordHasher;

    public UserBO(IUserDAL i_objIUserDAL, IPasswordHasher<User> i_objIPasswordHasher)
    {
        m_objIUserDAL = i_objIUserDAL;
        m_objIPasswordHasher = i_objIPasswordHasher;
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
            await m_objIUserDAL.EmailExistsAsync(
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
            m_objIPasswordHasher.HashPassword(
                user,
                request.Password);

        var createdUser =
            await m_objIUserDAL.CreateAsync(
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
            await m_objIUserDAL.GetByEmailAsync(
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
            m_objIPasswordHasher.VerifyHashedPassword(
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

        await m_objIUserDAL.UpdateAsync(
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
    public async Task<GetUserResponseDTO?> GetUserAsync(
    GetUserRequestDTO request)
    {
        if (request.SessionObject == null)
        {
            return null;
        }

        var user =
            await m_objIUserDAL.GetUserByIdAsync(
                request.SessionObject.UserId);

        if (user == null)
        {
            return null;
        }

        return new GetUserResponseDTO
        {
            UserId = user.UserId,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}