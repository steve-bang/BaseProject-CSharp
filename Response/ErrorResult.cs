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
        /// The message of the error.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The Timestamp of the error.
        /// </summary>
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString();

        /// <summary>
        /// The path of the error.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The description of the error.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
