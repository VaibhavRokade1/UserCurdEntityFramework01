using StapatyaUserCurd.Dto;
using StapatyaUserCurd.Models;
using StapatyaUserCurd.Repository;
using StapatyaUserCurd.Services.Defination;

namespace StapatyaUserCurd.Services.Implimentation
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repo;
        public ProductServices(IProductRepository repo)
        {
            this._repo = repo;
        }

        public async Task<bool> AddProduct(AddProductDto addProductDto)
        {
           
            var res = await _repo.AddProduct(addProductDto);
            return res ? true : false;
        }

        public Task<IList<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
