using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WarehouseImport.Exporters
{
    public class ExportQuery : IQuery, IRequest<Result<IEnumerable<ExportQuery.WarehouseDto>>>
    {
        public class WarehouseDto
        {
            public string Name { get; set; }

            public int Count { get; set; }
        }

        public class MaterialDto
        {
            public string Id { get; set; }

            public int Count { get; set; }
        }
    }
}
