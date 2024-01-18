using Backend_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_Project.DAL
{
    public class ShopwiseDbContext : DbContext
    {
        public ShopwiseDbContext(DbContextOptions<ShopwiseDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders {get; set;}
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewArrival> NewArrivals { get; set; }
        public DbSet<BestSeller> BestSellers { get; set; }
        public DbSet<Featured> Featureds { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<Trending> Trendings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }
        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }
        public DbSet<ProductAdditionalInfo> ProductAdditionalInfos { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
    }
}
