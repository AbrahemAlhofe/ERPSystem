using ERPSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ERPSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        static private readonly List<Product> products = new List<Product>();

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return new JsonResult(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            Product product = products.Find(product => product.id == id);
            if (product == null) return new NotFoundResult();
            return new JsonResult(product);
        }

        [HttpPost]
        public ActionResult PostProduct([FromQuery] string name, [FromQuery] int price)
        {

            Product product = new Product { id = products.Count(), name = name, price = price };

            if (product == null) return new NotFoundResult();

            products.Add(product);

            return new JsonResult(product);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromQuery] string? name, [FromQuery] int? price)
        {

            Product product = products.Find(product => product.id == id);

            if (product == null) return new NotFoundResult();

            if (name != null) product.name = name;

            if (price != null) product.price = (int)price;

            return new JsonResult(product);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product product = products.Find(product => product.id == id);
            if (product == null) return new NotFoundResult();
            products.RemoveAt(id);
            return new JsonResult(product);
        }

    }
}