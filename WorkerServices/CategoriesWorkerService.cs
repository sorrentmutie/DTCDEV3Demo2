using DemoMVC.Models;
using DemoMVC.ViewModels;

namespace DemoMVC.WorkerServices;

public class CategoriesWorkerService : ICategoriesWorkerService
{
    private NorthwindContext database;
    public CategoriesWorkerService()
    {
        database = new NorthwindContext();
    }

    public void Add(CategoryCreateViewModel newCategory)
    {
        database.Categories.Add(new Category
        {
             CategoryName = newCategory.Name,
              Description = newCategory.Description,
        });
        database.SaveChanges();
    }

    public IEnumerable<CategoryViewModel> GetAll()
    {
        var cat =  database.Categories.Select(
            category => new CategoryViewModel
            {
                 Id = category.CategoryId,
                 Name = category.CategoryName,
                 Description = category.Description,
                 ProductsCount = category.Products.Count,
                 MostExpensiveProductName = 
                 category.Products.OrderByDescending(p => p.UnitPrice).FirstOrDefault()
                  != null ? category.Products.OrderByDescending(p => p.UnitPrice).FirstOrDefault().ProductName : "",
            });


        return cat;
    }

    public CategoryViewModel? GetLastAdded()
    {
        return database.Categories.OrderByDescending(c => c.CategoryId)
            .Select(category => new CategoryViewModel
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description,
                ProductsCount = category.Products.Count,
                MostExpensiveProductName =
                category.Products.OrderByDescending(p => p.UnitPrice).FirstOrDefault()
                 != null ? category.Products.OrderByDescending(p => p.UnitPrice).FirstOrDefault().ProductName : "",
            }).FirstOrDefault();
    }
}
