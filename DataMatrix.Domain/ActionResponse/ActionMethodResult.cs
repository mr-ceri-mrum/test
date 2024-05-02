namespace DataMatrix.Domain.ActionResponse;

public class ActionMethodResult
{
    public ActionMethodResult(bool isSuccess, int statusCode)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }
    
    public ActionMethodResult(int statusCode, object data)
    {
        IsSuccess = true;
        StatusCode = statusCode;
        Data = data;
    }
    
    public bool IsSuccess { get; set; }
    public int? StatusCode { get; set; }
    
    public string? Title { get; set; }
    
    public object? Data { get; set; }
}