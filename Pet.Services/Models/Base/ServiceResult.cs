namespace Pet.Services.Models.Base
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }

        public ErrorMeta Error { get; set; }

        public bool IsSucceeded => Data != null && Error == null;
    }

    public class ErrorMeta
    {
        public ErrorMeta(string message)
        {
            Message = message;
        }

        public ErrorMeta(string message, int code) : this(message)
        {
            Code = code;
        }

        public int Code { get; set; }
        
        public string Message { get; set; }
    }
}
