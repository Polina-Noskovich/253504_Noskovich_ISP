using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Persistense.Repository
{
    public class FakeProductRepository : IRepository<Product>
    {
        List<Product> _products;
        public FakeProductRepository()
        {
            _products =
                [
                    new Product(1, "Сoncealer", new DateTime(2023, 7, 20), "Apply to face", "", 1, 200, 5),
                    new Product(2, "Mask", new DateTime(2024, 2, 22), "Apply under eyes", "", 2, 68, 50),
                    new Product(3, "Gloss", new DateTime(2024, 1, 11), "Apply to lips", "", 3, 300, 2.8),
                    new Product(4, "Mascara", new DateTime(2023, 6, 23), "Apply to eyelashes", "", 1, 34, 7),
                    new Product(5, "Serum", new DateTime(2023, 10, 15), "Apply to the neck", "", 2, 22, 8.2)
                ];
        }
        public Task AddAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Product, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Product>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _products);
        }

        public Task<IReadOnlyList<Product>> ListAsync(Expression<Func<Product, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Product, object>>[]? includesProperties)
        {
            var data = _products.AsQueryable();
            var filteredData = data.Where(filter).ToList();
            IReadOnlyList<Product> result = filteredData;
            return Task.FromResult(result);
        }

        public Task UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
