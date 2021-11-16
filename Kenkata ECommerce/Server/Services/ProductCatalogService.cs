using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IMongoCollection<ProductModel> _products;
        private readonly IMongoCollection<OverlayProductModel> _products_overlay;

        public ProductCatalogService(IKenkataDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<ProductModel>(settings.ProductCollectionName);
            _products_overlay = database.GetCollection<OverlayProductModel>(settings.ProductCollectionName);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Return a list of products</returns>
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var result = _products.Find(p => true).ToListAsync();
            return await result;
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>Return one product</returns>    
        public async Task<ProductModel> GetProductByIdAsync(string id)
        {
            var result = _products.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (result.Result == null) //Cant find the sought product. Return epty object
            {
                return new ProductModel();
            }
            return await result;
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>Return one product, only overlay fields </returns>        
        public async Task<OverlayProductModel> GetProductByIdAsync(string id, bool overlay)
        {
            var projection = Builders<OverlayProductModel>.Projection.Include("name").Include("price").Include("brand").Include("tags").Include("categories").Include("images");
            var resultF = _products_overlay.Find(p => p.Id == id).Project(projection).FirstOrDefaultAsync();
            if (resultF.Result == null) //Cant find the sought product. Return epty object
            {
                return new OverlayProductModel();
            }
            var result = BsonSerializer.Deserialize<OverlayProductModel>(resultF.Result);            
            return result; //cant await here. why?
        }

        /// <summary>
        /// Get a product by article nr
        /// </summary>
        /// <param name="id">The article nr of the product</param>
        /// <returns>Return one product</returns>   
        public async Task<ProductModel> GetProductByArtNrAsync(string artNr)
        {
            var result = _products.Find(p => p.articleNr == artNr).FirstOrDefaultAsync();
            if (result.Result == null) //Cant find the sought product. Return epty object
            {
                return new ProductModel();
            }
            return await result;
        }

        public async Task<List<ProductModel>> GetProductByParamAsync(ParamOptions paramOption, string value)
        {
            switch (paramOption)
            {
            case ParamOptions.Category:
                {
                    var categorieFilter = Builders<ProductModel>.Filter.Eq("categories", value);
                    return await _products.Find(categorieFilter).ToListAsync();
                }
            case ParamOptions.Brand:
                {
                    return await _products.Find(p => p.brand == value).ToListAsync();
                }
            case ParamOptions.Tag:
                {
                    var tagsFilter = Builders<ProductModel>.Filter.Eq("tags", value);
                    return await _products.Find(tagsFilter).ToListAsync();
                }
            default:
                {
                    return new List<ProductModel>();
                }
            }

            //return paramOption switch
            //{
            //    ParamOptions.Brand => await _products.Find(p => p.brand == value).ToListAsync(),
            //    ParamOptions.Category => await _products.Find(p => p.categories[0] == value).ToListAsync(),
            //    ParamOptions.Tag => await _products.Find(p => p.tags[0] == value).ToListAsync(),
            //    _ => new List<ProductModel>(),
            //};
        }

        /// <summary>
        /// Replace the param id product with param product
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <param name="product">The replacement product</param>
        /// <returns>void</returns>
        public async Task UpdateProductAsync(string id, ProductModel product)
        {
            try
            {
                await _products.ReplaceOneAsync(p => p.Id == id, product);
            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        /// Create a new product
        /// </summary>        
        /// <param name="product">The new product</param>
        /// <returns>void</returns>        
        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {            
            try
            {
                await _products.InsertOneAsync(product);
                var result = _products.Find(p => p.articleNr == product.articleNr).FirstOrDefaultAsync();
                return await result;
            }
            catch
            {                
                throw;
            }           
        }

        /// <summary>
        /// Delete a product
        /// </summary>        
        /// <param name="id">The id of the product</param>
        /// <returns>void</returns> 
        public async Task DeleteProductAsync(string id)
        {           
            try
            {
                await _products.DeleteOneAsync(p => p.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
