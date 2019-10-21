using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Models.Filters;
using WebStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Context;
using DataAccess;

namespace WebStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly IProductImagesBusinessLogic _productImagesBusinessLogic;
        private readonly IMapper _mapper;
        

        public ProductController(IProductBusinessLogic productBusinessLogic, 
                                IProductImagesBusinessLogic productImagesBusinessLogic, 
                                IMapper mapper)
        {
            _mapper = mapper;
            _productBusinessLogic = productBusinessLogic;
            _productImagesBusinessLogic = productImagesBusinessLogic;
        }
        // GET
        public IActionResult Index()
        {
            
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _productBusinessLogic.GetAllActive().Select(_mapper.Map<ProductView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductView product)
        {
            try
            {
                _productBusinessLogic.Insert(_mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var product = _productBusinessLogic.GetById(id);
            return View(_mapper.Map<ProductView>(product));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductView product)
        {
            try
            {
                _productBusinessLogic.Update(_mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(ProductsFilters filtersEvents)
        {
            var prodFilter = filtersEvents.Name;
            var products = _productBusinessLogic
                .GetAll()
                .Where(@prod =>
                    FilterByName(@prod, prodFilter))
                .ToList();
            List<ProductView> models = new List<ProductView>();
            foreach (var item in products)
            {
                models.Add(_mapper.Map<ProductView>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Name).ToList();
            return View(nameof(Index));
        }
        private bool FilterByName(Product @event, string prodFilter)
        {
            if (String.IsNullOrEmpty(prodFilter))
                return true;
            if (@event.Name == null)
                return false;
            var dep = _productBusinessLogic.GetByStr(@event.Name).FirstOrDefault();
            if (dep != null && dep.Name.Contains(prodFilter))
                return true;
            return false;
        }
        public ActionResult Details(int id)
        {
            var product = _productBusinessLogic.GetById(id);
            return View(_mapper.Map<ProductView>(product));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<ProductView>(_productBusinessLogic.GetById(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                if ((_productImagesBusinessLogic.GetByProductId(product.Id)).Any())
                {
                    var prodView = _mapper.Map<ProductView>(_productBusinessLogic.GetById(id));
                    prodView.Message = "Товар використовується!";
                    return View(prodView);
                }
                _productBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var prod = _productBusinessLogic.GetById(id);
                return View(_mapper.Map<ProductView>(prod));
            }
        }
    }
}