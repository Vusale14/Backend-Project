using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Backend_Project.Entities
{
    public class ShopList
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Offer {  get; set; } = null!;
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
    }
}
