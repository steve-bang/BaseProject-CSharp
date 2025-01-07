using System.Net;

namespace SBase.Response
{
    /// <summary>
    /// This class is used to return the error detail for client.
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// The error detail.
        /// </summary>
        public ErrorJson Error { get; set; }

        public static ErrorResult Build(ErrorJson error)
        {
            return new ErrorResult { Error = error };
        }
    }

    public class ErrorJson
    {
        /// <summary>
        /// The HttpCode of the error.
        /// By default the error http code is 500.
        /// </summary>
        public int HttpCode { get; set; } = (int)HttpStatusCode.InternalServerError;

        /// <summary>
        /// The error code of the error.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// The message of the error.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The path of the error.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// The description of the error.
        /// </summary>
        public string? Description { get; set; }

        public ErrorJson()
        {

        }

        public ErrorJson(int httpCode, string code, string message, string description)
        {
            HttpCode = httpCode;
            Code = code;
            Message = message;
            Description = description;
        }

        public ErrorJson(HttpStatusCode httpCode, string code, string message, string description)
        {
            HttpCode = (int)httpCode;
            Code = code;
            Message = message;
            Description = description;
        }

        public ErrorJson(HttpStatusCode httpCode, string code, string message)
        {
            HttpCode = (int)httpCode;
            Code = code;
            Message = message;
        }

    }
}
