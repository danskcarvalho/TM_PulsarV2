using Pulsar.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Cqrs
{
    public class MemoryContainerBus : IRequestBus, ICommandBus, ISlowCommandBus
    {
        private Dictionary<(Type, Type), object> _RequestHandlers = new Dictionary<(Type, Type), object>();
        private Dictionary<Type, object> _CommandHandlers = new Dictionary<Type, object>();
        Task<TResponse> IRequestBus.Request<T, TResponse>(T request, CancellationToken? ct)
        {
            if (!_RequestHandlers.ContainsKey((typeof(T), typeof(TResponse))))
                throw new InvalidOperationException($"no request handler found for request {typeof(T).Name} and response {typeof(TResponse).Name}");

            var handler = _RequestHandlers[(typeof(T), typeof(TResponse))] as IAsyncRequestHandler<T, TResponse>;
            return handler.Handle(request, ct ?? CancellationToken.None);
        }
        Task ICommandBus.Send<T>(T cmd, CancellationToken? ct)
        {
            if (!_CommandHandlers.ContainsKey(typeof(T)))
                throw new InvalidOperationException($"no command handler found for command {typeof(T).Name}");

            var handler = _CommandHandlers[typeof(T)] as IAsyncCommandHandler<T>;
            return handler.Handle(cmd, ct ?? CancellationToken.None);
        }

        Task ISlowCommandBus.Send(ICommand cmd, CancellationToken? ct)
        {
            cmd = cmd ?? throw new ArgumentNullException(nameof(cmd));
            var cmdType = cmd.GetType();
            if (!_CommandHandlers.ContainsKey(cmdType))
                throw new InvalidOperationException($"no command handler found for command {cmdType.Name}");

            var handler = _CommandHandlers[cmdType];
            var handlerInterfaceType = typeof(IAsyncCommandHandler<>).MakeGenericType(cmdType);
            var map = handler.GetType().GetInterfaceMap(handlerInterfaceType);
            var method = map.TargetMethods[0];
            try
            {
                var r = method.Invoke(handler, new object[] { cmd, ct });
                return (Task)r;
            }
            catch(TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        public void RegisterRequestHandlers<T>(T handler) where T : class
        {
            var interfaces = typeof(T).GetInterfaces();
            interfaces = interfaces.Where(i => IsSuitableRequestHandlerInterface(i)).ToArray();
            var allHandlers = interfaces.Select(i => ExtractRequestAndResponse(i)).ToList();
            foreach (var item in allHandlers)
            {
                RegisterRequestHandlerFor(item.Request, item.Response, handler);
            }
        }

        public void RegisterCommandHandlers<T>(T handler) where T : class
        {
            var interfaces = typeof(T).GetInterfaces();
            interfaces = interfaces.Where(i => IsSuitableCommandHandlerInterface(i)).ToArray();
            var allHandlers = interfaces.Select(i => ExtractCommand(i)).ToList();
            foreach (var item in allHandlers)
            {
                RegisterCommandHandlerFor(item, handler);
            }
        }

        private (Type Request, Type Response) ExtractRequestAndResponse(Type i)
        {
            var args = i.GetGenericArguments();
            return (args[0], args[1]);
        }

        private bool IsSuitableRequestHandlerInterface(Type i)
        {
            if (!i.IsGenericType)
                return false;

            var t = i.GetGenericTypeDefinition();
            if (t != typeof(IAsyncRequestHandler<,>))
                return false;

            return true;
        }

        private Type ExtractCommand(Type i)
        {
            var args = i.GetGenericArguments();
            return args[0];
        }

        private bool IsSuitableCommandHandlerInterface(Type i)
        {
            if (!i.IsGenericType)
                return false;

            var t = i.GetGenericTypeDefinition();
            if (t != typeof(IAsyncCommandHandler<>))
                return false;

            return true;
        }

        private void RegisterRequestHandlerFor(Type requestType, Type responseType, object handler)
        {
            lock (_RequestHandlers)
            {
                _RequestHandlers[(requestType, responseType)] = handler;
            }
        }

        private void RegisterCommandHandlerFor(Type cmdType, object handler)
        {
            lock (_CommandHandlers)
            {
                _CommandHandlers[cmdType] = handler;
            }
        }
    }
}
