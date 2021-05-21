using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonDetails.Models;
using PersonDetails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDetails.Controllers
{
    public class PersonController : Controller
    {
        private ILogger<PersonController> _logger;
        private IRepo<Person> _repo;
        public PersonController(IRepo<Person> repo, ILogger<PersonController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Person> authors = _repo.GetAll().ToList();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person author)
        {
            _repo.Add(author);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person= _repo.Get(id);
            return View(person);
        }
        public IActionResult Details(int id)
        {
            Person person= _repo.Get(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(int id, Person person)
        {
            _repo.Update(id,person);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deltete(Person person)
        {
            _repo.Delete(person);
            return RedirectToAction("Index");
        }
    }
}
