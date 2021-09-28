using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common
{

    [Serializable]
    public class OptimisticFailureException : Exception
    {
        public OptimisticFailureException() { }
        public OptimisticFailureException(string message) : base(message) { }
        public OptimisticFailureException(string message, Exception inner) : base(message, inner) { }
        protected OptimisticFailureException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
