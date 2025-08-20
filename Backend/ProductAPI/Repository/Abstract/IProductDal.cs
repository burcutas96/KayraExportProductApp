using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IProductDal
    {
        Task AddAsync(Product product);

        Task<bool> AnyAsync(Expression<Func<Product, bool>> expression);

        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>>? expression = null);

        Task<Product?> GetByIdAsync(int id);

        Task<Product?> GetAsync(Expression<Func<Product, bool>> filter);

        Task RemoveAsync(Product product);

        Task UpdateAsync(Product product);

        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
    }
}
