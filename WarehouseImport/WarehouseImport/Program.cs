using System;
using System.Threading.Tasks;
using Autofac;
using MediatR;

namespace WarehouseImport
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var application = CreateApplication(CreateContainer());

            await application.RunAsync();
        }

        public static IContainer CreateContainer(Action<ContainerBuilder> extraRegistrations = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            if (extraRegistrations != null)
            {
                extraRegistrations(builder);
            }

            return builder.Build();
        }

        public static IApplication CreateApplication(IContainer container)
        {
            return container.Resolve<IApplication>();
        }
    }
}
