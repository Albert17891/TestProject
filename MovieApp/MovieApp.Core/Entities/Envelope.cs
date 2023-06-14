namespace MovieApp.Core.Entities;

public class Envelope<T> where T : class
{
    public T Value { get; set; }
    public string Message { get; set; } 
    public bool IsSuccess { get { return Value != default; } }  
    public EnvelopeStatusCode EnvelopeStatusCode { get; set; }  
}

public enum EnvelopeStatusCode
{
    Success,
    NotFound,
    BadRequest,
    InternalServerError    
}
