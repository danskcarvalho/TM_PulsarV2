using Pulsar.Common.Database;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Repositories
{
    public interface IUsuarioRepository : IAsyncRepository<Usuario>
    {
    }
}
