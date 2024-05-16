namespace SBase.Response
{
    /// <summary>
    /// This provides interfaces for API results.
    /// </summary>
    public interface IApiResult
    {
        /// <summary>
        /// This is the flag to indicate whether the API call is successful or not.
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// This is the HTTP status code. This is used to determine the status code to be returned to the client.
        /// </summary>
        int StatusCode { get; }

        /// <summary>
        /// This is the message to be displayed to the user.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// This is the data to be returned to the client.
        /// </summary>
        object Data { get; }
    }

    /// <summary>
    /// This provides interfaces for API results with data.
    /// </summary>
    public class ApiResult : IApiResult
    {
        /// <inheritdoc/>
        public bool Success { get; set; }

        /// <inheritdoc/>
        public int StatusCode { get; set; }

        /// <inheritdoc/>
        public string Message { get; set; } = "The request was success.";


        /// <inheritdoc/>
        public object? Data { get; set; }

        public ApiResult() { }

        public ApiResult(object? data)
        {
            Data = data;
            Success = true;
            StatusCode = 200;
        }

        public ApiResult(int statusCode, string message, object data)
        {
            Success = true;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ApiResult(bool success, int statusCode, string message, object data)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

    }
}
