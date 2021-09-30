using Pulsar.Common.Database;
using Pulsar.Domain.Notificacoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Notificacoes.Repositories
{
    public interface INotificacaoRepository : IAsyncRepository<Notificacao>
    {
    }
}
