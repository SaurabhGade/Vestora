using Vestora.DAL.Entities;

namespace Vestora.DAL.Dashboard;

public interface IDashboardDAL
{
    Task<User?> GetUserAsync(long userId);
}