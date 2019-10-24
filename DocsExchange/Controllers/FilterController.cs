﻿using System;
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
using Newtonsoft.Json;

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
        //[ValidateAntiForgeryToken]
        public ActionResult Filter([FromBody] string filters)
        {
            List<FiltersView> filtersView = JsonConvert.DeserializeObject<List<FiltersView>>(filters);
            List<ProductColor> colorFilter = GetColorFilters(filtersView);
            //return RedirectToAction("Index", "Catalog");
            return PartialView("Index");
        }
        private bool FilterByProductName(Product @item, string prodFilter)
        {
            if (String.IsNullOrEmpty(prodFilter))
                return true;
            if (@item.Name == null)
                return false;
            var prod = _productBusinessLogic.GetByStr(@item.Name).FirstOrDefault();
            if (prod != null && prod.Name.Contains(prodFilter))
                return true;
            return false;
        }
        public List<ProductColor> GetColorFilters(List<FiltersView> filtersView) {
            var _colorRep = new ProductColorRepository(_context);
            List<ProductColor> colorFilter = new List<ProductColor> { };
            foreach (FiltersView item in filtersView)
            {
                if (item.Checked) { 
                    string[] result = item.Id.Split(new char[] { '_' }, StringSplitOptions.None);
                    if(item.Id.Split(new char[] { '_' }, StringSplitOptions.None) != null) { 
                    
                        colorFilter.Add(_colorRep.GetById(Int32.Parse(result[1])));
                    }
                }
            }
            return colorFilter;
        }
        private bool FilterByColorName(Product @item, IEnumerable<ProductColorView> filter)
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
        //var colorFilter = filtersItems.ColorList;
        //var metalFilter = filtersItems.MetalList;
        //var typeFilter = filtersItems.TypeList;
        //var statusFilter = filtersItems.StatusList;
        //var statusAvFilter = filtersItems.StatusAvList;
        //var genderFilter = filtersItems.GenderList;

        //var products = _productBusinessLogic
        //    .GetAll()
        //    .Where(@prod =>
        //        FilterByColorName(@prod, colorFilter)
        //        ).ToList();
        //List<ProductView> models = new List<ProductView>();
        //foreach (var item in products)
        //{
        //    models.Add(_mapper.Map<ProductView>(item));
        //}
        //ViewBag.Data = models.OrderBy(x => x.Name).ToList();
    }
}