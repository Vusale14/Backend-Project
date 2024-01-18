using Backend_Project.DAL;
using Backend_Project.Entities;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopwiseDbContext _context;
        public HomeController(ShopwiseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Advertisings = _context.Advertisings.ToList(),
                Categories = _context.Categories.ToList(),
                NewArrivals = _context.NewArrivals.ToList(),
                BestSellers = _context.BestSellers.ToList(),
                Featureds = _context.Featureds.ToList(),
                SpecialOffers = _context.SpecialOffers.ToList(),
                Trendings = _context.Trendings.ToList()
            };

            if (model.Sliders is null || model.Advertisings is null || model.Categories is null || model.NewArrivals is null || model.BestSellers is null || model.Featureds is null || model.SpecialOffers is null) return NotFound();

            return View(model);
        }
    }
}
