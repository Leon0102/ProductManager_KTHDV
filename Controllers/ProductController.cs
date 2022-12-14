using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return RedirectToAction("Create");
            var categories = _productService.GetCategories();
            ViewBag.Categories = categories;
            return View(product);
        }

        public IActionResult Save(Product product)
        {
            if (product.Id == 0)
            {
                _productService.CreateProduct(product);
            }
            else
            {
                _productService.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var products = _productService.GetProductById(id);
            if (products == null) return RedirectToAction("Index");
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }

}