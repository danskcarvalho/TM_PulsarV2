using Pulsar.Common.Database;
using Pulsar.Domain.Perfis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Perfis.Repositories
{
    public interface IPerfilRepository : IAsyncRepository<Perfil>
    {
    }
}
