using JwtAuthInASP.NetCoreWebAPI.Dto;
using JwtAuthInASP.NetCoreWebAPI.Repository;
using JwtAuthInASP.NetCoreWebAPI.Services.Defination;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthInASP.NetCoreWebAPI.Services.Implimentation
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repo;
        public ProductServices(ProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddProduct(AddProductDto addProductDto)
        {
            if (addProductDto.Name.Trim() == "" || addProductDto.Descreption.Trim() == "" || addProductDto.Cid.ToString().Trim()=="")
            {
                return false;
            }

            var res = await _repo.AddProduct(addProductDto);
            return res ? true : false;
        }
    }
}
