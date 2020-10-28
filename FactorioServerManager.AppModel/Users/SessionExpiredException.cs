using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FactorioServerManager.AppModel.Users
{
    public class SessionExpiredException : ApplicationException
    {
        public SessionExpiredException()
        {
        }

        public SessionExpiredException(string message) : base(message)
        {
        }

        public SessionExpiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SessionExpiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
