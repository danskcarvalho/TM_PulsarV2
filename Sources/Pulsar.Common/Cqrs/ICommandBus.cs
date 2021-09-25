using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Cqrs
{
    public interface ICommandBus
    {
        Task Send<T>(T cmd, CancellationToken? ct = null) where T : class, ICommand;
    }
}
