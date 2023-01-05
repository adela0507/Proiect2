using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect2.Data;
namespace Proiect2.Models
{
    public class BeautyCategoriesPage:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect2Context context,
        Beauty beauty)
        {
            var allCategories = context.Category;
            var beautyCategories = new HashSet<int>(
            beauty.BeautyCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = beautyCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBeautyCategories(Proiect2Context context,
        string[] selectedCategories, Beauty beautyToUpdate)
        {
            if (selectedCategories == null)
            {
                beautyToUpdate.BeautyCategories = new List<BeautyCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var beautyCategories = new HashSet<int>
            (beautyToUpdate.BeautyCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!beautyCategories.Contains(cat.ID))
                    {
                        beautyToUpdate.BeautyCategories.Add(
                        new BeautyCategory
                        {
                            BeautyID = beautyToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (beautyCategories.Contains(cat.ID))
                    {
                        BeautyCategory courseToRemove
                        = beautyToUpdate
                        .BeautyCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
