using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Parsers
{
    public class DefaultParser : IParser
    {
        public Result<ICommand> Parse(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return Result.Failure<ICommand>("Invalid line");
            }

            if (line.StartsWith("#"))
            {
                return Result.Ok<ICommand>(new NullCommand());
            }

            throw new NotImplementedException();
        }
    }
}
