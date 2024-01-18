namespace Backend_Project.Entities
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string CommentDate { get; set; } = null!;
        public string UserComment { get; set; } = null!;
    }
}
