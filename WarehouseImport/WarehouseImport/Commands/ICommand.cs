using MediatR;

namespace WarehouseImport.Commands
{
    public interface ICommand : IRequest<Result>
    {
    }
}
