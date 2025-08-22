using Entity.Concrete;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Repository.Abstract;
using Service.Abstract;
using Service.Exceptions;
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



        public async Task Add(ProductUpsertDto productInsertDto)
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
            await _productDal.SaveChangesAsync();
        }


        public async Task Update(int productId, ProductUpsertDto productUpsertDto)
        {
            Product product = await CheckIfProductEntity(productId);


            if (!string.Equals(product.Name, productUpsertDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                await CheckIfProductNameExists(productUpsertDto.Name, productId);
                product.Name = productUpsertDto.Name;
            }

            product.Price = productUpsertDto.Price;
            product.Description = productUpsertDto.Description;
            product.Stock = productUpsertDto.Stock;
            product.UpdateDate = DateTime.Now;

            await _productDal.SaveChangesAsync();
        }


        public async Task Delete(int productId)
        {
            Product product = await CheckIfProductEntity(productId);

            product.IsDeleted = true;
            product.DeleteDate = DateTime.Now;

            await _productDal.SaveChangesAsync();
        }



        public async Task<ProductDetailDto> GetById(int productId)
        {
            Product product = await CheckIfProductEntity(productId);

            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock,
                UpdateDate = product.UpdateDate,
                CreateDate = product.CreateDate,
            };
        }



        public async Task<List<ProductListDto>> GetAll()
        {
            List<Product> products = await _productDal
                .GetAllAsync(p => !p.IsDeleted);

            List<ProductListDto> productDtos = new();

            products.ForEach(p => productDtos.Add(
                new()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock
                }));

            return productDtos;
        }







        private async Task<Product> CheckIfProductEntity(int productId)
        {
            Product? product = await _productDal
                .GetAsync(p => p.Id == productId && !p.IsDeleted)
                ??
                throw new ProductNotFoundException();

            return product;
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
