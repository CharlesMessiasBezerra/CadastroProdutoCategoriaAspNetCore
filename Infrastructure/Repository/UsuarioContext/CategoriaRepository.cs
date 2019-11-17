using App.Infrastructure.Model;
using App.Infrastructure.Repository.Base;
using System.Linq;
using App.Domain.AppContext;

namespace App.Infrastructure.Repository.AppContext
{
    public class CategoriaRepository : GenericRepository<CategoriaDB, Banco>
    {
        public CategoriaRepository(Banco context) : base(context)
        {

        }

        public IQueryable<CategoriaDB> GetById(int id)
        {
            return _context.CategoriaDB.Where(x => x.Id == id);
        }


    }
}