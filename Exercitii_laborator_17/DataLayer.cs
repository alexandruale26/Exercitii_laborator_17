using Exercitii_laborator_17.Data;
using Exercitii_laborator_17.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercitii_laborator_17
{
    static class DataLayer
    {
        public static void AddCategory(Category category)
        {
            using var context = new StoreContextDB();

            if (context.Categories.Contains(category))
            {
                throw new Exception("category already exists");
            }
            context.Add(category);
            context.SaveChanges();
        }

        public static void AddProducer(Producer producer)
        {
            using var context = new StoreContextDB();

            if (context.Producers.Contains(producer))
            {
                throw new Exception("producer already exists");
            }
            context.Add(producer);
            context.SaveChanges();
        }

        public static void ChangePrice(string productName, double newPrice)
        {
            using var context = new StoreContextDB();
            var temp = context.Products.Include(p => p.Label).FirstOrDefault(p => p.Name == productName);
            
            if (temp == null)
            {
                // lazy Exception implementation
                throw new Exception("product does not exist");
            }
            temp.Label.Price = newPrice;
            context.SaveChanges();
        }

        public static void ChangePrice(int productId, double newPrice)
        {
            using var context = new StoreContextDB();
            var temp = context.Products.Include(p => p.Label).FirstOrDefault(p => p.Id == productId);

            if (temp == null)
            {
                throw new Exception("product does not exist");
            }
            temp.Label.Price = newPrice;
            context.SaveChanges();
        }

        public static void ChangePrice(Guid barcode, double newPrice)
        {
            using var context = new StoreContextDB();
            var temp = context.Products.Include(p => p.Label).FirstOrDefault(p => p.Label.Barcode == barcode);

            if (temp == null)
            {
                throw new Exception("product does not exist");
            }
            temp.Label.Price = newPrice;
            context.SaveChanges();
        }
    
        public static double StoreStockValue()
        {
            using var context = new StoreContextDB();

            if (!context.Products.Any())
            {
                return 0d;
            }
            return context.Products.Include(p => p.Label).Sum(p => p.Label.Price * p.Stock);
        }

        public static double ProducerStockValue(Producer producer)
        {
            using var context = new StoreContextDB();

            if (!context.Producers.Contains(producer))
            {
                return 0d;
            }
            return context.Products.Where(p => p.Producer.Id == producer.Id).Include(p => p.Label).Sum(p => p.Label.Price * p.Stock);
        }

        public static double CategoryStockValue(Category category)
        {
            using var context = new StoreContextDB();

            if (!context.Categories.Contains(category))
            {
                return 0d;
            }
            return context.Products.Where(p => p.Category.Id == category.Id).Include(p => p.Label).Sum(p => p.Label.Price * p.Stock);
        }

        public static double CategoryProducerStockValue(Category category, Producer producer)
        {
            using var context = new StoreContextDB();

            if (!context.Categories.Contains(category) || !context.Producers.Contains(producer))
            {
                return 0d;
            }
            return context.Products.Where(p => p.Category.Id == category.Id && p.Producer.Id == producer.Id).Include(p => p.Label).Sum(p => p.Label.Price * p.Stock);
        }

        public static void AddProduct(Product product, double price)
        {
            using var context = new StoreContextDB();

            if (context.Products.Contains(product))
            {
               throw new Exception("product already exists");
            }

            if (product.Label == null)
            {
                context.Update(product); // without Update product.id = 0
                product.Label = new Label { Price = price };
            }
            context.Add(product);
            context.SaveChanges();
        }
    }
}
