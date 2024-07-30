using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;
using PetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetWeb.DataAccess.Repository
{
    public class CategoryRepository :Repository<Category> ,ICategoryRepository
    {
        private readonly ApplicationDbContext1 _applicationDbContext1;

        public CategoryRepository(ApplicationDbContext1 applicationDbContext1) : base(applicationDbContext1)
        {
            _applicationDbContext1 = applicationDbContext1;
        }

        public void Save()
        {
            _applicationDbContext1.SaveChanges();
        }

        public void Update(Category category)
        {
            _applicationDbContext1.Categories.Update(category);
        }
    }
}
