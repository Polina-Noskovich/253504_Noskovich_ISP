using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.ProductUseCases.Queries
{
    public record AddProductQuery : IRequest<int>
    {
        public AddProductQuery(string name, DateTime createdAt, string description, decimal cost, double volume, string imagePath, int brandId)
        {
            Name = name;
            CreatedAt = createdAt;
            Description = description;
            Cost = cost;
            Volume = volume;
            ImagePath = imagePath;
            BrandId = brandId;
        }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public double Volume { get; set; }
        public string ImagePath { get; set; }
        public int BrandId { get; set; }
    }
}
