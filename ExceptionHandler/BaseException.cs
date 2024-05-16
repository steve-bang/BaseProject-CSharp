using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBase.ExceptionHandler
{
    /// <summary>
    /// This is the base exception class for the system.
    /// </summary>
    public class BaseException : Exception
    {
        public int HttpStatus { get; set; } = (int) HttpStatusEnum.InternalServerError;

        /// <inheritdoc/>
        public BaseException(string message) : base(message) { }

        public BaseException(HttpStatusEnum statusEnum ,string message) : base(message) 
        {
            HttpStatus = (int) statusEnum;
        }

        /// <inheritdoc/>
        public BaseException(string message, Exception innerException) : base(message, innerException) { }

        /// <inheritdoc/>
        public BaseException(HttpStatusEnum statusEnum, string message, Exception innerException) : base(message, innerException) 
        {
            HttpStatus = (int)statusEnum;
        }

    }
}
