using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;

namespace PetWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext1 _applicationDbContext1;

        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext1 applicationDbContext1)
        {
            _applicationDbContext1 = applicationDbContext1;
            _dbSet = _applicationDbContext1.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //IQueryable<T> query = _dbSet;
            //query = _dbSet.Where(filter);
            //return query.FirstOrDefault();

            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();



        }

        public IEnumerable<T> GetAll()
        {
            //IQueryable<T> query = _dbSet;
            //return query.ToList();


             return _dbSet.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
