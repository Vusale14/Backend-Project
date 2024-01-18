namespace Backend_Project.Entities
{
    public class ProductInformation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InformationId { get; set; }
        public Product Product { get; set; } = null!;
        public Information Information { get; set; } = null!;
    }
}
