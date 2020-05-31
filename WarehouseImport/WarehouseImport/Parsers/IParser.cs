using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Commands;

namespace WarehouseImport.Parsers
{
    public interface IParser
    {
        Task<Result<ICommand>> ParseAsync(string line);
    }
}
