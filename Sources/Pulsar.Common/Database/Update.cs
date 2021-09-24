using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public static class Update
    {
        public static PushUpdate Push(object obj) => new PushUpdate(obj);
        public static IncUpdate Inc(object obj) => new IncUpdate(obj);
    }

    public record PushUpdate(object Object);
    public record IncUpdate(object Amount);
}
