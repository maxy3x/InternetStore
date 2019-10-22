using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using WebStore.Models.Filters;
using DataAccess.Context;
using DataAccess;
using WebStore.ViewModels;
using Domain.Models;
using AutoMapper;

namespace WebStore.Controllers
{
    public class FilterController : Controller
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly IMapper _mapper;
        private readonly WebStoreDbContext _context;
        public FilterController(WebStoreDbContext context, IProductBusinessLogic productBusinessLogic, IMapper mapper)
        {
            _context = context;
            _productBusinessLogic = productBusinessLogic;
            _mapper = mapper;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CatalogFilter(ProductsFilters filtersItems)
        {

            var colorFilter = filtersItems.ColorList;
            var metalFilter = filtersItems.MetalList;
            var typeFilter = filtersItems.TypeList;
            var statusFilter = filtersItems.StatusList;
            var statusAvFilter = filtersItems.StatusAvList;
            var genderFilter = filtersItems.GenderList;

            var products = _productBusinessLogic
                .GetAll()
                .Where(@prod =>
                    FilterByColorName(@prod, colorFilter)
                    ).ToList();
            List<ProductView> models = new List<ProductView>();
            foreach (var item in products)
            {
                models.Add(_mapper.Map<ProductView>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Name).ToList();
            return RedirectToAction("Index", "Catalog");
        }
        private bool FilterByProductName(Product @item, string prodFilter)
        {
            if (String.IsNullOrEmpty(prodFilter))
                return true;
            if (@item.Name == null)
                return false;
            var dep = _productBusinessLogic.GetByStr(@item.Name).FirstOrDefault();
            if (dep != null && dep.Name.Contains(prodFilter))
                return true;
            return false;
        }
        private bool FilterByColorName(Product @item, IEnumerable<ProductColor> filter)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByMetalName(Product @event, IEnumerable<int> filter)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByTypeName(Product @event, IEnumerable<int> filter)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByStatusName(Product @event, IEnumerable<int> filter)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByStatusAvName(Product @event, IEnumerable<int> filter)
        {
            throw new System.NotImplementedException();
        }
        private bool FilterByGenderName(Product @event, IEnumerable<int> filter)
        {
            throw new System.NotImplementedException();
        }
        
    }
}