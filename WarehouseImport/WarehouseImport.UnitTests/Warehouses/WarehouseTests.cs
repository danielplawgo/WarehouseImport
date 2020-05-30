using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WarehouseImport.Warehouses;
using Xunit;

namespace WarehouseImport.UnitTests.Warehouses
{
    public class WarehouseTests
    {
        [Fact]
        public void Create_New_Warehouse()
        {
            var warehouse = new Warehouse("warehouse");

            warehouse.Name
                .Should()
                .Be("warehouse");

            warehouse.Materials
                .Should()
                .BeEmpty();
        }
    }
}
