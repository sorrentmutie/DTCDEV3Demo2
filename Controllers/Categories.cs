using DemoMVC.Models;
using DemoMVC.ViewModels;
using DemoMVC.WorkerServices;
using Microsoft.AspNetCore.Mvc;


namespace DemoMVC.Controllers
{
    public class Categories : Controller
    {
        private readonly ICategoriesWorkerService categoriesWorkerService;

        public Categories(ICategoriesWorkerService categoriesWorkerService)
        {
            this.categoriesWorkerService = categoriesWorkerService;
        }

        public IActionResult Index()
        {
            //var db = new NorthwindContext();
            // var categories = db.Categories.ToList();

            return View(categoriesWorkerService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel categoryCreateViewModel)
        {
            categoriesWorkerService.Add(categoryCreateViewModel);
            return RedirectToAction("Index");
        }

    }
}
