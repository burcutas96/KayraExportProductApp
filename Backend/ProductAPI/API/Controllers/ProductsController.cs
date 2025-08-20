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
        public async Task<IActionResult> Add(ProductInsertDto productInsertDto)
        {
            try
            {
                await _productService.Add(productInsertDto);

                return Ok(new { Message = "Ürün başarıyla eklendi." });
            }
            catch (ProductNameAlreadyExistsException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
