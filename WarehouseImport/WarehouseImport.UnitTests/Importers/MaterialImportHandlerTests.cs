using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions;
using Moq;
using WarehouseImport.Importers;
using WarehouseImport.Parsers;
using WarehouseImport.Warehouses;
using Xunit;

namespace WarehouseImport.UnitTests.Importers
{
    public class MaterialImportHandlerTests
    {
        protected Mock<IWarehouseRepository> WarehouseRepository;

        protected List<Warehouse> Warehouses = new List<Warehouse>();

        protected MaterialImportCommand Command = new MaterialImportCommand()
        {
            Id = "id",
            Name = "name",
            Warehouses = new List<MaterialImportCommand.WarehouseCount>()
            {
                new MaterialImportCommand.WarehouseCount()
                {
                    Name = "warehouse",
                    Count = 10
                }
            }
        };

        protected virtual MaterialImportHandler Create()
        {
            WarehouseRepository = new Mock<IWarehouseRepository>();
            WarehouseRepository.SetupGet(w => w.Warehouses)
                .Returns(Warehouses);

            WarehouseRepository.Setup(w => w.AddAsync(It.IsAny<Warehouse>()))
                .Callback<Warehouse>(w => Warehouses.Add(w))
                .ReturnsAsync(Result.Ok);

            return new MaterialImportHandler(WarehouseRepository.Object);
        }

        [Fact]
        public async void Add_New_Warehouse_When_Not_Exist()
        {
            var handler = Create();

            var result = await handler.Handle(Command, CancellationToken.None);

            result.Success
                .Should()
                .BeTrue();

            WarehouseRepository.Verify(r => r.AddAsync(It.Is<Warehouse>(w => w.Name == "warehouse")), Times.Once);
        }

        [Fact]
        public async void Dont_Add_Warehouse_When_Exist()
        {
            var handler = Create();

            Warehouses.Add(new Warehouse("warehouse"));

            var result = await handler.Handle(Command, CancellationToken.None);

            result.Success
                .Should()
                .BeTrue();

            WarehouseRepository.Verify(r => r.AddAsync(It.IsAny<Warehouse>()), Times.Never);
        }

        [Fact]
        public async void Add_Material_To_Warehouse()
        {
            var handler = Create();

            var result = await handler.Handle(Command, CancellationToken.None);

            result.Success
                .Should()
                .BeTrue();

            var warehouse = Warehouses.First();

            var expected = new Material("name", "id");
            expected.AddCount(10);

            warehouse.Materials
                .Should()
                .ContainEquivalentOf(expected);
        }
    }
}
