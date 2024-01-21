using Backend_Project.Entities;

namespace Backend_Project.ViewModels
{
    public class HomeVM
    {
        public ICollection<Slider> Sliders { get; set; } = null!;
        public ICollection<Advertising> Advertisings { get; set; } = null!;
        public ICollection<Category> Categories { get; set; } = null!;
        public ICollection<NewArrival> NewArrivals { get; set; } = null!;
        public ICollection<BestSeller> BestSellers { get; set; } = null!;
        public ICollection<Featured> Featureds { get; set; } = null!;
        public ICollection<SpecialOffer> SpecialOffers { get; set; } = null!;
        public ICollection<Trending> Trendings { get; set; } = null!;

    }
}
