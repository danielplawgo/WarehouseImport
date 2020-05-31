using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WarehouseImport.Exporters;
using Xunit;

namespace WarehouseImport.UnitTests.Exporters
{
    public class WarehouseExportFormatterTests
    {
        protected ExportQuery.WarehouseDto Warehouse = new ExportQuery.WarehouseDto()
        {
            Name = "warehouse",
            Count = 10,
            Materials = new List<ExportQuery.MaterialDto>()
            {
                new ExportQuery.MaterialDto()
                {
                    Id = "id1",
                    Count = 20
                },
                new ExportQuery.MaterialDto()
                {
                    Id = "id2",
                    Count = 30
                }
            }
        };

        protected virtual WarehouseExportFormatter Create()
        {
            return new WarehouseExportFormatter();
        }

        [Fact]
        public async void Format_Warehouse_Data()
        {
            var formatter = Create();

            var result = await formatter.FormatAsync(Warehouse);

            result.Should()
                .StartWith($"warehouse (total 10){Environment.NewLine}");
        }
    }
}
