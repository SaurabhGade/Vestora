using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Data;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Dashboard;

public class DashboardDAL : IDashboardDAL
{
    private readonly VestoraDbContext m_objVestoraDbContext;

    public DashboardDAL(VestoraDbContext i_objVestoraDbContext)
    {
        m_objVestoraDbContext = i_objVestoraDbContext;
    }

    public async Task<User?> GetUserAsync(long userId)
    {
        return await m_objVestoraDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.UserId == userId);
    }
}