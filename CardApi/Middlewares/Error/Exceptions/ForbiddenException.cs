using System;
namespace CardApi.Middlewares.Error.Exceptions
{
    public class ForbiddenException : ResponseBaseException
    {
        private const string ErrorName = "ForbiddenException";
        private new const string Message = "Request is not allowed to resources.";

        public ForbiddenException() : base(ErrorName, Message) { }

        public ForbiddenException(string message) : base(ErrorName, message) { }
    }
}
