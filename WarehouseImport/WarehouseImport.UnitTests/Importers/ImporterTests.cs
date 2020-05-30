using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Moq;
using WarehouseImport.Importers;
using WarehouseImport.Parsers;
using Xunit;

namespace WarehouseImport.UnitTests.Importers
{
    public class ImporterTests
    {
        protected Mock<IImportSource> ImportSource;

        protected IEnumerable<string> _lines = new List<string>()
        {
            "line"
        };

        protected Mock<IParser> Parser;

        protected Mock<ICommand> Command;

        protected virtual Importer Create()
        {
            ImportSource = new Mock<IImportSource>();
            ImportSource.Setup(m => m.GetLinesAsync())
                .ReturnsAsync(_lines);

            Command = new Mock<ICommand>();

            Parser = new Mock<IParser>();
            Parser.Setup(m => m.ParseAsync(It.IsAny<string>()))
                .ReturnsAsync(Result.Ok(Command.Object));

            return new Importer(ImportSource.Object,
                new[] { Parser.Object });
        }

        [Fact]
        public async void Get_Lines_From_ImportSource()
        {
            var importer = Create();

            await importer.ImportAsync();

            ImportSource.Verify(m => m.GetLinesAsync(), Times.Once);
        }

        [Fact]
        public async void Parse_Line_Using_Parser()
        {
            var importer = Create();

            await importer.ImportAsync();

            Parser.Verify(m => m.ParseAsync(_lines.First()), Times.Once);
        }
    }
}
