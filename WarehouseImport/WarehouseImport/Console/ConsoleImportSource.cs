using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Importers;

namespace WarehouseImport.Console
{
    public class ConsoleImportSource : IImportSource
    {
        public Task<IEnumerable<string>> GetLinesAsync()
        {
            var result = new List<string>();

            while (true)
            {
                var line = System.Console.ReadLine();

                if (line == null)
                {
                    break;
                }

                result.Add(line);
            }

            return Task.FromResult(result as IEnumerable<string>);
        }
    }
}
