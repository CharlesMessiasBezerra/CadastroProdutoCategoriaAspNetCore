using App.Infrastructure.Model;
using App.Infrastructure.Repository.Base;
using System.Linq;
using App.Domain.AppContext;

namespace App.Infrastructure.Repository.AppContext
{
    public class ProdutoRepository : GenericRepository<ProdutoDB, Banco>
    {
        public ProdutoRepository(Banco context) : base(context)
        {

        }

        public IQueryable<ProdutoDB> GetById(int id)
        {
            return _context.ProdutoDB.Where(x => x.Id == id);
        }

        //public IQueryable<ProdutoDB> GetProduto(int id)
        //{

        //    var produros = from p in _context.ProdutoDB
        //                      join c in _context.CategoriaDB on p.IdCategoria equals c.Id
        //                        select new
        //                        {
        //                            Id = p.Id,
        //                            Nome = p.Nome,
        //                            IdCategoria = p.IdCategoria,
        //                            Preco = p.Preco,
        //                            NomeCategoria = c.Nome,                                                                            
        //                        };

        //    return produros.IQueryable();

        //}




    }
}