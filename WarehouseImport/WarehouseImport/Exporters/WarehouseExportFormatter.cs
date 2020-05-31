using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Exporters
{
    public class WarehouseExportFormatter : IFormatter<ExportQuery.WarehouseDto>
    {
        public Task<string> FormatAsync(ExportQuery.WarehouseDto warehouse)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{warehouse.Name} (total {warehouse.Count})");

            var materials = string.Join(Environment.NewLine, warehouse.Materials.Select(m => $"{m.Id}: {m.Count}"));

            builder.Append(materials);

            return Task.FromResult(builder.ToString());
        }
    }
}
