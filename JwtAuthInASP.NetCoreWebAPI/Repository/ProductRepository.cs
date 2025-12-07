using JwtAuthInASP.NetCoreWebAPI.Dto;
using JwtAuthInASP.NetCoreWebAPI.Models;

namespace JwtAuthInASP.NetCoreWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _Context;
        public ProductRepository(ProductDbContext context)
        {
            _Context = context;
        }
        public async Task<bool> AddProduct(AddProductDto addProductDto)
        {
            try
            {
              await _Context.Product.AddAsync(new Product() { Name = addProductDto.Name , Descreption = addProductDto.Descreption , Cid = addProductDto.Cid });
                var res = await _Context.SaveChangesAsync() > 0;
                return res ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
