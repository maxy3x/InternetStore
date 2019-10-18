using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;

namespace WebStore.Controllers
{
    public class FilterController : Controller
    {
        private readonly IProductMetalBusinessLogic _productMetalBusinessLogic;
        private readonly IProductColorBusinessLogic _productColorBusinessLogic;
        private readonly IGenderBusinessLogic _genderBusinessLogic;
        public FilterController(IProductMetalBusinessLogic productMetalBusinessLogic,
                                IProductColorBusinessLogic productColorBusinessLogic,
                                IGenderBusinessLogic genderBusinessLogic)
        {
            _productMetalBusinessLogic = productMetalBusinessLogic;
            _productColorBusinessLogic = productColorBusinessLogic;
            _genderBusinessLogic = genderBusinessLogic;
        }
        public IActionResult GetResult()
        {
            var genders = _genderBusinessLogic.GetAllAvailable();
            return RedirectToAction("Index", "Product");
        }
    }
}