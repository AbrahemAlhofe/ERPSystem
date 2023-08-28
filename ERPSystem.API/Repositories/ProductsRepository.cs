using ERPSystem.API.Models;

namespace ERPSystem.API.Repositories
{
    public class ProductsRepository
    {

        static private readonly List<Product> products = new List<Product>();

        public IEnumerable<Product> GetProducts ()
        {
            return products;
        }

        public Product? GetProductById (int id)
        {
            return products.Find(product => product.id == id);
        }

        public Product InsertProduct (Product product)
        {
            
            product.id = products.Count();
            
            products.Add(product);

            return product;

        }

        public Product? UpdateProductById (int id, Product mutation)
        {

            Product? product = GetProductById(id);

            if (product == null) return null;
            
            if (mutation.name != null) product.name = mutation.name;

            if (mutation.price != null) product.price = mutation.price;

            return product;

        }

        public Product? DeleteProductById (int id)
        {

            Product? product = products.Find(product => product.id == id);

            if (product == null) return null;

            products.RemoveAt(id);

            return product;

        }

    }
}
