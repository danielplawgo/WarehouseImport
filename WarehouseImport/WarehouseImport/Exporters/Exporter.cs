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

        public Exporter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> ExportAsync()
        {

            return Result.Ok();
        }
    }
}
