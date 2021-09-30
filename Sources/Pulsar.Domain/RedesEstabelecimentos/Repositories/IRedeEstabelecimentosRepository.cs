using Pulsar.Common.Database;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Repositories
{
    public interface IRedeEstabelecimentosRepository : IAsyncRepository<RedeEstabelecimentos>
    {
    }
}
