namespace Backend_Project.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image {  get; set; } = null!;
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Offer { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<Review> Reviews { get; set; }
        public ICollection<ProductInformation> ProductInformations { get; set; } = null!;
        public ICollection<ProductAdditionalInfo> ProductAdditionalInfos { get; set; } = null!;

    }
}
