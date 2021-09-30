using Pulsar.Common.Database;
using Pulsar.Domain.FilasAtendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimentos.Repositories
{
    public interface IFilaAtendimentosRepository : IAsyncRepository<FilaAtendimentos>
    {
    }
}
