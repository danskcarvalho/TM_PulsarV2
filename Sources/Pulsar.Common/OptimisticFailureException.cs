﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common
{

    [Serializable]
    public class OptimisticException : Exception
    {
        public OptimisticException() { }
        public OptimisticException(string message) : base(message) { }
        public OptimisticException(string message, Exception inner) : base(message, inner) { }
        protected OptimisticException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
