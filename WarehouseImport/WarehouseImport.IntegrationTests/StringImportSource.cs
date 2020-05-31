using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Importers;

namespace WarehouseImport.IntegrationTests
{
    public class StringImportSource : IImportSource
    {
        private string _data;

        public void Init(string data)
        {
            _data = data;
        }

        public Task<IEnumerable<string>> GetLinesAsync()
        {
            return Task.FromResult(_data.Split(Environment.NewLine) as IEnumerable<string>);
        }
    }
}
