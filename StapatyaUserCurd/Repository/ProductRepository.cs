using StapatyaUserCurd.Dto;
using StapatyaUserCurd.Models;

namespace StapatyaUserCurd.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductDbContext _contect;
        public ProductRepository(ProductDbContext productDbContext)
        {
            this._contect = productDbContext;
        }

        public async Task<bool> AddProduct(AddProductDto addProductDto)
        {
            try
            {
               await _contect.Product.AddAsync(new Product() { PName = addProductDto.PName , PPrice = addProductDto.PPrice , PCategory = addProductDto.PCategory , PDescription = addProductDto.PDescription });
             var res =  await _contect.SaveChangesAsync() > 0;
                return res ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
               var product = await _contect.Product.FindAsync(id);
                _contect.Product.Remove(product);
              var res =  await _contect.SaveChangesAsync() > 0;

                return res ? true : false;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IList<Product>> GetAllProduct()
        {
            try 
            {
                IList<Product> products = _contect.Product.ToList();

                return products != null ? products : null; 
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _contect.Product.FindAsync(id);
                product.PName = updateProductDto.PName;
                product.PPrice = updateProductDto.PPrice;
                product.PDescription = updateProductDto.PDescription;
                _contect.Product.Update(product);

              var res = await _contect.SaveChangesAsync() > 0;
                return res ? true : false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<Product> GetProductByName(string PName) 
        {
            try 
            {
                var product = await _contect.Product.FindAsync(PName);

                return product != null ? product : null;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

}
