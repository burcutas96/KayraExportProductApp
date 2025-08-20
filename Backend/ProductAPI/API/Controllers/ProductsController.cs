using API.Dtos;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Service.Exceptions.Product;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService) 
            => _productService = productService;



        [HttpPost]
        public async Task<IActionResult> Add(ProductUpsertDto productUpsertDto)
        {
            try
            {
                await _productService.Add(productUpsertDto);

                return Ok(new ApiResponse { Success = true, Message = "Ürün başarıyla eklendi." });
            }
            catch (ProductNameAlreadyExistsException ex)
            {
                return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
            }
        }



        [HttpPut]
        public async Task<IActionResult> Update(int productId, ProductUpsertDto productUpsertDto)
        {
            try
            {
                await _productService.Update(productId, productUpsertDto);
                return Ok(new ApiResponse { Success = true, Message = "Ürün başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
            }

        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                await _productService.Delete(productId);
                return Ok(new ApiResponse { Success = true, Message = "Ürün başarıyla silindi." });
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetById(int productId)
        {
            try
            {
                ProductDetailDto productDetailDto = await _productService.GetById(productId);
                
                return Ok(new ApiDataResponse<ProductDetailDto> { Success = true, Message = "Ürün başarıyla getirildi.", Data = productDetailDto });
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(new ApiResponse { Success = false, Message = ex.Message });
            }
        }
    }
}
