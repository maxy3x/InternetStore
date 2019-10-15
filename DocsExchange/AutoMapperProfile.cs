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
                .ForMember(x => x.ProductMetalName, c => c.ResolveUsing<ProductMetalResolver>());
            CreateMap<ProductView, Product>()
                .ForMember(x => x.ProductType, c => c.ResolveUsing<ProductTypeResolverReverse>())
                .ForMember(x => x.ProductMetal, c => c.ResolveUsing<ProductMetalResolverReverse>()); ;

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
            var type = _productMetalBusinessLogic.GetById(source.ProductMetal);
            return type.Name;
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
            var type = _productMetalBusinessLogic.GetByStr(source.ProductMetalName).FirstOrDefault();
            return type.Id;
        }
    }
}