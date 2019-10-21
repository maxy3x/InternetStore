using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Context;
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
        private readonly WebStoreDbContext _context;
        private readonly IMapper _mapper;

        public CatalogController(IProductBusinessLogic productBusinessLogic, 
                                IProductImagesBusinessLogic productImagesBusinessLogic,
                                IMapper mapper, WebStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _productBusinessLogic = productBusinessLogic;
            _productImagesBusinessLogic = productImagesBusinessLogic;
        }
        // GET
        public IActionResult Index()
        {
            var _colorRep = new ProductColorRepository(_context);
            var _metalRep = new ProductMetalRepository(_context);
            var _typeRep = new ProductTypeRepository(_context);
            var _statusRep = new ProductStatusRepository(_context);
            var _statusAvRep = new ProductAvStatusRepository(_context);
            var _genderRep = new GenderRepository(_context);

            try {
                    ViewBag.Data = _productBusinessLogic.GetAllActive().Select(_mapper.Map<ProductView>);
                    ViewBag.Colors = _colorRep.GetAllAvailable();
                    ViewBag.Metals = _metalRep.GetAllAvailable();
                    ViewBag.Genders = _genderRep.GetAllAvailable();
                    ViewBag.Types = _typeRep.GetAllAvailable();
                    ViewBag.Statuses = _statusRep.GetAllAvailable();
                    ViewBag.StatusesAv = _statusAvRep.GetAllAvailable();
                return View();
                }
            catch
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
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult GetFilters(ProductsFilters filtersEvents)
        {
            var _colorRep = new ProductColorRepository(_context);
            var _metalRep = new ProductMetalRepository(_context);
            var _typeRep = new ProductTypeRepository(_context);
            var _statusRep = new ProductStatusRepository(_context);
            var _statusAvRep = new ProductAvStatusRepository(_context);
            var _genderRep = new GenderRepository(_context);
            var filters = new ProductsFilters()
            {
                Name = "",
                ColorList = _colorRep.GetAllAvailable(),
                MetalList = _metalRep.GetAllAvailable(),
                TypeList = _typeRep.GetAllAvailable(),
                StatusList = _statusRep.GetAllAvailable(),
                StatusAvList = _statusAvRep.GetAllAvailable(),
                GenderList = _genderRep.GetAllAvailable()
            };

            //ViewBag.Data = _productBusinessLogic.GetAllActive().Select(_mapper.Map<ProductView>);
            //ViewBag.Colors = _colorRep.GetAllAvailable();
            //ViewBag.Metals = _metalRep.GetAllAvailable();
            //ViewBag.Genders = _genderRep.GetAllAvailable();
            //ViewBag.Types = _typeRep.GetAllAvailable();
            //ViewBag.Statuses = _statusRep.GetAllAvailable();
            //ViewBag.StatusesAv = _statusAvRep.GetAllAvailable();

            return View(nameof(Index));
        }
    }
}