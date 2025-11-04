using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Models;

namespace ProductCatagoryManagement.Repository
{
    public interface ICategoryRepository
    {
        public Task<bool> AddCategory(AddCategoryDto addCategoryDto);
        public Task<IEnumerable<Category>> GetAllCategory();
        public Task<bool> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto);

        public Task<bool> DeleteCategory(int id);
        public Task<Category> GetCategoryById(int id);
    }
}
