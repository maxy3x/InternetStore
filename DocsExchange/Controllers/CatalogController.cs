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
    public class CatalogController : Controller
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly IProductImagesBusinessLogic _productImagesBusinessLogic;
        private readonly IMapper _mapper;

        public CatalogController(IProductBusinessLogic productBusinessLogic, IProductImagesBusinessLogic productImagesBusinessLogic, IMapper mapper)
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
                ViewBag.Data = _productBusinessLogic.GetAll().Select(_mapper.Map<ProductView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterProducts filtersEvents)
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
    }
}