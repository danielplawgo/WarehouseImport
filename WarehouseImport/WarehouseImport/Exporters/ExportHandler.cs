using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WarehouseImport.Exporters
{
    public class ExportHandler : IRequestHandler<ExportQuery, Result<IEnumerable<ExportQuery.WarehouseDto>>>
    {
        public Task<Result<IEnumerable<ExportQuery.WarehouseDto>>> Handle(ExportQuery request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
