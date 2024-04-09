using ApplicationProject.Dtos;
using DomainCore.Models;


namespace DomainCore.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetProducts();

        public  Task<Product> GetProductById(int id);

        public Task<Product> CreateProduct(ProductForCreationDto product);

        public Task RemoveProduct(int productId);

        public Task UpdateProduct(Product product);
        
    }
}
