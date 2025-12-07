using StapatyaUserCurd.Dto;
using StapatyaUserCurd.Models;

namespace StapatyaUserCurd.Services.Defination
{
    public interface IProductServices
    {
        public Task<bool> AddProduct(AddProductDto addProductDto);
        public Task<IList<Product>> GetAllProducts();
    }
}
