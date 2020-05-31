using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using FluentAssertions;
using WarehouseImport.Exporters;
using Xunit;

namespace WarehouseImport.IntegrationTests
{
    public class ApplicationTests
    {
        protected StringExportDestination ExportDestination;

        protected virtual IApplication Create()
        {
            var container = Program.CreateContainer(builder =>
            {
                builder.RegisterAssemblyTypes(typeof(ApplicationTests).Assembly)
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .SingleInstance();
            });

            ExportDestination = container.Resolve<StringExportDestination>();
            var importSource = container.Resolve<StringImportSource>();
            importSource.Init(InputData);

            return Program.CreateApplication(container);
        }

        [Fact]
        public async void Run_On_Example_Data()
        {
            var application = Create();

            await application.RunAsync();

            ExportDestination.Data
                .Should()
                .Be(ExpectedData);
        }

        protected string InputData = @"# Material inventory initial state as of Jan 01 2018
# New materials
Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10
Maple Dovetail Drawerbox;COM-124047;WH-A,15
Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2
Yankee Hardware 110 Deg. Hinge;COM-123908;WH-A,10|WH-B,11
# Existing materials, restocked
Hdw Accuride CB0115-CASSRC - Locking Handle Kit - Black;CB0115-CASSRC;WH-C,13|WH-B,5
Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm - Paper Back;3M-Cherry-10mm;WH-A,10|WH-B,1
Veneer - Cherry Rotary 1 FSC;COM-123823;WH-C,10
MDF, CARB2, 1 1/8""; COM-101734;WH-C,8";

        protected string ExpectedData = @"WH-A (total 50)
3M-Cherry-10mm: 10
COM-100001: 5
COM-123906c: 10
COM-123908: 10
COM-124047: 15

WH-C (total 33)
CB0115-CASSRC: 13
COM-101734: 8
COM-123823: 10
COM-123906c: 2

WH-B (total 33)
3M-Cherry-10mm: 1
CB0115-CASSRC: 5
COM-100001: 10
COM-123906c: 6
COM-123908: 11";
    }
}
