using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interfaces;
using WebStore.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WebStore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeView>()
                .ForMember(x => x.Message, c => c.ResolveUsing<MessageResolver>())
                .ForMember(x => x.UserName, c => c.ResolveUsing<UserResolver>());
            CreateMap<EmployeeView, Employee>()
                .ForMember(x => x.User, c => c.ResolveUsing<UserResolverReverse>());

            CreateMap<Product, ProductView>()
                .ForMember(x => x.Message, c => c.ResolveUsing<MessageResolver>())
                .ForMember(x => x.ProductTypeName, c => c.ResolveUsing<ProductTypeResolver>())
                .ForMember(x => x.ProductMetalName, c => c.ResolveUsing<ProductMetalResolver>())
                .ForMember(x => x.ProductColorName, c => c.ResolveUsing<ProductColorResolver>())
                .ForMember(x => x.ProductStatusName, c => c.ResolveUsing<ProductStatusResolver>())
                .ForMember(x => x.AvailabilityStatusName, c => c.ResolveUsing<ProductAvStatusResolver>())
                .ForMember(x => x.GenderName, c => c.ResolveUsing<GenderResolver>());
            CreateMap<ProductView, Product>()
                .ForMember(x => x.ProductType, c => c.ResolveUsing<ProductTypeResolverReverse>())
                .ForMember(x => x.ProductMetal, c => c.ResolveUsing<ProductMetalResolverReverse>())
                .ForMember(x => x.ProductColor, c => c.ResolveUsing<ProductColorResolverReverse>())
                .ForMember(x => x.ProductStatus, c => c.ResolveUsing<ProductStatusResolverReverse>())
                .ForMember(x => x.AvailabilityStatus, c => c.ResolveUsing<ProductAvStatusResolverReverse>())
                .ForMember(x => x.Gender, c => c.ResolveUsing<GenderResolverReverse>());

            CreateMap<ProductImage, ProductImageView>()
              .ForMember(x => x.Message, c => c.ResolveUsing<MessageResolver>());
            CreateMap<ProductImageView, ProductImage>();
        }
    }
    
    public class MessageResolver : IValueResolver<Object, Object, String>
    {
        public string Resolve(Object source, Object destination, string message, ResolutionContext context)
        {
            var messageNew = "";
            return messageNew;
        }
    }
    public class UserResolver : IValueResolver<Employee, EmployeeView, string>
    {
        readonly UserManager<IdentityUser> _userManager;
        public UserResolver(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Resolve(Employee source)
        {
            IdentityUser user = await _userManager.FindByIdAsync(source.User);
            return user.UserName;
        }

        string IValueResolver<Employee, EmployeeView, string>.Resolve(Employee source, EmployeeView destination, string destMember, ResolutionContext context)
        {
            if(source.User != null)
            { 
                var user = Resolve(source).Result;
                return user;
            }
            return null;
        }
    }
    public class UserResolverReverse : IValueResolver<EmployeeView, Employee, string>
    {
        readonly UserManager<IdentityUser> _userManager;
        public UserResolverReverse(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Resolve(EmployeeView source)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(source.UserName);
            return user.Id;
        }
        public string Resolve(EmployeeView source, Employee destination, string destMember, ResolutionContext context)
        {
            if(source.UserName != null) { 
                var user = Resolve(source).Result;
                return user;
            }
            return null;
        }
    }

    public class ProductTypeResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IProductTypeBusinessLogic _productTypeBusinessLogic;
        public ProductTypeResolver(IProductTypeBusinessLogic productTypeBusinessLogic)
        {
            _productTypeBusinessLogic = productTypeBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.ProductType == 0)
                return "";
            var type = _productTypeBusinessLogic.GetById(source.ProductType);
            return type.Name;
        }
    }
    public class ProductTypeResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IProductTypeBusinessLogic _productTypeBusinessLogic;
        public ProductTypeResolverReverse(IProductTypeBusinessLogic productTypeBusinessLogic)
        {
            _productTypeBusinessLogic = productTypeBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var type = _productTypeBusinessLogic.GetByStr(source.ProductTypeName).FirstOrDefault();
            return type.Id;
        }
    }
    public class ProductMetalResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IProductMetalBusinessLogic _productMetalBusinessLogic;
        public ProductMetalResolver(IProductMetalBusinessLogic productMetalBusinessLogic)
        {
            _productMetalBusinessLogic = productMetalBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.ProductMetal == 0)
                return "";
            var item = _productMetalBusinessLogic.GetById(source.ProductMetal);
            return item.Name;
        }
    }
    public class ProductMetalResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IProductMetalBusinessLogic _productMetalBusinessLogic;
        public ProductMetalResolverReverse(IProductMetalBusinessLogic productMetalBusinessLogic)
        {
            _productMetalBusinessLogic = productMetalBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var item = _productMetalBusinessLogic.GetByStr(source.ProductMetalName).FirstOrDefault();
            return item.Id;
        }
    }
    public class ProductColorResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IProductColorBusinessLogic _productColorBusinessLogic;
        public ProductColorResolver(IProductColorBusinessLogic productColorBusinessLogic)
        {
            _productColorBusinessLogic = productColorBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.ProductColor == 0)
                return "";
            var item = _productColorBusinessLogic.GetById(source.ProductColor);
            return item.Name;
        }
    }
    public class ProductColorResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IProductColorBusinessLogic _productColorBusinessLogic;
        public ProductColorResolverReverse(IProductColorBusinessLogic productColorBusinessLogic)
        {
            _productColorBusinessLogic = productColorBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var item = _productColorBusinessLogic.GetByStr(source.ProductColorName).FirstOrDefault();
            return item.Id;
        }
    }
    public class ProductStatusResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IProductStatusBusinessLogic _productStatusBusinessLogic;
        public ProductStatusResolver(IProductStatusBusinessLogic productStatusBusinessLogic)
        {
            _productStatusBusinessLogic = productStatusBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.ProductStatus == 0)
                return "";
            var item = _productStatusBusinessLogic.GetById(source.ProductStatus);
            return item.Name;
        }
    }
    public class ProductStatusResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IProductStatusBusinessLogic _productStatusBusinessLogic;
        public ProductStatusResolverReverse(IProductStatusBusinessLogic productStatusBusinessLogic)
        {
            _productStatusBusinessLogic = productStatusBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var item = _productStatusBusinessLogic.GetByStr(source.ProductStatusName).FirstOrDefault();
            return item.Id;
        }
    }
    public class ProductAvStatusResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IProductAvStatusBusinessLogic _productStatusAvBusinessLogic;
        public ProductAvStatusResolver(IProductAvStatusBusinessLogic productAvStatusBusinessLogic)
        {
            _productStatusAvBusinessLogic = productAvStatusBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.AvailabilityStatus == 0)
                return "";
            var item = _productStatusAvBusinessLogic.GetById(source.AvailabilityStatus);
            return item.Name;
        }
    }
    public class ProductAvStatusResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IProductAvStatusBusinessLogic _productAvStatusBusinessLogic;
        public ProductAvStatusResolverReverse(IProductAvStatusBusinessLogic productAvStatusBusinessLogic)
        {
            _productAvStatusBusinessLogic = productAvStatusBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var item = _productAvStatusBusinessLogic.GetByStr(source.AvailabilityStatusName).FirstOrDefault();
            return item.Id;
        }
    }
    public class GenderResolver : IValueResolver<Product, ProductView, String>
    {
        private readonly IGenderBusinessLogic _genderBusinessLogic;
        public GenderResolver(IGenderBusinessLogic genderBusinessLogic)
        {
            _genderBusinessLogic = genderBusinessLogic;
        }
        public string Resolve(Product source, ProductView destination, string destMember, ResolutionContext context)
        {
            if (source.Gender == 0)
                return "";
            var item = _genderBusinessLogic.GetById(source.Gender);
            return item.Name;
        }
    }
    public class GenderResolverReverse : IValueResolver<ProductView, Product, int>
    {
        private readonly IGenderBusinessLogic _genderBusinessLogic;
        public GenderResolverReverse(IGenderBusinessLogic genderBusinessLogic)
        {
            _genderBusinessLogic = genderBusinessLogic;
        }
        public int Resolve(ProductView source, Product destination, int destMember, ResolutionContext context)
        {
            var item = _genderBusinessLogic.GetByStr(source.GenderName).FirstOrDefault();
            return item.Id;
        }
    }
}