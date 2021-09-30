using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulsar.CommandHandlers.Usuarios;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Common.Services;
using Pulsar.Contracts.Commands.Usuarios;
using Pulsar.Contracts.Requests.Usuarios;
using Pulsar.Domain.Infrastructure.Repositories;
using Pulsar.Domain.Procedimentos.Models;
using Pulsar.Infrastructure.Cqrs;
using Pulsar.Infrastructure.Database;
using Pulsar.Infrastructure.Jobs;
using Pulsar.Infrastructure.Services;
using Pulsar.RequestHandlers.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure
{
    public class PulsarContainer
    {
        public static void Install(IServiceCollection services)
        {
            RegisterFactory(services);
            RegisterRepositoryFactories(services);
            RegisterServices(services);
            RegisterCommandBus(services);
            RegisterRequestBus(services);
        }

        private static void RegisterRequestBus(IServiceCollection services)
        {
            List<Type> types = new List<Type>();

            foreach (var type in typeof(UsuarioRequestHandler).Assembly.GetTypes())
            {
                if (!type.IsClass || type.IsInterface)
                    continue;

                var impl = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>));
                if (impl == null)
                    continue;
                services.AddSingleton(type);
                types.Add(type);
            }

            services.AddSingleton<IRequestBus>(a =>
            {
                var container = a.GetService<MemoryContainerBus>();
                foreach (var type in types)
                {
                    var impl = type.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>));
                    if (impl == null)
                        continue;

                    var method = typeof(MemoryContainerBus).GetMethod("RegisterRequestHandlers");
                    method.MakeGenericMethod(type).Invoke(container, new object[] {
                            a.GetService(type)
                        });
                }

                return container;
            });
        }

        private static void RegisterCommandBus(IServiceCollection services)
        {
            List<Type> types = new List<Type>();

            foreach (var type in typeof(UsuarioCommandHandler).Assembly.GetTypes())
            {
                if (!type.IsClass || type.IsInterface)
                    continue;

                var impl = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncCommandHandler<>));
                if (impl == null)
                    continue;
                services.AddSingleton(type);
                types.Add(type);
            }

            services.AddSingleton<ICommandBus>(a =>
            {
                var container = a.GetService<MemoryContainerBus>();

                foreach (var type in types)
                {
                    var impl = type.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncCommandHandler<>));
                    if (impl == null)
                        continue;

                    var method = typeof(MemoryContainerBus).GetMethod("RegisterCommandHandlers");
                    method.MakeGenericMethod(type).Invoke(container, new object[] {
                            a.GetService(type)
                        });
                }

                return container;
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IFileService, S3FileService>();
            services.AddSingleton<IEmailService, SESEmailService>();
            services.AddSingleton<IJobService, JobService>();
            services.AddSingleton<JobOrchestrator>();
            services.AddSingleton<MemoryContainerBus>();
            services.AddSingleton<ISpeechSynthesizer, PollyService>();

            var assemblies = new Assembly[]
            {
                typeof(UsuarioRequestHandler).Assembly,
                typeof(Procedimento).Assembly
            };

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IService).IsAssignableFrom(type) && type.IsClass && !type.IsInterface)
                        services.AddSingleton(type);
                }
            }
        }

        private static void RegisterRepositoryFactories(IServiceCollection services)
        {
            Pulsar.Common.Extensions.AbstractExtensions = new MongoAbstractExtensions();
            foreach (var type in typeof(ProcedimentoMongoRepository).Assembly.GetTypes())
            {
                var impl = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRepository<>));
                if (impl == null)
                    continue;
                var modelType = impl.GetGenericArguments()[0];

                services.AddSingleton(
                    typeof(IAsyncRepositoryFactory<>).MakeGenericType(modelType),
                    typeof(MongoRepositoryFactory<,>).MakeGenericType(modelType, type));
            }
        }

        private static void RegisterFactory(IServiceCollection services)
        {
            MongoAutoMapper.Map(typeof(Procedimento).Assembly);
            services.AddSingleton<MongoContextFactory>();
            services.AddSingleton<IDbContextFactory, MongoContextFactory>();
        }
    }
}
