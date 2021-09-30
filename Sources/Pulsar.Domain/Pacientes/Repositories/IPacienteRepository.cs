using Pulsar.Common.Database;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Repositories
{
    public interface IPacienteRepository : IAsyncRepository<Paciente>
    {
    }
}
