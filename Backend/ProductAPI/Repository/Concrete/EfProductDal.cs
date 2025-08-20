using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class EfProductDal : IProductDal
    {
        readonly DbSet<Product> _dbSet;
        readonly ProductContext _context;

        public EfProductDal(ProductContext context)
        {
            _dbSet = context.Set<Product>();
            _context = context;
        }




        public async Task AddAsync(Product product) 
            => await _dbSet.AddAsync(product);




        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
            => await _dbSet.AnyAsync(expression);




        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>>? expression = null)
            => expression == null ? await _dbSet.AsNoTracking().ToListAsync() : await _dbSet.Where(expression).AsNoTracking().ToListAsync();



        public async Task<Product?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);



        public async Task<Product?> GetAsync(Expression<Func<Product, bool>> filter)
            => await _dbSet.SingleOrDefaultAsync(filter);



        public void RemoveAsync(Product product) 
            => _dbSet.Remove(product);



        public void UpdateAsync(Product product)
            => _dbSet.Update(product);




        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
            => _dbSet.Where(expression);



        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }

}
