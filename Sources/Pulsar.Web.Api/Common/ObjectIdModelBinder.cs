using System;
using System.Collections.Immutable;
using System.Threading;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace Pulsar.Web.Api.Common
{
    public class ObjectIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);

            bindingContext.Result = ModelBindingResult.Success(new ObjectId(result.FirstValue));

            return Task.CompletedTask;
        }
    }
}
