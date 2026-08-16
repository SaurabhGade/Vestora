using Vestora.DTO.Dashboard;

namespace Vestora.BO.Dashboard;

public interface IDashboardBO
{
    Task<GetUserResponseDTO?> GetUserAsync(
        GetUserRequestDTO request);
}