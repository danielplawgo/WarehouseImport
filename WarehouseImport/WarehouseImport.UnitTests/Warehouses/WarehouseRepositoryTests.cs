using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WarehouseImport.Warehouses;
using Xunit;

namespace WarehouseImport.UnitTests.Warehouses
{
    public class WarehouseRepositoryTests
    {
        protected virtual WarehouseRepository Create()
        {
            return new WarehouseRepository();
        }

        [Fact]
        public void Repository_Is_Empty_After_Creation()
        {
            var repository = Create();

            repository.Warehouses
                .Should()
                .BeEmpty();
        }
    }
}
