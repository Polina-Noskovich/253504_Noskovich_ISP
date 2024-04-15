using _253504_Noskovich.Application.ProductUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Commands
{
    public class EditProductHandler : IRequestHandler<EditProductQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(EditProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product != null)
            {
                product.Name = request.Name;
                product.CreatedAt = request.CreatedAt;
                product.Description = request.Description;
                product.ImagePath = request.ImagePath;
                product.BrandId = request.BrandId;
                product.Cost = request.Cost;
                product.Volume = request.Volume;

                await _unitOfWork.ProductRepository.UpdateAsync(product, cancellationToken);

            }
        }
    }
}
