namespace Application.Domains;

public class BaseResponse
{
    /// <summary>
    /// Success
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// ErrorMessage
    /// </summary>
    public string ErrorMessage { get; set; }
}