using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question2.Models;
using System;
using System.Diagnostics;
using System.Drawing.Text;

namespace Question2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;
        public ActionResult LinkEntity()
        {
            return View();
        }

        public ActionResult WebService()
        {
            return RedirectToAction("Index"); 
            
        }
        [HttpGet]
        public ActionResult RecordAdd()//GET
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordAdd(Person person)//POST
        {
            if (ModelState.IsValid)
            {
                _dbContext.Persons.Add(person);
                _dbContext.SaveChanges();
                return RedirectToAction("RecordList");
            }
            return View(person); ;
        }

        public ActionResult RecordDelete()//GET
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordDelete(string name)//POST
        {
            var personToDelete = _dbContext.Persons.FirstOrDefault(p => p.Name == name);


            if (personToDelete != null)
            {
                _dbContext.Persons.Remove(personToDelete);
                _dbContext.SaveChanges();
                ViewBag.DeleteSuccess = true; //Boolean value  inorder to determine succes or not ?
            }
            else
            {
                ViewBag.DeleteSuccess = false;
            }

            return View();
        }

        public ActionResult RecordList()// Retrieve records from the database
        {
            
            var people = _dbContext.Persons.ToList();
            return View(people);
        }

        public ActionResult RecordSearch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordSearch(string name)
        {
            var people = _dbContext.Persons.Where(p => p.Name.Contains(name)).ToList();

            if (people.Any()) //is not null gibi
            {
                // If records found, display the search result
                return View("RecordSearchResult", people);
            }
            else
            {
                // If no records found, display a message
                ViewBag.SearchTerm = name;
                return View("RecordSearchNoResult");
            }
        }
        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
          
        }

        public IActionResult Index()

        {

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
