using PetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWeb.DataAccess.Repository.IRepository;

namespace PetWeb.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update (Category category);

        void Save();
    }
}
