using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions;
using Moq;
using WarehouseImport.Exporters;
using WarehouseImport.Warehouses;
using Xunit;

namespace WarehouseImport.UnitTests.Exporters
{
    public class ExportHandlerTests
    {
        protected Mock<IWarehouseRepository> Repository;

        protected virtual ExportHandler Create(List<Warehouse> warehouses)
        {
            Repository = new Mock<IWarehouseRepository>();
            Repository.SetupGet(m => m.Warehouses)
                .Returns(warehouses);

            return new ExportHandler(Repository.Object);
        }

        protected List<Warehouse> CreateDefaultWarehouses()
        {
            var result = new List<Warehouse>();

            var warehouse = new Warehouse("warehouse1");
            warehouse.AddMaterial("material1.1", "id1.1", 10);
            warehouse.AddMaterial("material1.2", "aid1.2", 30);

            result.Add(warehouse);

            warehouse = new Warehouse("warehouse2");
            warehouse.AddMaterial("material2.1", "id2.1", 20);
            warehouse.AddMaterial("material2.2", "aid2.2", 40);

            result.Add(warehouse);

            return result;
        }

        protected List<Warehouse> CreateWarehousesWithTheSameCounts()
        {
            var result = new List<Warehouse>();

            var warehouse = new Warehouse("warehouse1");
            warehouse.AddMaterial("material1.1", "id1.1", 10);
            warehouse.AddMaterial("material1.2", "aid1.2", 30);

            result.Add(warehouse);

            warehouse = new Warehouse("zarehouse2");
            warehouse.AddMaterial("material2.1", "id2.1", 10);
            warehouse.AddMaterial("material2.2", "aid2.2", 30);

            result.Add(warehouse);

            return result;
        }

        [Fact]
        public async void Order_By_Warehouse_Count_Descending()
        {
            var hander = Create(CreateDefaultWarehouses());

            var result = await hander.Handle(new ExportQuery(), CancellationToken.None);

            var firstItem = result.Value.ElementAt(0);

            firstItem.Name
                .Should()
                .Be("warehouse2");

            firstItem.Count
                .Should()
                .Be(60);

            var secondItem = result.Value.ElementAt(1);

            secondItem.Name
                .Should()
                .Be("warehouse1");

            secondItem.Count
                .Should()
                .Be(40);
        }

        [Fact]
        public async void Order_By_Warehouse_Name_When_Count_Is_The_Same()
        {
            var hander = Create(CreateWarehousesWithTheSameCounts());

            var result = await hander.Handle(new ExportQuery(), CancellationToken.None);

            var firstItem = result.Value.ElementAt(0);

            firstItem.Name
                .Should()
                .Be("zarehouse2");

            var secondItem = result.Value.ElementAt(1);

            secondItem.Name
                .Should()
                .Be("warehouse1");
        }
    }
}
