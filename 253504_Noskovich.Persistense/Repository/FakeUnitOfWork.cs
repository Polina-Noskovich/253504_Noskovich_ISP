using _253504_Noskovich.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Brand>> _brandRepository;
        private readonly Lazy<IRepository<Product>> _productRepository;
        public FakeUnitOfWork(/*AppDbContext context*/)
        {
            //_context = context;
            _brandRepository = new Lazy<IRepository<Brand>>(() => new FakeBrandRepository());
            _productRepository = new Lazy<IRepository<Product>>(() => new FakeProductRepository());
        }
        public IRepository<Brand> BrandRepository => _brandRepository.Value;
        public IRepository<Product> ProductRepository => _productRepository.Value;

        public async Task CreateDataBaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataBaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
