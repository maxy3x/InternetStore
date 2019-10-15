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

namespace WebStore.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImagesBusinessLogic _productImagesBusinessLogic;
        private readonly IMapper _mapper;

        public ProductImageController(IProductImagesBusinessLogic productImagesBusinessLogic, IMapper mapper)
        {
            _mapper = mapper;
            _productImagesBusinessLogic = productImagesBusinessLogic;
        }
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _productImagesBusinessLogic.GetAll().Select(_mapper.Map<ProductImageView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        // GET
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductImage image)
        {
            try
            {
                _productImagesBusinessLogic.Insert(image);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductImageView image)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterProductsImages filtersEvents)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByProductId(ProductImage @event, int prodFilter)
        {
            throw new System.NotImplementedException();
        }
        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<ProductImageView>(_productImagesBusinessLogic.GetById(id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _productImagesBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_mapper.Map<ProductImageView>(_productImagesBusinessLogic.GetById(id)));
            }
        }
    }
}