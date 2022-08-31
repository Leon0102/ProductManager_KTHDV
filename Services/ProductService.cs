using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var existedProduct = GetProductById(product.Id);
            if (existedProduct == null) return;
            existedProduct.Name = product.Name;
            existedProduct.Price = product.Price;
            existedProduct.CategoryId = product.CategoryId;
            existedProduct.Quantity = product.Quantity;
            existedProduct.Description = product.Description;
            existedProduct.Slug = product.Slug;
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return;
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}