using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseImport.Commands;

namespace WarehouseImport.Parsers
{
    public class DefaultParser : IParser
    {
        public async Task<Result<ICommand>> ParseAsync(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return Result.Failure<ICommand>("Invalid line");
            }

            if (line.StartsWith("#"))
            {
                return Result.Ok<ICommand>(new NullCommand());
            }

            var command = new MaterialImportCommand();

            var data = line.Split(";");

            command.Name = data[0].Trim();
            command.Id = data[1].Trim();

            var warehouseData = data[2].Split("|");
            var warehouses = new List<MaterialImportCommand.WarehouseCount>();

            foreach (var item in warehouseData)
            {
                var itemData = item.Split(",");

                var warehouseCount = new MaterialImportCommand.WarehouseCount();
                warehouseCount.Name = itemData[0];
                
                if(int.TryParse(itemData[1], out var count))
                {
                    warehouseCount.Count = count;
                }
                
                warehouses.Add(warehouseCount);
            }

            command.Warehouses = warehouses;

            return Result.Ok<ICommand>(command);
        }
    }
}
