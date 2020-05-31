using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WarehouseImport.Commands
{
    public class NullCommandHandler : IRequestHandler<NullCommand, Result>
    {
        public Task<Result> Handle(NullCommand request, CancellationToken cancellationToken)
        {
            return Result.OkAsync();
        }
    }
}
