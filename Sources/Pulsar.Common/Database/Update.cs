using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public abstract class Update<T>
    {
        public abstract Update<T> Set<TField>(Expression<Func<T, TField>> field, TField fieldValue);
    }
}
