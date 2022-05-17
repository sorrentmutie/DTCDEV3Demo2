using System.ComponentModel.DataAnnotations;

namespace DemoMVC.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
