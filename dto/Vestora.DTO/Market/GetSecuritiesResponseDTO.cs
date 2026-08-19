public class GetSecuritiesResponseDTO
{
  public List<SecurityDTO> Items { get; set; } = [];

  public int TotalCount { get; set; }

  public int Page { get; set; }

  public int PageSize { get; set; }

  public int TotalPages { get; set; }
}
public class SecurityDTO
{
  public long SecurityId { get; set; }
  public string Symbol { get; set; } = string.Empty;
  public string CompanyName { get; set; } = string.Empty;
  public string Exchange { get; set; } = string.Empty;
  public string ISIN { get; set; } = string.Empty;
  public string SecurityType { get; set; } = string.Empty;
  public string Sector {get; set;} = string.Empty;
  public string Industry {get; set;} = string.Empty;
  public bool IsActive {get; set;} 

}