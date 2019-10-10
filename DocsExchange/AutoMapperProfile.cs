using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
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
                .ForMember(x => x.Message, c => c.ResolveUsing<MessageResolver>());
            CreateMap<ProductView, Product>();

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
}