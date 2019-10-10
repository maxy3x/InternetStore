using System.Linq;
using AutoMapper;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        
    }
}