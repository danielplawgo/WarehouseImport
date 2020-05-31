using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WarehouseImport.Parsers;
using WarehouseImport.Warehouses;

namespace WarehouseImport.Importers
{
    public class MaterialImportHandler : IRequestHandler<MaterialImportCommand, Result>
    {
        private readonly IWarehouseRepository _repository;

        public MaterialImportHandler(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(MaterialImportCommand request, CancellationToken token)
        {
            foreach (var requestWarehouse in request.Warehouses)
            {
                var warehouse = _repository.Warehouses.FirstOrDefault(w => w.Name == requestWarehouse.Name);

                if (warehouse == null)
                {
                    warehouse = new Warehouse(requestWarehouse.Name);

                    await _repository.AddAsync(warehouse);
                }
            }

            return Result.Ok();
        }
    }
}
