using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.UI.Data;
using ProductManagement.UI.ViewModels;

namespace ProductManagement.UI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.Get()));
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var productViewModel = await FindProductCategory(id);
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.Add(product);

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var productViewModel = await FindProductCategory(id);
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(productViewModel);
            
            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.Update(product);
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var productViewModel = await FindProductCategory(id);
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productViewModel = await FindProductCategory(id);
            
            if (productViewModel == null) return NotFound();

            await _productRepository.Remove(id);
            
            return RedirectToAction("Index");
        }
        private async Task<ProductViewModel> FindProductCategory(int id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.FindProductCategory(id));
        }
        private async Task<ProductViewModel> FindProduct(ProductViewModel product)
        {
            product.Category = _mapper.Map<CategoryViewModel>(await _productRepository.Get());
            return product;
        }
    }
}
