using Microsoft.AspNetCore.Mvc;
using PetWeb.DataAccess.Repository.IRepository;
using PetWeb.Models;

namespace PetWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly ILogger<ProductController> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(ILogger<ProductController>logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var Product = _unitOfWork.Product.GetAll();

			return View(Product);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Create(Product obj)
		{
			
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Product created successfully";
				_logger.LogInformation("Product Create");
				return RedirectToAction("Index");

			}

			_logger.LogError("Product Creation Failed");

			return View();


		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id != null)
			{
				Product? product = _unitOfWork.Product.Get(x => x.Id == id);
				if (product != null)
				{
					return View(product);
				}
			}
			return NotFound();

		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Edit(Product obj)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Product updated successfully";
				_logger.LogInformation("Product Update");
				return RedirectToAction("Index");
			}

			_logger.LogError("Product Update Failed");

			return View();


		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id != null)
			{
				Product? product = _unitOfWork.Product.Get(x => x.Id == id);
				if (product != null)
				{
					return View(product);
				}
			}
			return NotFound();

		}

		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
		public IActionResult DeleteAction(int? id)
		{
			if (id != null)
			{
				Product? product = _unitOfWork.Product.Get(x => x.Id == id);
				if (product != null)
				{
					_unitOfWork.Product.Remove(product);
					_unitOfWork.Save();
					TempData["success"] = "Product Deleted successfully";
					_logger.LogInformation("Product Delete");
					return RedirectToAction("Index");
				}

				_logger.LogError("Product Delete Opereation Failed");

			}
			return NotFound();



		}


	}
}
