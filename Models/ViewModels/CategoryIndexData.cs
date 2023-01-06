namespace Proiect2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<BeautyCategory> BeautyCategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Beauty> Cosmetics { get; set; }
    }
}
