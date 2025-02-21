namespace BookManagement.API
{
    public class EndpointResponse
    {
        public EndpointResponse(string message, bool isSuccess, object result, int statusCode)
        {
            Message = message;
            IsSuccess = isSuccess;
            Result = result;
            StatusCode = statusCode;
        }

        public EndpointResponse()
        {
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public int StatusCode { get; set; }
    }

    public static class EndpointResponseMessage
    {
        public static string SuccessMessage = "Request completed successfully";
    }
}
