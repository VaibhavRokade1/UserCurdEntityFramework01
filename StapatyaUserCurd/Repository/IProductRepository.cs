
using StapatyaUserCurd.Dto;
using StapatyaUserCurd.Models;

namespace StapatyaUserCurd.Repository
{
    public interface IProductRepository
    {

        public Task<bool> AddProduct(AddProductDto addProductDto);
        public Task<bool> UpdateProduct(int id , UpdateProductDto updateProductDto);
        public Task<IList<Product>> GetAllProduct();
        public Task<bool> DeleteProduct(int id);
        
    }
}
