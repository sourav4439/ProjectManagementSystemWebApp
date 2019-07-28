using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data.Interfaces;

namespace ProjectManagementSystem.Data.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected readonly AppDbContext db;

        public Repository(AppDbContext dbContext)
        {
           db=dbContext;
        }
        public int Count(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate).Count();

        }


        public void Create(T entity)
        {
            db.Add(entity);
            Save();
        }
        public void Delete(T entity)
        {
            db.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }



        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            Save();
        }

        protected void Save()
        {
            db.SaveChanges();
        }
    }
}
