using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_DangHaiAnh.Models;

namespace Day3_DangHaiAnh.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" }
        };

        // GET: Category
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
            
        {
            var newCategory = new Category();
            if (ModelState.IsValid)
            {
                 newCategory = new Category
                {
                    Id = _categories.Count + 1,
                    Name = collection["Name"]
                };
                _categories.Add(newCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(newCategory);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
           var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                category.Name = collection["Name"];
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
