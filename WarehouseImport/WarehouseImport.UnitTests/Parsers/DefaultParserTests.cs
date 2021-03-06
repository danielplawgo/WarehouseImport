﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WarehouseImport.Commands;
using WarehouseImport.Parsers;
using Xunit;

namespace WarehouseImport.UnitTests.Parsers
{
    public class DefaultParserTests
    {
        protected virtual DefaultParser Create()
        {
            return new DefaultParser();
        }

        [Theory]
        [InlineData((string) null)]
        [InlineData("")]
        public async void Return_False_Result_When_Line_Is_Null_Or_Empty(string line)
        {
            var parser = Create();

            var result = await parser.ParseAsync(line);

            result.Success
                .Should()
                .BeFalse();
        }

        [Fact]
        public async void Return_NullCommand_When_Line_Start_With_Hash()
        {
            var parser = Create();

            var result = await parser.ParseAsync("#Line to ignore");

            result.Success
                .Should()
                .BeTrue();

            result.Value
                .Should()
                .BeOfType<NullCommand>();
        }

        [Fact]
        public async void Return_MaterialImportCommand_When_Line_Has_Correct_Data()
        {
            var parser = Create();

            var result = await parser.ParseAsync("Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10");

            result.Success
                .Should()
                .BeTrue();

            var expected = new MaterialImportCommand()
            {
                Name = "Cherry Hardwood Arched Door - PS",
                Id = "COM-100001",
                Warehouses = new List<MaterialImportCommand.WarehouseCount>()
                {
                    new MaterialImportCommand.WarehouseCount()
                    {
                        Name = "WH-A",
                        Count = 5
                    },
                    new MaterialImportCommand.WarehouseCount()
                    {
                        Name = "WH-B",
                        Count = 10
                    }
                }
            };

            result.Value
                .Should()
                .BeEquivalentTo(expected);
        }

        [Fact]
        public async void Trim_WhiteSpace_On_Material_Id()
        {
            var parser = Create();

            var result = await parser.ParseAsync(@"MDF, CARB2, 1 1/8""; COM-101734;WH-C,8");

            var command = result.Value as MaterialImportCommand;

            command.Id
                .Should()
                .Be("COM-101734");
        }

        [Fact]
        public async void Trim_WhiteSpace_On_Material_Name()
        {
            var parser = Create();

            var result = await parser.ParseAsync(@" MDF, CARB2, 1 1/8""; COM-101734;WH-C,8");

            var command = result.Value as MaterialImportCommand;

            command.Name
                .Should()
                .Be(@"MDF, CARB2, 1 1/8""");
        }
    }
}
