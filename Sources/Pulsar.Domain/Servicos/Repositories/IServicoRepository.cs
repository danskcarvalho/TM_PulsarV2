using Pulsar.Common.Database;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Servicos.Repositories
{
    public interface IServicoRepository : IAsyncRepository<Servico>
    {
    }
}
