using _253504_Noskovich.Application.ProductUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Commands
{
    public class AddProductHandler : IRequestHandler<AddProductQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddProductQuery request, CancellationToken cancellationToken)
        {
            var product = new Product(0, request.Name, request.CreatedAt, request.Description, request.ImagePath, request.BrandId, request.Cost, request.Volume);
            await _unitOfWork.ProductRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return product.Id;
        }
    }
}
