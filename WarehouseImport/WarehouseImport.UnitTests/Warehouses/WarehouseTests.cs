﻿using System;
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

        [Fact]
        public void Add_Material_To_Warehouse()
        {
            var warehouse = new Warehouse("warehouse");

            warehouse.AddMaterial("name", "id", 10);

            warehouse.Materials
                .Should()
                .HaveCount(1)
                .And
                .Contain(m => m.Name == "name" && m.Id == "id" && m.Count == 10);
        }

        [Fact]
        public void Add_Two_Different_Materials_To_Warehouse()
        {
            var warehouse = new Warehouse("warehouse");

            warehouse.AddMaterial("name", "id", 10);

            warehouse.AddMaterial("name2", "id2", 30);

            warehouse.Materials
                .Should()
                .HaveCount(2)
                .And
                .Contain(m => m.Name == "name" && m.Id == "id" && m.Count == 10)
                .And
                .Contain(m => m.Name == "name2" && m.Id == "id2" && m.Count == 30);
        }
    }
}
