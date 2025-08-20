using Entity.Concrete;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Repository.Abstract;
using Service.Abstract;
using Service.Exceptions;
using Service.Exceptions.File;
using Service.Exceptions.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal) 
            => _productDal = productDal;
        


        public async Task<bool> Add(ProductInsertDto productInsertDto)
        {
            await CheckIfProductNameExists(productInsertDto.Name);

            Product product = new()
            {
                Name = productInsertDto.Name,
                Price = productInsertDto.Price,
                Description = productInsertDto.Description,
                Stock = productInsertDto.Stock,
                CreateDate = DateTime.Now
            };

            await _productDal.AddAsync(product);

            return true;
        }

        




        private async Task CheckIfProductNameExists(string productName, int? productId = null)
        {
            if (await _productDal
                .AnyAsync(p => p.Name == productName
                && (productId.HasValue ? p.Id != productId : true)
                && !p.IsDeleted))
                throw new ProductNameAlreadyExistsException();
        }

    }
}
