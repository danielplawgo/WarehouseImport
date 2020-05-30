using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using MediatR;
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
        protected Result<ICommand> ParseResult;

        protected Mock<IMediator> Mediator;

        protected virtual Importer Create()
        {
            ImportSource = new Mock<IImportSource>();
            ImportSource.Setup(m => m.GetLinesAsync())
                .ReturnsAsync(_lines);

            Command = new Mock<ICommand>();
            ParseResult = Result.Ok(Command.Object);

            Parser = new Mock<IParser>();
            Parser.Setup(m => m.ParseAsync(It.IsAny<string>()))
                .ReturnsAsync(ParseResult);

            Mediator = new Mock<IMediator>();
            Mediator.Setup(m => m.Send(It.IsAny<IRequest<Result>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Ok());


            return new Importer(ImportSource.Object,
                new[] { Parser.Object },
                Mediator.Object);
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

        [Fact]
        public async void Send_Command_When_Parse_Is_Success()
        {
            var importer = Create();

            await importer.ImportAsync();

            Mediator.Verify(m => m.Send(Command.Object, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void Dont_Send_Command_When_Parse_Is_Not_Success()
        {
            var importer = Create();

            ParseResult.Success = false;

            await importer.ImportAsync();

            Mediator.Verify(m => m.Send(It.IsAny<IRequest<Result>>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
