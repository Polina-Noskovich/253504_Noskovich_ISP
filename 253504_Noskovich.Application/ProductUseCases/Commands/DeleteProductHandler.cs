using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Commands
{
    public sealed record DeleteProductQuery(Product product) : IRequest { }
    internal class DeleteProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductQuery>
    {
        public async Task Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            await unitOfWork.ProductRepository.DeleteAsync(request.product, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
