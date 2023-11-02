using Man3Web.DataAccess.Data;
using Man3Web.DataAccess.Repository.IRepository;
using Man3Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Man3Web.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        { 
            _db=db;
        }


        public void Save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            //throw new NotImplementedException();
        }
    }
}
