﻿using storeManagerDotNet.Models;

namespace storeManagerDotNet.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int id);
        Task Create(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task Delete(int id);
    }
}
