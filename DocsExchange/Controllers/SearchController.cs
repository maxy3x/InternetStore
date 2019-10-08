using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess;
using WebStore.Models;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;


namespace WebStore.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;
        readonly UserManager<IdentityUser> _userManager;

        public SearchController(IEmployeeBusinessLogic employeeBusinessLogic, UserManager<IdentityUser> userManager)
        {
            _employeeBusinessLogic = employeeBusinessLogic;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public string[] AutocompleteSearchEmployee(string term)
        {
            if (term == null) return null;

            List<Employee> employees = _employeeBusinessLogic.GetByStr(term);

            List<string> array = new List<string>();

            foreach (var item in employees)
            {
                array.Add(item.Name);
            }

            return array.ToArray();
        }
        public async Task<string[]> AutocompleteSearchUsers(string term)
        {
            if (term == null) return null;
            IdentityUser user = await _userManager.FindByEmailAsync(term);
            List<string> array = new List<string>();
            if(user.UserName != null)
                array.Add(user.UserName);
            
            return array.ToArray();
        }
    }
}