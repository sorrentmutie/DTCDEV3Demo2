using DemoMVC.Models;
using DemoMVC.ViewModels;

namespace DemoMVC.WorkerServices
{
    public interface ICategoriesWorkerService
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel? GetLastAdded();
        void Add(CategoryCreateViewModel newCategory);
    }
}
