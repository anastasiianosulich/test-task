namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string msg = null) 
        {
            StatusCode = statusCode;
            Message = msg ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Unauthorized",
                404 => "Not found",
                500 => "Server error",
                _ => null
            };
        }
    }
}