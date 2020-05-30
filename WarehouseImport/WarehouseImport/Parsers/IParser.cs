using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Parsers
{
    public interface IParser
    {
        Task<Result<ICommand>> ParseAsync(string line);
    }
}
