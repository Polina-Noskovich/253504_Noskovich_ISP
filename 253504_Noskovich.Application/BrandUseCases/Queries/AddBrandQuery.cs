using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.BrandUseCases.Queries
{
    public record AddBrandQuery : IRequest<int>
    {
        public AddBrandQuery(string name, string country, string description, int year)
        {
            Name = name;
            Country = country;
            Description = description;
            Year = year;
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
    }
}
