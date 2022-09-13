
namespace Exercitii_laborator_17.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public Producer Producer { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Label Label { get; set; } = null!;
    }
}
