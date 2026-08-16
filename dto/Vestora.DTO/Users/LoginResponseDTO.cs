namespace Vestora.DTO.Users;

public class LoginResponseDTO
{
    public bool Success { get; set; }

    public long? UserId { get; set; }

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}