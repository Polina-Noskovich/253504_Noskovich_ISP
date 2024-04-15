using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Domain.Entities
{
    public class Brand : Entity
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public int? Year { get; set; }
        public List<Product> Products { get; private set; } = [];
        private Brand() { }
        public Brand(int id, string name, string country, string description, int year)
        {
            Id = id;
            Name = name;
            Country = country;
            Description = description;
            Year = year;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public string GetCountryYear()
        {
            return $"{Country}, {Year}";
        }
        public string GetDescription()
        {
            return $"{Description}";
        }
    }
}
