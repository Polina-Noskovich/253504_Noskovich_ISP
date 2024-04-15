using _253504_Noskovich.Application.BrandUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.BrandUseCases.Commands
{
    public class GetAllCarsHandler : IRequestHandler<GetAllBrandsQuery, List<Brand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return (List<Brand>)await _unitOfWork.BrandRepository.ListAllAsync(cancellationToken);
        }
    }
}
