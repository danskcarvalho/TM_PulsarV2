using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Exceptions
{

    [Serializable]
    public class PulsarException : Exception
    {
        public PulsarErrorCode ErrorCode { get; }
        public object Information { get; set; }
        public PulsarException() { }
        public PulsarException(PulsarErrorCode errorCode) : base(GetMessageFromErrorCode(errorCode))
        { }
        public PulsarException(PulsarErrorCode errorCode, object information) : base(GetMessageFromErrorCode(errorCode))
        {
            this.Information = information;
        }
        public PulsarException(string message) : base(message) { }
        public PulsarException(string message, Exception inner) : base(message, inner) { }
        protected PulsarException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string GetMessageFromErrorCode(PulsarErrorCode errorCode)
        {
            var enumType = typeof(PulsarErrorCode);
            var memberInfos = enumType.GetMember(errorCode.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                  enumValueMemberInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)valueAttributes[0]).Name;
        }
    }
}
