using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Persistense.Repository
{
    public class FakeBrandRepository : IRepository<Brand>
    {
        List<Brand> _brands;
        public FakeBrandRepository()
        {
            _brands = [
                new Brand(1, "Estee Lauder", "USA", "Care", 1946),
                new Brand(2, "DARLING*", "Italy", "Decorative", 2020),
                new Brand(3, "Rhode Skin", "USA", "Care", 2022)
            ];
        }
        public Task AddAsync(Brand entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brand entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> FirstOrDefaultAsync(Expression<Func<Brand, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<Brand> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Brand, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Brand>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _brands);
        }
        public async Task<IReadOnlyList<Brand>> ListAsync(Expression<Func<Brand, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Brand, object>>[]? includesProperties)
        {
            return await Task.Run(() => _brands.AsQueryable().Where(filter).ToList());
        }

        public Task UpdateAsync(Brand entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
