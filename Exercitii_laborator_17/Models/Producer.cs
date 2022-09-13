
namespace Exercitii_laborator_17.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string UIC { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
