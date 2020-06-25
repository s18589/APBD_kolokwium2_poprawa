﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Exceptions
{
    public class NoDateRegisteredException : Exception
    {
        public NoDateRegisteredException()
        {
        }

        public NoDateRegisteredException(string message) : base(message)
        {
        }

        public NoDateRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoDateRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
