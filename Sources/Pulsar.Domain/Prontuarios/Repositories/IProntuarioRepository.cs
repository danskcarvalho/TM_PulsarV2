using Pulsar.Common.Database;
using Pulsar.Domain.Prontuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Repositories
{
    public interface IProntuarioRepository : IAsyncRepository<FragmentoProntuario>
    {
    }
}
