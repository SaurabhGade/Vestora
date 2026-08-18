using System.Text.Json;

using Vestora.DAL.Config;
using Vestora.DTO.Config;

namespace Vestora.BO.Config;

public class ConfigBO : IConfigBO
{
  private readonly IConfigDAL m_objIConfigDAL;

  public ConfigBO(IConfigDAL i_objIConfigDAL)
  {
    m_objIConfigDAL = i_objIConfigDAL;
  }

  public async Task<List<MenuDTO>> GetMenuAsync()
  {
    var settings = await m_objIConfigDAL.GetActiveMenuSettingsAsync();

    var result = new List<MenuDTO>();

    foreach (var setting in settings)
    {
      if (string.IsNullOrWhiteSpace(
              setting.ConfigValue))
      {
        continue;
      }

      try
      {
        var menu =
            JsonSerializer.Deserialize<MenuConfig>(
                setting.ConfigValue);

        if (menu == null)
        {
          continue;
        }

        result.Add(new MenuDTO
        {
          MenuId = setting.ConfigId,
          Key = setting.ConfigKey,
          Name = menu.name,
          Route = menu.route,
          Icon = menu.icon,
          DisplayOrder = menu.displayOrder
        });
      }
      catch (JsonException)
      {
        // We'll add proper structured logging here
        // when we implement BO/DAL logging.
      }
    }

    return result
        .OrderBy(x => x.DisplayOrder)
        .ToList();
  }

  private sealed class MenuConfig
  {
    public string name { get; set; } = string.Empty;

    public string route { get; set; } = string.Empty;

    public string icon { get; set; } = string.Empty;

    public int displayOrder { get; set; }
  }
}