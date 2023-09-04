using ERPSystem.API.Contexts;
using ERPSystem.API.Models;
using ERPSystem.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ERPSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository productsRepository;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, TemporaryContext context)
        {
            _logger = logger;
            productsRepository = new ProductsRepository(context);
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
        public ActionResult UpdateProduct([FromQuery] Product targetProduct)
        {

            Product? product = productsRepository.UpdateProduct(targetProduct);

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