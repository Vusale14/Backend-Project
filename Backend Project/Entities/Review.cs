namespace Backend_Project.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string CommentDate { get; set; } = null!;
        public string UserComment { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
