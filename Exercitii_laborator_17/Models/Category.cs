
namespace Exercitii_laborator_17.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
