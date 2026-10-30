using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_DangHaiAnh.Models;
namespace Day3_DangHaiAnh.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _Product=new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0, Description = "Description 1", CategoryId = 1 },
            new Product { Id = 2, Name = "Product 2", Price = 20.0, Description = "Description 2", CategoryId = 2 },
            new Product { Id = 3, Name = "Product 3", Price = 30.0, Description = "Description 3", CategoryId = 3 }
        };
        // GET: ProductController
        public ActionResult Index()
        {
           
           return View(_Product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var newProduct = new Product();
            if (ModelState.IsValid)
            {
                newProduct = new Product
                {
                    Id = _Product.Count + 1,
                    Name = collection["Name"],
                    Price = double.Parse(collection["Price"]),
                    Description = collection["Description"],
                    CategoryId = int.Parse(collection["CategoryId"])
                };
            }
            ;
            return View(newProduct);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _Product.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var product = _Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                product.Name = collection["Name"];
                product.Price = double.Parse(collection["Price"]);
                product.Description = collection["Description"];
                product.CategoryId = int.Parse(collection["CategoryId"]);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var product = _Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();

            }
            _Product.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
