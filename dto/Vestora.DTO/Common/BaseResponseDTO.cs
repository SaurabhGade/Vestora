namespace Vestora.DTO.Common;

public class BaseResponseDTO<T>
{
    public bool IsSuccess { get; set; }

    public T? Response { get; set; }

    public APIErrorDTO? Error { get; set; }
}

public class APIErrorDTO
{
    public string Code { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}