using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Models;

namespace ProductCatagoryManagement.Repository
{
    public class ProductRepocitory : IProductRepocitory
    {
        private readonly ProductCategoryDbContext _Context;
        public ProductRepocitory(ProductCategoryDbContext context)
        {
            this._Context = context;
        }
        public async Task<bool> AddProduct(AddProductDto addProductDto)
        {
            try
            {
                var product = new Product
                {
                    Name = addProductDto.Name,
                    Price = addProductDto.Price,
                    Cid = addProductDto.Cid
                };

                await _Context.Product.AddAsync(product);
                return await _Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public async Task<ICollection<Product?>> GetAllProduct()
        {
            try
            {
               var ProductsList =  await _Context.Product.Include(p => p.Category).ToListAsync();
                return ProductsList ?? null;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public async Task<bool> UpdateProduct(int id , UpdateProductDto updateProductDto )
        {
            try
            {
               var product = _Context.Product.Find(id);

                product.Name = updateProductDto.Name;
                product.Price = updateProductDto.Price;
                product.Cid = updateProductDto.Cid;

                var res = await _Context.SaveChangesAsync() > 0;
                return res ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;    
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = _Context.Product.Find(id);
               
                 _Context.Product.Remove(product);
                var res = await _Context.SaveChangesAsync();

                return res > 0 ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }
        public async Task<Product> GetProductById(int id) 
        {
            try
            {
                var res = await _Context.Product.FindAsync(id);
                return res == null ? null : res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return new Product();
            }
        }

        public Task<List<Product>> GetProductByCategoryName(string name)
        {
            throw new NotImplementedException();
        }
    }

}
