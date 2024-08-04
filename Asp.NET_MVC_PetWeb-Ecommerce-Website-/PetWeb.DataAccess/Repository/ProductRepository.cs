using PetWeb.DataAccess.Data;
using PetWeb.DataAccess.Repository.IRepository;
using PetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWeb.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext1 _applicationDbContext1;

        public ProductRepository(ApplicationDbContext1 applicationDbContext1) : base(applicationDbContext1)
        {
            _applicationDbContext1 = applicationDbContext1;
        }

        public void Update(Product product)
        {
            _applicationDbContext1.Products.Update(product);
        }
    }
}
