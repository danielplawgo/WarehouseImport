using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WarehouseImport
{
    public interface ICommand : IRequest<Result>
    {
    }
}
