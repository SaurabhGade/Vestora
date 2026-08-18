using Vestora.DTO.Config;

namespace Vestora.BO.Config;

public interface IConfigBO
{
    Task<List<MenuDTO>> GetMenuAsync();
}