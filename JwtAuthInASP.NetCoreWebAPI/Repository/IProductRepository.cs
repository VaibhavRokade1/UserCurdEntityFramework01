using JwtAuthInASP.NetCoreWebAPI.Dto;

namespace JwtAuthInASP.NetCoreWebAPI.Repository
{
    public interface IProductRepository
    {
        public Task<bool> AddProduct(AddProductDto addProductDto);

        //public Task<bool> 
    }
}
