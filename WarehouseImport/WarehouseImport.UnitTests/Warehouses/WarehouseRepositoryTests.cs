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

        [Fact]
        public void Add_Warehouse_When_Does_Not_Exist()
        {
            var repository = Create();

            var warehouse = new Warehouse("warehouse");

            var result = repository.Add(warehouse);

            result.Success
                .Should()
                .BeTrue();

            repository.Warehouses
                .Should()
                .HaveCount(1)
                .And
                .Contain(warehouse);
        }
    }
}
