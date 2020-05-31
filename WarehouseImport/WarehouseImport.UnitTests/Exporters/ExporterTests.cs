using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Moq;
using WarehouseImport.Exporters;
using Xunit;

namespace WarehouseImport.UnitTests.Exporters
{
    public class ExporterTests
    {
        protected Mock<IMediator> Mediator;
        protected IEnumerable<ExportQuery.WarehouseDto> Warehouses = new List<ExportQuery.WarehouseDto>()
        {
            new ExportQuery.WarehouseDto()
        };

        protected virtual Exporter Create()
        {
            Mediator = new Mock<IMediator>();
            Mediator.Setup(m => m.Send(It.IsAny<ExportQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Ok(Warehouses));

            return new Exporter(Mediator.Object);
        }

        [Fact]
        public async void Execute_Export_Query()
        {
            var exporter = Create();

            await exporter.ExportAsync();

            Mediator.Verify(m => m.Send(It.IsAny<ExportQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
