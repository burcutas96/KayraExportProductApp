using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

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
            => Ok(await _productService.Add(productInsertDto));
    }
}
