using Dapper_Service_CRUD.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Service_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public ProductController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dapperService.GetProducts(); ;
            return Ok(products);
        }
    }

}
