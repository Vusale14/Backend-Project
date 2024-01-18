using Backend_Project.Entities;

namespace Backend_Project.ViewModels
{
    public class ProductVM
    {
        public ICollection<Product> Products {get; set; } = null!;
        public ICollection<Category> Categories { get; set; } = null!;
    }
}
