using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.UI.ViewModels;

namespace ProductManagement.UI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IImportFileService _importService;

        public ProductsController(IProductRepository productRepository,
                                    IMapper mapper, 
                                    IImportFileService importService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _importService = importService;
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

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) View(productViewModel);
            if (await UploadFile(productViewModel.File))
            {
                var file = productViewModel.File.OpenReadStream();
                await _importService.Import(file);
            }
            return View(nameof(Index));
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

        private async Task<bool> UploadFile(IFormFile file)
        {
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", file.Name);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
