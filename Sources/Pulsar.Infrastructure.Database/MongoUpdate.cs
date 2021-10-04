using MongoDB.Driver;
using Pulsar.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoUpdate<T> : Update<T>
    {
        private UpdateDefinitionBuilder<T> _Builder = null;
        private UpdateDefinition<T> _UpdateDefinition = null;

        public MongoUpdate(UpdateDefinitionBuilder<T> builder)
        {
            _Builder = builder;
        }

        public UpdateDefinition<T> Definition => _UpdateDefinition;

        public override Update<T> Set<TField>(System.Linq.Expressions.Expression<Func<T, TField>> field, TField fieldValue)
        {
            if (_UpdateDefinition == null)
                _UpdateDefinition = _Builder.Set(field, fieldValue);
            else
                _UpdateDefinition = _UpdateDefinition.Set(field, fieldValue);
            return this;
        }
    }
}
