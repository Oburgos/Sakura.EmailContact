using System;
using System.Text.Json.Serialization;

namespace Sakura.EmailContact.Features.Common
{
    public class EntityResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public object ErrorData { get; set; }

        public static EntityResponse CreateOk(string message = "", string codeMessage = "")
        {
            return new EntityResponse()
            {
                Message = message,
                MessageCode = codeMessage,
                Ok = true
            };
        }

        public static EntityResponse CreateError(string message, string codeMessage, object errorData = null)
        {
            return new EntityResponse()
            {
                Message = message,
                MessageCode = codeMessage,
                Ok = false,
                ErrorData = errorData
            };
        }

        public static EntityResponse Create(string message, string codeMessage, bool ok = false)
        {
            return new EntityResponse()
            {
                Message = message,
                MessageCode = codeMessage,
                Ok = ok
            };
        }

        public EntityResponse<T> As<T>(T data = default(T))
        {
            return new EntityResponse<T>
            {
                Message = Message,
                Data = data,
                Ok = Ok,
                MessageCode = MessageCode
            };
        }
    }

    public class EntityResponse<T> : EntityResponse
    {
        public T Data { get; set; }
    }
}
