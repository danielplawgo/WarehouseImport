using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WarehouseImport.Parsers;

namespace WarehouseImport.Importers
{
    public class MaterialImportHandler : IRequestHandler<MaterialImportCommand, Result>
    {
        public Task<Result> Handle(MaterialImportCommand request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
