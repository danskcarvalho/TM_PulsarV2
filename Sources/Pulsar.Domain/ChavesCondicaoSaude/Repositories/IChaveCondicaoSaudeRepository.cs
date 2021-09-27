using Pulsar.Common.Database;
using Pulsar.Domain.ChavesCondicaoSaude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.ChavesCondicaoSaude.Repositories
{
    public interface IChaveCondicaoSaudeRepository : IAsyncRepository<ChaveCondicaoSaude>
    {
    }
}
