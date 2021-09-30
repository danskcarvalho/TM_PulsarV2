using Pulsar.Common.Database;
using Pulsar.Domain.Importacoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Importacoes.Repositories
{
    public interface IImportacaoRepository : IAsyncRepository<Importacao>
    {
    }
}
