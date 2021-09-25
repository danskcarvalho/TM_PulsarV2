﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Cqrs
{
    public interface IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        Task<TResponse> Handle(TRequest req, CancellationToken ct);
    }
}