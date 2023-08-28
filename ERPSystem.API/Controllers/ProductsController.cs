using ERPSystem.API.Models;
using ERPSystem.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ERPSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository productsRepository = new ProductsRepository();

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {

            IEnumerable<Product> products = productsRepository.GetProducts();
            
            return new JsonResult(products);

        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            
            Product? product = productsRepository.GetProductById(id);
            
            if (product == null) return new NotFoundResult();
            
            return new JsonResult(product);

        }

        [HttpPost]
        public ActionResult PostProduct([FromQuery] string name, [FromQuery] int price)
        {

            Product product = productsRepository.InsertProduct(new Product { name = name, price = price });

            return new JsonResult(product);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromQuery] string? name, [FromQuery] int? price)
        {

            Product? product = productsRepository.UpdateProductById(id, new Product { name = name, price = price });

            if (product == null) return new NotFoundResult();

            return new JsonResult(product);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            
            Product? product = productsRepository.DeleteProductById(id);

            if (product == null) return new NotFoundResult();
            
            return new JsonResult(product);
        }

    }
}