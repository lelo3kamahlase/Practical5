using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272Lecture4v1.Models;

namespace INF272Lecture4v1.Controllers
{
    public class HomeController : Controller
    {
        // Create a static list to store people (replaces hardcoded data)
        private static List<PersonModel> people = new List<PersonModel>();

        public ActionResult Index()
        {
            // Initialize with sample data only if empty
            if (people.Count == 0)
            {
                people = new List<PersonModel>
                {
                    new PersonModel { FirstName = "Person01", LastName = "Surname01", Age = 20, IsAlive = true },
                    new PersonModel { FirstName = "Person02", LastName = "Surname02", Age = 21, IsAlive = true },
                    new PersonModel { FirstName = "Person03", LastName = "Surname03", Age = 22, IsAlive = true },
                    new PersonModel { FirstName = "Person04", LastName = "Surname04", Age = 23, IsAlive = true },
                    new PersonModel { FirstName = "YourName", LastName = "YourSurname", Age = 24, IsAlive = true }
                };
            }

            return View(people);
        }

        // Add these new methods for creating people
        [HttpGet] // This is the default, but shown here for clarity
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel newPerson)
        {
            if (ModelState.IsValid)
            {
                // Add the new person to our list
                people.Add(newPerson);

                // Redirect to the Index to show all people
                return RedirectToAction("Index");
            }

            // If validation fails, return to the Create view with the model
            return View(newPerson);
        }

        // Keep your existing About, Contact, form1, and form2 methods unchanged
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult form1(string fName, string lName, int age, string isAlive)
        {
            ViewBag.FirstName = fName;
            ViewBag.LastName = lName;
            ViewBag.Age = age;
            ViewBag.IsAlive = (isAlive != null) ? "Alive" : "Not Alive";
            return View("Contact");
        }

        [HttpPost]
        public ActionResult form2(PersonModel pm)
        {
            ViewBag.FirstName = pm.FirstName;
            ViewBag.LastName = pm.LastName;
            ViewBag.Age = pm.Age;
            ViewBag.IsAlive = pm.IsAlive ? "Alive" : "Not Alive";
            return View("Contact");
        }
        public ActionResult LoadFromStorage()
        {
            var savedData = System.Web.HttpContext.Current.Request.Cookies["peopleData"]?.Value;
            if (!string.IsNullOrEmpty(savedData))
            {
                var people = JsonConvert.DeserializeObject<List<PersonModel>>(savedData);
                return View("Index", people);
            }
            return RedirectToAction("Index");
        }
    }
}