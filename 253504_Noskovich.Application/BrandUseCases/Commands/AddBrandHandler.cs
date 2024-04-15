using _253504_Noskovich.Application.BrandUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.BrandUseCases.Commands
{
    public class AddBrandHandler : IRequestHandler<AddBrandQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddBrandQuery request, CancellationToken cancellationToken)
        {
            var brand = new Brand(0, request.Name, request.Country, request.Description, request.Year);
            await _unitOfWork.BrandRepository.AddAsync(brand, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return brand.Id;
        }
    }
}
