namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string msg = null, string details = null) : base(statusCode, msg)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}