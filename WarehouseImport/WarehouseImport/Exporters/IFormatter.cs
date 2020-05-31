using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport.Exporters
{
    public interface IFormatter<T>
    {
        Task<string> FormatAsync(T value);
    }
}
