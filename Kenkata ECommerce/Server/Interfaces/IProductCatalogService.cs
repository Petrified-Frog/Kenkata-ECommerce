using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Interfaces
{
    public interface IProductCatalogService
    {        
        Task<List<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductByIdAsync(string id);
        Task<OverlayProductModel> GetProductByIdAsync(string id, bool overlay);
        Task<ProductModel> GetProductByArtNrAsync(string artNr);
        Task<List<ProductModel>> GetProductByParamAsync(ParamOptions paramOption, string value);
        Task UpdateProductAsync(string id, ProductModel product);
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task DeleteProductAsync(string id);
    }
}
