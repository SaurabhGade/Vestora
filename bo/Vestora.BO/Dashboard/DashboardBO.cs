using Vestora.DAL.Dashboard;
using Vestora.DTO.Dashboard;

namespace Vestora.BO.Dashboard;

public class DashboardBO : IDashboardBO
{
  private readonly IDashboardDAL m_objIDashboardDAL;

  public DashboardBO(IDashboardDAL i_objIDashboardDAL)
  {
    m_objIDashboardDAL = i_objIDashboardDAL;
  }

  public async Task<GetUserResponseDTO?> GetUserAsync(GetUserRequestDTO i_objGetUserRequestDTO)
  {
    if (i_objGetUserRequestDTO.SessionObject == null)
    {
      return null;
    }

    var user =
        await m_objIDashboardDAL.GetUserAsync(
            i_objGetUserRequestDTO.SessionObject.UserId);

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