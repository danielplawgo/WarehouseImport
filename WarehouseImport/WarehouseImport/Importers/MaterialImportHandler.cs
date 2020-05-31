using System;
using System.Collections.Generic;
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

            return Result.Ok();
        }
    }
}
