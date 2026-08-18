using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Data;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Config;

public class ConfigDAL : IConfigDAL
{
    private readonly VestoraDbContext m_objVestoraDbContext;

    public ConfigDAL(VestoraDbContext i_objVestoraDbContext)
    {
        m_objVestoraDbContext = i_objVestoraDbContext;
    }

    public async Task<List<ConfigSetting>>GetActiveMenuSettingsAsync()
    {
        return await m_objVestoraDbContext.ConfigSettings
            .AsNoTracking()
            .Where(x =>
                x.IsActive &&
                x.ConfigType == "MENU")
            .OrderBy(x => x.ConfigId)
            .ToListAsync();
    }
}