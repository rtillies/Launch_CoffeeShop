using CoffeeShopMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.Models;

namespace CoffeeShopMVC.Controllers
{
	public class CustomersController : Controller
	{
		private readonly CoffeeShopMVCContext _context;

		public CustomersController(CoffeeShopMVCContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var customers = _context.Customers.ToList();
			return View(customers);
		}

		public IActionResult New()
		{
			return View();
		}

		// Create route
		[HttpPost]
		public IActionResult Index(Customer customer)
		{
			_context.Customers.Add(customer);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[Route("customers/details/{id:int}")]
		public IActionResult Show(int id)
		{
			var customer = _context.Customers.Find(id);
			return View(customer);
		}

		[Route("customers/edit/{id:int}")]
		public IActionResult Edit(int id)
		{
			var customer = _context.Customers.Find(id);
			return View(customer);
		}

		[HttpPost]
		[Route("customers/details/{id:int}")]
		public IActionResult Update(int id, Customer customer)
		{
			customer.Id = id;
			_context.Customers.Update(customer);
			_context.SaveChanges();

			return RedirectToAction("show");
		}

		public IActionResult Delete(int id)
		{
			var customer = _context.Customers.Find(id);

			if (customer != null)
			{
				_context.Customers.Remove(customer);
				_context.SaveChanges();
			}

			return RedirectToAction("Index");
		}
	}
}
