using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace WarehouseImport.Exporters
{
    public class Exporter : IExporter
    {
        private readonly IMediator _mediator;
        private readonly IFormatter<ExportQuery.WarehouseDto> _formatter;
        private readonly IExportDestination _exportDestination;

        public Exporter(IMediator mediator,
            IFormatter<ExportQuery.WarehouseDto> formatter,
            IExportDestination exportDestination)
        {
            _mediator = mediator;
            _formatter = formatter;
            _exportDestination = exportDestination;
        }

        public async Task<Result> ExportAsync()
        {
            var queryResult = await _mediator.Send(new ExportQuery());

            if (queryResult.Success == false)
            {
                return Result.Failure("error");
            }

            foreach (var warehouseDto in queryResult.Value)
            {
                var formattedValue = await _formatter.FormatAsync(warehouseDto);

                await _exportDestination.WriteAsync(formattedValue);
            }

            return Result.Ok();
        }
    }
}
