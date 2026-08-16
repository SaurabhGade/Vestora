namespace Vestora.DTO.Common;

public class SessionObjectDTO
{
    public long UserId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }
}