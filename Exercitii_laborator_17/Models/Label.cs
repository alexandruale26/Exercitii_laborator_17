
namespace Exercitii_laborator_17.Models
{
    public class Label
    {
        public int Id { get; set; }
        public Guid Barcode { get; set; } = Guid.NewGuid();
        public double Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
