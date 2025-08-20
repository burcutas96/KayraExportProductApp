using API.Dtos;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Service.Exceptions.Product;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService) 
            => _productService = productService;



        [SwaggerOperation(Summary = "Yeni ürün ekler.")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
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




        [SwaggerOperation(Summary = "Belirtilen ürün ID’sine sahip ürünü günceller.")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        [HttpPut("{productId}")]
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




        [SwaggerOperation(Summary = "Belirtilen ürün ID’sine sahip ürünü soft-delete yöntemiyle siler.")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                await _productService.Delete(productId);
                return Ok(new ApiResponse { Success = true, Message = "Ürün başarıyla silindi." });
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(new ApiResponse { Success = false, Message = ex.Message });
            }
        }




        [SwaggerOperation(Summary = "Belirtilen ürün ID’sine sahip ürünü getirir ve detay bilgilerini döner.")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiDataResponse<ProductDetailDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        [HttpGet("{productId}")]
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




        [SwaggerOperation(Summary = "Tüm ürünleri listeler.")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiDataResponse<List<ProductDto>>))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProductDto> productDtos = await _productService.GetAll();

            return Ok(new ApiDataResponse<List<ProductDto>> { Success = true, Message = "Ürünler başarıyla listelendi.", Data = productDtos });
        }
    }
}
