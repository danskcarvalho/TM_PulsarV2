using Pulsar.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Services
{
    public interface IJobService
    {
        Task Push<T>(T cmd) where T : class, ICommand;
        Task Schedule<T>(DateTime on, T cmd) where T : class, ICommand;
    }
}
