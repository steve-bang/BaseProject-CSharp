using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBase.ExceptionHandler
{
    public enum HttpStatusEnum
    {
        OK = 200,
        Created = 201,
        BadRequest = 400,
        DataNotFound = 404,
        InternalServerError = 500,
        BadGateway = 502
    }
}
