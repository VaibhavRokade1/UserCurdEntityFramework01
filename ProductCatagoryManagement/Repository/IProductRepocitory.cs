using ProductCatagoryManagement.Dto;
using ProductCatagoryManagement.Models;

namespace ProductCatagoryManagement.Repository
{
    public interface IProductRepocitory
    {
        public Task<bool> AddProduct(AddProductDto addProductDto);
        public Task<bool> UpdateProduct( int id , UpdateProductDto updateProducct);
        public Task<bool> DeleteProduct(int id);
        public Task<ICollection<Product?>> GetAllProduct();

        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProductByCategoryName(string name);
    }
}
