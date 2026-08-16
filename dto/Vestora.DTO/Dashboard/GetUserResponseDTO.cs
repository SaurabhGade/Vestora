namespace Vestora.DTO.Dashboard;

public class GetUserResponseDTO
{
    public long UserId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}