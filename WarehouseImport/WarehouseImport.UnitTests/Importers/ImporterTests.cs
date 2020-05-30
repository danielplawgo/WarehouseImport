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
            ImportSource.Setup(m => m.GetLines())
                .Returns(_lines);

            Command = new Mock<ICommand>();

            Parser = new Mock<IParser>();
            Parser.Setup(m => m.Parse(It.IsAny<string>()))
                .Returns(Result.Ok(Command.Object));

            return new Importer(ImportSource.Object,
                new[] { Parser.Object });
        }

        [Fact]
        public void Get_Lines_From_ImportSource()
        {
            var importer = Create();

            importer.Import();

            ImportSource.Verify(m => m.GetLines(), Times.Once);
        }

        [Fact]
        public void Parse_Line_Using_Parser()
        {
            var importer = Create();

            importer.Import();

            Parser.Verify(m => m.Parse(_lines.First()), Times.Once);
        }
    }
}
