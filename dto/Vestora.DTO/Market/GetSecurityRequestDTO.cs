using Vestora.DTO.Common;

namespace Vestora.DTO.Market;

public class GetSecurityRequestDTO : BaseRequestDTO
{
    public long SecurityId { get; set; }
}