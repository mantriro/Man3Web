using Man3Web.Data;
using Man3Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Man3Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {

            List<Category> objCatList= _db.Categories.ToList();    
            return View(objCatList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name", "Display Order cannot exactly match Name");
            }
            if (obj.Name == "test" || obj.Name != null)
            {
                ModelState.AddModelError("", "test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0) {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(categoryId);//find only works on primary key
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //Category categoryFromDb2 = _db.Categories.Where(u=>u.CategoryId==id).FirstOrDefault();

            if (categoryFromDb == null) {
                return NotFound();

            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(categoryId);//find only works on primary key
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //Category categoryFromDb2 = _db.Categories.Where(u=>u.CategoryId==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();

            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? categoryId)
        {
            Category ob = _db.Categories.Find(categoryId);
            if (ob == null) {
                return NotFound();
            }
            
                _db.Categories.Remove(ob);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
        }
    }
}
