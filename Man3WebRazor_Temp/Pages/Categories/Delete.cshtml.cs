using Man3WebRazor_Temp.Data;
using Man3WebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Man3WebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                            
            }
            Category = _db.Categories.Find(categoryId);//find only works on primary key

            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.CategoryId==id);
            //Category categoryFromDb2 = _db.Categories.Where(u=>u.CategoryId==id).FirstOrDefault();

            //if (categoryFromDb == null)
            //{
            //    //return NotFound();

            //}

           // return View(categoryFromDb);

        }

        public IActionResult OnPost(int categoryId)
        {
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";

            return RedirectToPage("Index");
        }
    }
}

