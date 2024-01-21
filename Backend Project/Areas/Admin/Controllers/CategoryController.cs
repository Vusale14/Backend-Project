using Backend_Project.Areas.Admin.ViewModels;
using Backend_Project.DAL;
using Backend_Project.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController:Controller
    {
        private readonly ShopwiseDbContext _context;

        public CategoryController(ShopwiseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.AsEnumerable();
            return View(categories);
        }

        public IActionResult Detail(int id)
        {
            if (id == 0) return BadRequest();

            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();

            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryVM category)
        {
            if (!ModelState.IsValid) return View();

            bool isExisted = _context.Categories.Any(c => c.Title == category.Title);

            if (isExisted) return View();

            Category newCategory = new Category
            {
                Title = category.Title
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0) return BadRequest();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id)!;
            if (category is null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, Category category)
        {
            if (id == 0) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View();
            }

            Category existedCategory = _context.Categories.FirstOrDefault(c => c.Id == id)!;

            if (existedCategory is null) return NotFound();

            bool existed = _context.Categories.Any(c => c.Title == category.Title);
            if (existed)
            {
                ModelState.AddModelError(string.Empty, "The same data,please don't repeat");
                return View();
            }

            _context.Entry(existedCategory).CurrentValues.SetValues(category);

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id)!;
            if (category is null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
