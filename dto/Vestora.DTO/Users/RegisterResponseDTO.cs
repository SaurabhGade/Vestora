namespace Vestora.DTO.Users;

public class RegisterResponseDTO
{
    public bool Success { get; set; }

    public long? UserId { get; set; }

    public string Message { get; set; } = string.Empty;
}