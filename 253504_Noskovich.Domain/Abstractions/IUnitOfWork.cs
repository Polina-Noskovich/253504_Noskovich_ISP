using _253504_Noskovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Brand> BrandRepository { get; }
        IRepository<Product> ProductRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
