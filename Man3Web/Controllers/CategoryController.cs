using Man3Web.Data;
using Man3Web.Models;
using Microsoft.AspNetCore.Mvc;

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

   

    }
}
