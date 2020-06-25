using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Exceptions
{
    public class NoBreedNameException : Exception
    {
        public NoBreedNameException()
        {
        }

        public NoBreedNameException(string message) : base(message)
        {
        }

        public NoBreedNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoBreedNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
