using System;
using Autofac;

namespace WarehouseImport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder.Build();
        }
    }
}
