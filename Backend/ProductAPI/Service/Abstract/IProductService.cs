using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IProductService
    {
        Task Add(ProductUpsertDto productUpsertDto);

        Task Update(int productId, ProductUpsertDto productUpsertDto);

        Task Delete(int productId);

        Task<ProductDetailDto> GetById(int productId);

        Task<List<ProductListDto>> GetAll();
    }
}
