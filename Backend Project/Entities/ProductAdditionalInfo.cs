namespace Backend_Project.Entities
{
    public class ProductAdditionalInfo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AdditionalInfoId { get; set; }
        public Product Product { get; set; } = null!;
        public AdditionalInfo AdditionalInfo { get; set; } = null!;
    }
}
