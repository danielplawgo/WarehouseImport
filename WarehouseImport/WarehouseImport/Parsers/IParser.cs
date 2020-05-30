using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport.Parsers
{
    public interface IParser
    {
        Result<ICommand> Parse(string line);
    }
}
