using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseImport
{
    public class Application : IApplication
    {
        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }

    public interface IApplication
    {
        Task RunAsync();
    }
}
