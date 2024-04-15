using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Queries
{
    public record GetProductsByBrandQuery : IRequest<List<Product>>
    {
        public GetProductsByBrandQuery(int brandId)
        {
            BrandId = brandId;
        }
        public int BrandId { get; set; }
    }
}
