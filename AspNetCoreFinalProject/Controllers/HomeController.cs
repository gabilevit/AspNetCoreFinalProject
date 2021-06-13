using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFinalProject.Models;
using AspNetCoreFinalProject.Repositories;
using AspNetCoreFinalProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public HomeController(IRepository repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult HomePage()
        {
            IEnumerable<Comment> comm = _repository.GetComments();
            ViewBag.Comments = comm;
            return View(_repository.GetTop2AnimalsVieComments());
        }

        public IActionResult Catalog()
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View(_repository.GetAnimals());
        }

        public IActionResult SpecificCatalog(int id)
        {
            if (id == 0) return RedirectToAction("Catalog");
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View("Catalog", _repository.GetAnimalsViaCategory(id));

        }
        public IActionResult Animal(int id)
        {
            ViewBag.Comments = _repository.GetCommentsViaAnimal(id);
            var animal = _repository.GetAnimal(id);
            ViewBag.Category = _repository.GetCategory(animal.CategoryId);
            return View(_repository.GetAnimal(id));
        }

        [HttpPost]
        public IActionResult AddComment(int id, string newComment)
        {
            if (newComment != null)
            {
                _repository.InsertComment(new Comment { Info = newComment, AnimalId = id });
                return RedirectToAction("Animal", new { id = id });
            }
            else
            {
                TempData["ProcessMessage"] = "Please Fill The On The Field Correctly.";
                TempData["displayModal"] = "myModal";
                return RedirectToAction("Animal", new { id = id });
            }
        }

        public IActionResult Administrator()
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View(_repository.GetAnimals());
        }

        public IActionResult SpecificAdministrator(int id)
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View("Administrator", _repository.GetAnimalsViaCategory(id));

        }

        public IActionResult EditAnimal(int id)
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View(_repository.GetAnimal(id));
        }

        [HttpPost]
        public IActionResult UpdatedAnimal(int id, Animal animal)
        {
            _repository.UpdateAnimal(id, animal);
            return RedirectToAction("Administrator");
        }
        public IActionResult DeleteAnimal(int id)
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            _repository.DeleteAnimal(id);
            return RedirectToAction("Administrator");
        }

        public IActionResult NewAnimal()
        {
            IEnumerable<Category> cat = _repository.GetCategories();
            ViewBag.Categories = cat;
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult AddNewAnimal(AnimalCreateViewModel viewModel)
        {
            if (viewModel.Name == null || viewModel.Age < 1 || viewModel.Description == null || viewModel.CategoryId == 0 || viewModel.Photo == null)
            {
                TempData["ProcessMessage"] = "Please Fill All The Fields Correctly.";
                TempData["displayModal"] = "myModal";
                return RedirectToAction("NewAnimal");
            }

            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/NewAnimals");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;
                string fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);
                string pathWithoutWWWroot = @"/images/NewAnimals/" + uniqueFileName;
                viewModel.Photo.CopyTo(new FileStream(fullFilePath, FileMode.Create));

                Animal newAnimal = new Animal
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    Description = viewModel.Description,
                    Picturename = pathWithoutWWWroot,
                    CategoryId = viewModel.CategoryId
                };
                _repository.InsertAnimal(newAnimal);
                return RedirectToAction("Administrator");
            }
            return View();
        }

    }
}
