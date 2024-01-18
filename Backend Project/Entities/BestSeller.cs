namespace Backend_Project.Entities
{
    public class BestSeller
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Old_Price { get; set; }
        public decimal New_Price { get; set; }
        public string Offer { get; set; } = null!;

    }
}
