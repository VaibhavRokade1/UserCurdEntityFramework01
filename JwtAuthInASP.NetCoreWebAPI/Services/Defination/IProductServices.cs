using JwtAuthInASP.NetCoreWebAPI.Dto;

namespace JwtAuthInASP.NetCoreWebAPI.Services.Defination
{
    public interface IProductServices
    {
        public Task<bool> AddProduct(AddProductDto addProductDto);
    }
}
