using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext1 _applicationDbContext1;

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext1 applicationDbContext1)
        {
            _applicationDbContext1 = applicationDbContext1;
            Category = new CategoryRepository (_applicationDbContext1);
        }

        

        public void Save()
        {
            _applicationDbContext1.SaveChanges();
        }
    }
}
