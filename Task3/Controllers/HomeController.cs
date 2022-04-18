using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Entities;
using Task3.Models;
using Task3.Repositories;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            
            var persons = _repository.GetAll().Select(p =>
            {
                var vm = new PersonViewModel
                {
                    Id = p.Id,
                    Address = p.Address,
                    Age = p.Age,
                    Name = p.Name,
                    Salary = p.Salary,
                    Surname = p.Surname
                };
                return vm;
            });
          
            return View(persons);
        }
        public IActionResult Create()
        {
            var vm = new PersonViewModel();
            return View(vm);
        }
       
        [HttpPost]
        public IActionResult Create(PersonViewModel pm)
        {
            var person = new Person
            {
                Name=pm.Name,
                Surname=pm.Surname,
                Age=pm.Age,
                Address=pm.Address,
                Salary=pm.Salary
            };
            _repository.Add(person);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var person = _repository.Get(id);
            var model = new PersonViewModel
            {
                Address = person.Address,
                Age = person.Age,
                Id = person.Id,
                Name = person.Name,
                Salary = person.Salary,
                Surname = person.Surname
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _repository.Get(id);
            var model = new PersonViewModel
            {
                 Address=person.Address,
                  Age=person.Age,
                   Id=person.Id,
                    Name=person.Name,
                     Salary=person.Salary,
                      Surname=person.Surname
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PersonViewModel model)
        {
            var person = new Person
            {
                Address = model.Address,
                Age = model.Age,
                Id = model.Id,
                Name = model.Name,
                Salary = model.Salary,
                Surname = model.Surname
            };
            _repository.Update(person);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var person = _repository.Get(id);
            _repository.Delete(person);
            //deleted
            return RedirectToAction("Index");
        }
    }
}
