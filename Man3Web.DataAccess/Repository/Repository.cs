﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Man3Web.DataAccess.Data;
using Man3Web.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace Man3Web.DataAccess.Repository
{
    public class Repository <T>: IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet= _db.Set<T>(); //==> _db.Categories = dbSet; _db.Categories.Add(obj) ==> dbSet.Add()
           
        }

        public void Add(T entity) {
            dbSet.Add(entity);
            //throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query=query.Where(filter);
            return query.FirstOrDefault();
           //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
            //throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            //throw new NotImplementedException();
        }
    }
}
