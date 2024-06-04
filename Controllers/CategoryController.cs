using Microsoft.AspNetCore.Mvc;
using PetWeb.Data;
using PetWeb.Models;

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

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Name","Name and DisplayOrder Can not be same");
            }
            if (ModelState.IsValid) 
            {
                dbContext1.Categories.Add(obj);
                dbContext1.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            

        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id!=null)
            {
                Category category = dbContext1.Categories.FirstOrDefault(x=>x.Id==id);
                if(category!=null) 
                {
                    return View(category);
                }
            }
            return NotFound();

        }

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			
			if (ModelState.IsValid)
			{
				dbContext1.Categories.Update(obj);
				dbContext1.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();


		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				Category? category = dbContext1.Categories.FirstOrDefault(x => x.Id == id);
				if (category != null)
				{
					return View(category);
				}
			}
			return NotFound();

		}

		[HttpPost,ActionName("Delete")]
		public IActionResult DeleteAction(int? id)
		{
            if(id!= null) 
            {
                Category? category = dbContext1.Categories.FirstOrDefault(x => x.Id == id);
                if (category != null) 
                {
					dbContext1.Categories.Remove(category);
					dbContext1.SaveChanges();
					return RedirectToAction("Index");
				}
            }
			return NotFound();



		}


	}
}
