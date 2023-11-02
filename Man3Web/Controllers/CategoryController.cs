using Man3Web.DataAccess.Data;
using Man3Web.DataAccess.Repository.IRepository;
using Man3Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Man3Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> objCatList = _categoryRepo.GetAll().ToList();    
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
            if (obj.Name.ToLower() == "test" || obj.Name == null)
            {
                ModelState.AddModelError("", "test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0) {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.CategoryId==categoryId);//find only works on primary key
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
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";

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
            Category categoryFromDb = _categoryRepo.Get(u=>u.CategoryId==categoryId);//find only works on primary key
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
            Category ob = _categoryRepo.Get(u => u.CategoryId == categoryId);
            if (ob == null) {
                return NotFound();
            }
            
                _categoryRepo.Remove(ob);
                _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index", "Category");
        }
    }
}
