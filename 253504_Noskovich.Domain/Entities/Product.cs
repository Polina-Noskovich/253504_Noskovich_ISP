using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Domain.Entities
{
    public class Product : Entity
    {
        private Product() { }
        public Product(int id, string name, DateTime createAt, string description, string imagePath, int brandId, decimal cost, double volume)
        {
            Id = id;
            Name = name;
            CreatedAt = createAt;
            Description = description;
            Cost = cost;
            Volume = volume;
            ImagePath = imagePath;
            BrandId = brandId;
        }
        public string? Name { get; set; }
        public decimal Cost { get; /*private*/ set; }
        public double Volume { get;/*private*/ set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BrandId { get; /*private*/ set; }
        public Brand Brand { get; set; }
        public string? ImagePath { get; set; }
        public void addToBrand(int brandId)
        {
            if (brandId <= 0) return;
            BrandId = brandId;
        }
        public void removeFromBrand() { BrandId = 0; }
        public void changeCost(decimal cost)
        {
            if (cost < 0) return;
            Cost = cost;
        }
        public void changeVolume(double volume)
        {
            if (volume < 0) return;
            Volume = volume;
        }
    }
}
