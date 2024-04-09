using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;
using DomainCore.Interfaces;
using DomainCore.Context;
using DomainCore.Models;
using System.Data.SqlClient;
using ApplicationProject.Dtos;

namespace Infrastructure.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly DapperContext _dapperContext;

        public ProductRepo(DapperContext dapperContext)
        {
            _dapperContext=dapperContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            var query = "SELECT * FROM Products";
            using (var connection = _dapperContext.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var query = "SELECT * FROM Products WHERE id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
                return product;
            }
        }

        public async Task<Product> CreateProduct(ProductForCreationDto product)
        {
            var query = "INSERT INTO Products (Name, Description, Price, PictureUrl, ProductBrand, ProductType, Avaraible )" +
                " VALUES(@Name, @Description, @Price, @PictureUrl, @ProductBrand, @ProductType, @Avaraible )";
            using (var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("Name", product.Name, DbType.String);
                paramaters.Add("Description", product.Description, DbType.String);
                paramaters.Add("Price", product.Price, DbType.Decimal);
                paramaters.Add("PictureUrl", product.PictureUrl, DbType.String);
                paramaters.Add("ProductBrand", product.ProductBrand, DbType.String);
                paramaters.Add("ProductType", product.ProductType, DbType.String);
                paramaters.Add("Avaraible", product.Avaraible, DbType.String);

                // Execute the query and get the inserted product ID
                var productId = await connection.ExecuteScalarAsync<int>(query, paramaters);
                // Retrieve the created product using the ID
                return await GetProductById(productId);
            }
        }

        public async Task RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
