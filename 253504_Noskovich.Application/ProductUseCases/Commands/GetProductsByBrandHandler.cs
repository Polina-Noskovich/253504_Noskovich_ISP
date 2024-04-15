using _253504_Noskovich.Application.ProductUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Commands
{
    public class GetProductsByBrandHandler : IRequestHandler<GetProductsByBrandQuery, List<Product>>
    {
        private IUnitOfWork _unitOfWork;
        public GetProductsByBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            return (List<Product>)await _unitOfWork.ProductRepository
                .ListAsync((product) => product.BrandId == request.BrandId, cancellationToken);
        }
    }
}
