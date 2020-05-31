using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentAssertions;
using MediatR;
using Moq;
using WarehouseImport.Exporters;
using Xunit;

namespace WarehouseImport.UnitTests.Exporters
{
    public class ExporterTests
    {
        protected Mock<IMediator> Mediator;
        protected ExportQuery.WarehouseDto Warehouse = new ExportQuery.WarehouseDto();
        protected IEnumerable<ExportQuery.WarehouseDto> Warehouses;

        protected Mock<IFormatter<ExportQuery.WarehouseDto>> Formatter;

        protected virtual Exporter Create()
        {
            Warehouses = new List<ExportQuery.WarehouseDto>()
            {
                Warehouse
            };

            Mediator = new Mock<IMediator>();
            Mediator.Setup(m => m.Send(It.IsAny<ExportQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Ok(Warehouses));

            Formatter = new Mock<IFormatter<ExportQuery.WarehouseDto>>();

            return new Exporter(Mediator.Object, Formatter.Object);
        }

        [Fact]
        public async void Execute_Export_Query()
        {
            var exporter = Create();

            await exporter.ExportAsync();

            Mediator.Verify(m => m.Send(It.IsAny<ExportQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void Format_Data()
        {
            var exporter = Create();

            await exporter.ExportAsync();

            Formatter.Verify(m => m.FormatAsync(Warehouse), Times.Once);
        }

        [Fact]
        public async void Dont_Format_Data_When_Query_Has_Error()
        {
            var exporter = Create();

            Mediator.Setup(m => m.Send(It.IsAny<ExportQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure<IEnumerable<ExportQuery.WarehouseDto>>("error"));

            var result = await exporter.ExportAsync();

            result.Success
                .Should()
                .BeFalse();

            Formatter.Verify(m => m.FormatAsync(Warehouse), Times.Never);
        }
    }
}
