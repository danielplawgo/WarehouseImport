using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WarehouseImport.Warehouses;

namespace WarehouseImport.Exporters
{
    public class ExportHandler : IRequestHandler<ExportQuery, Result<IEnumerable<ExportQuery.WarehouseDto>>>
    {
        private readonly IWarehouseRepository _repository;

        public ExportHandler(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<IEnumerable<ExportQuery.WarehouseDto>>> Handle(ExportQuery request, CancellationToken token)
        {
            var result = _repository.Warehouses
                .OrderByDescending(w => w.Count)
                .ThenByDescending(w => w.Name)
                .Select(w => new ExportQuery.WarehouseDto()
                {
                    Name = w.Name,
                    Count = w.Count
                });

            return Result.OkAsync(result);
        }
    }
}
