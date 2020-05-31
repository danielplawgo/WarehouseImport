using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WarehouseImport.Exporters;
using WarehouseImport.Warehouses;

namespace WarehouseImport.UnitTests.Exporters
{
    public class ExportHandlerTests
    {
        protected Mock<IWarehouseRepository> Repository;

        protected List<Warehouse> Warehouses = new List<Warehouse>();

        protected virtual ExportHandler Create()
        {
            Repository = new Mock<IWarehouseRepository>();
            Repository.SetupGet(m => m.Warehouses)
                .Returns(Warehouses);

            return new ExportHandler(Repository.Object);
        }
    }
}
