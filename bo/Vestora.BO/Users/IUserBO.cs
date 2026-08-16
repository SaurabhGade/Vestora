using Vestora.DTO.Users;

namespace Vestora.BO.Users;

public interface IUserBO
{
  Task<RegisterResponseDTO> RegisterAsync(
      RegisterRequestDTO request,
      CancellationToken cancellationToken = default);

  Task<LoginResponseDTO> LoginAsync(
      LoginRequestDTO request,
      CancellationToken cancellationToken = default);
}