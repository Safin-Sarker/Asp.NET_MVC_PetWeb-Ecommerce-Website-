using Microsoft.AspNetCore.Mvc;
using PetWeb.Data;

namespace PetWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext1 dbContext1;

        public CategoryController(ApplicationDbContext1 dbContext1)
        {
            this.dbContext1 = dbContext1;
        }
        public IActionResult Index()
        {
            var category = dbContext1.Categories.ToList();

            return View(category);
        }

        public IActionResult Create() 
        {
            return View();
        }
    }
}
