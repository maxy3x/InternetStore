using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using BusinessLogic;
using WebStore.Models;
using WebStore.Models.Filters;
using WebStore.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper, IEmployeeBusinessLogic employeeBusinessLogic)
        {
            _mapper = mapper;
            _employeeBusinessLogic = employeeBusinessLogic;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _employeeBusinessLogic.GetAll().Select(_mapper.Map<EmployeeView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _employeeBusinessLogic.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var employee = _employeeBusinessLogic.Get(id);
            return View(_mapper.Map<EmployeeView>(employee));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeView employee)
        {
            try
            {
                _employeeBusinessLogic.Update(_mapper.Map<Employee>(employee));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeBusinessLogic.Get(id);
            return View(_mapper.Map<EmployeeView>(employee));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                _employeeBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_mapper.Map<EmployeeView>(_employeeBusinessLogic.Get(id)));
            }
        }

        public ActionResult Details(int id)
        {
            var emp = _employeeBusinessLogic.Get(id);
            return View(_mapper.Map<EmployeeView>(emp));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterEployees filtersEvents)
        {
            var emplFilter = filtersEvents.Name;
            var okpoFilter = filtersEvents.Okpo;
            var departamentFilter = filtersEvents.Departament;
            var employees = _employeeBusinessLogic
                .GetAll()
                .Where(@emp =>
                    FilterByDepartament(@emp, departamentFilter)
                    &&
                    FilterByName(@emp, emplFilter)
                    &&
                    FilterByOKPO(@emp, okpoFilter))
                .ToList();
            List<EmployeeView> models = new List<EmployeeView>();
            foreach (var item in employees)
            {
                models.Add(_mapper.Map<EmployeeView>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Name).ToList();
            return View(nameof(Index));
        }
        private bool FilterByName(Employee @event, string empFilter)
        {
            if (String.IsNullOrEmpty(empFilter))
                return true;
            if (@event.Name == null)
                return false;
            var emp = _employeeBusinessLogic.GetByStr(@event.Name).FirstOrDefault();
            if (emp != null && emp.Name.Contains(empFilter))
                return true;
            return false;
        }
        private bool FilterByDepartament(Employee @event, string departamentFilter)
        {
            if (String.IsNullOrEmpty(departamentFilter))
                return true;
            return false;
        }
        private bool FilterByOKPO(Employee @event, long number)
        {
            if (number == 0)
                return true;
            if (@event.Okpo == 0)
                return false;
            if (@event.Okpo == number)
                return true;
            return false;
        }
    }
}