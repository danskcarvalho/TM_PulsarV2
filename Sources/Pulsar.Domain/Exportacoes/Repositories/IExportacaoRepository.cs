using Pulsar.Common.Database;
using Pulsar.Domain.Exportacoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Exportacoes.Repositories
{
    public interface IExportacaoRepository : IAsyncRepository<Exportacao>
    {
    }
}
