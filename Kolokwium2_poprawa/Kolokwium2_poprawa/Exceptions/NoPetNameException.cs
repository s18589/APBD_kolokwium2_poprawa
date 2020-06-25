using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Exceptions
{
    public class NoPetNameException : Exception
    {
        public NoPetNameException()
        {
        }

        public NoPetNameException(string message) : base(message)
        {
        }

        public NoPetNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPetNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
