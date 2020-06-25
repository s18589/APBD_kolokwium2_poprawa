using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Exceptions
{
    public class NoPetSexException : Exception
    {
        public NoPetSexException()
        {
        }

        public NoPetSexException(string message) : base(message)
        {
        }

        public NoPetSexException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPetSexException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
