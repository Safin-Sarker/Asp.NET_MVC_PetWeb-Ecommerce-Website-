using Microsoft.AspNetCore.Mvc;
using PetWeb.Data;
using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;
using PetWeb.Models;

namespace PetWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var category = _unitOfWork.Category.GetAll();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder Can not be same");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Category? category = _unitOfWork.Category.Get(x => x.Id == id);
                if (category != null)
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
                Category? category = _unitOfWork.Category.Get(x => x.Id == id);
                if (category != null)
                {
                    return View(category);
                }
            }
            return NotFound();

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(int? id)
        {
            if (id != null)
            {
                Category? category = _unitOfWork.Category.Get(x => x.Id == id);
                if (category != null)
                {
                    _unitOfWork.Category.Remove(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Deleted successfully";
                    return RedirectToAction("Index");
                }
            }
            return NotFound();



        }


    }
}
