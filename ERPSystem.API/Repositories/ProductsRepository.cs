using ERPSystem.API.Contexts;
using ERPSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.API.Repositories
{
    public class ProductsRepository
    {

        private readonly TemporaryContext context;

        public ProductsRepository (TemporaryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts ()
        {
            return context.Products.ToList();
        }

        public Product? GetProductById (int id)
        {
            return context.Products.Where(product => product.id == id).FirstOrDefault();
        }

        public Product InsertProduct (Product product)
        {
            
            context.Products.Add(product);

            context.SaveChanges();

            return product;

        }

        public Product? UpdateProductById (int id, Product mutation)
        {

            Product? product = GetProductById(id);

            if (product == null) return null;
            
            if (mutation.name != null) product.name = mutation.name;

            if (mutation.price != null) product.price = mutation.price;

            context.SaveChanges();

            return product;

        }

        public Product? DeleteProductById (int id)
        {

            Product? product = GetProductById(id);

            if (product == null) return null;

            context.Products.Remove(product);

            context.SaveChanges();

            return product;

        }

    }
}
