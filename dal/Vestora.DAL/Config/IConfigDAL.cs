using Vestora.DAL.Entities;

namespace Vestora.DAL.Config;

public interface IConfigDAL
{
    Task<List<ConfigSetting>> GetActiveMenuSettingsAsync();
}