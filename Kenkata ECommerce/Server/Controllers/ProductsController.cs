using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Server.Services;
using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kenkata_ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCatalogService _productCatalog;

        public ProductsController(IProductCatalogService productCatalog)
        {
            _productCatalog = productCatalog;
        }

        [HttpGet]        
        public Task<List<ProductModel>> GetProductsAsync() => _productCatalog.GetProductsAsync();

        [HttpGet("{id}")]
        public Task<ProductModel> GetProductByIdAsync(string id) => _productCatalog.GetProductByIdAsync(id);

        [HttpGet("{id}/{overlay}")]
        public Task<OverlayProductModel> GetProductByIdAsync(string id, bool overlay) => _productCatalog.GetProductByIdAsync(id, overlay);

        [Route("GetProductByArtNrAsync/{artnr}")]
        [HttpGet]
        public Task<ProductModel> GetProductByArtNrAsync(string artNr) => _productCatalog.GetProductByArtNrAsync(artNr);

        [Route("GetProductByParamAsync/{paramOption}/{value}")]
        [HttpGet]
        public Task<List<ProductModel>> GetProductByParamAsync(ParamOptions paramOption, string value) => _productCatalog.GetProductByParamAsync(paramOption, value);

        [HttpPut("{id}")]
        public Task UpdateProductAsync(string id, ProductModel product) => _productCatalog.UpdateProductAsync(id, product);

        [HttpPost]
        public Task<ProductModel> CreateProductAsync(ProductModel product) => _productCatalog.CreateProductAsync(product);

        [HttpDelete("{id}")]
        public Task DeleteProductAsync(string id) => _productCatalog.DeleteProductAsync(id);
    }
}
