using Microsoft.EntityFrameworkCore;
using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Models;

namespace ProductCatagoryManagement.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductCategoryDbContext _context;
        public CategoryRepository(ProductCategoryDbContext context) 
        {
            this._context = context;
        }
        public async Task<bool> AddCategory(AddCategoryDto addCategoryDto)
        {
            try
            {
                await _context.Category.AddAsync(new Category()
                {
                    Name = addCategoryDto.Name,
                    Desc = addCategoryDto.Desc

                });

                bool res = await _context.SaveChangesAsync() > 0;
                return res ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
           try
           {
                var category = await _context.Category.FindAsync(id);
                if (category == null) return false;

                _context.Category.Remove(category);
                var res = await _context.SaveChangesAsync();
                return res > 0 ? true : false;

           }
           catch (Exception ex)
           {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    return false;
           }
            
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            try
            {
                var  CategoryList = await _context.Category.ToListAsync();
                return (CategoryList == null) ? null : CategoryList ; 
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var res = await _context.Category.FindAsync(id);
                return res == null ? null : res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return new Category();
            }
        }
        public async Task<bool> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            try
            {
               var category =  _context.Category.Find(id);
                if (category == null) return false;

                category.Name = updateCategoryDto.Name;
                category.Desc = updateCategoryDto.Desc;

                _context.Update(category);
                var res = await _context.SaveChangesAsync();
                return res > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }




    }
}
