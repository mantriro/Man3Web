using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Man3Web.DataAccess.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        //T- will be Category or any db context interacting object doing CRUD

        IEnumerable<T> GetAll ();

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        //void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

         
    
    
    }
}
