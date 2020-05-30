using System;
using System.Collections.Generic;
using System.Text;
using WarehouseImport.Parsers;

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
        public void Return_False_Result_When_Line_Is_Null_Or_Empty(string line)
        {
            var parser = Create();

            var result = parser.Parse(line);

            result.Success
                .Should()
                .BeFalse();
        }
    }
}
