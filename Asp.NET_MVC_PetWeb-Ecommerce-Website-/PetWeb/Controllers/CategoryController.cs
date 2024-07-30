using Microsoft.AspNetCore.Mvc;
using PetWeb.Data;
using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;
using PetWeb.Models;

namespace PetWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll();

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
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
            

        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id!=null)
            {
                Category? category = _categoryRepository.Get(x=>x.Id==id);
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
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
			}

			return View();


		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				Category? category = _categoryRepository.Get(x => x.Id == id);
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
                Category? category = _categoryRepository.Get(x => x.Id == id);
                if (category != null) 
                {
                    _categoryRepository.Remove(category);
                    _categoryRepository.Save();
                    TempData["success"] = "Category Deleted successfully";
                    return RedirectToAction("Index");
				}
            }
			return NotFound();



		}


	}
}
