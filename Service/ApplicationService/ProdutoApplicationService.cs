using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.DTO.AppContext;
using App.Domain.AppContext;
using App.Infrastructure.UnitOfWork.App;


namespace App.Service.ApplicationService
{
    public class ProdutoApplicationService
    {
        private readonly ProdutoUnitOfWork _uow;

        public ProdutoApplicationService(ProdutoUnitOfWork uow)
        {

            _uow = uow;
        }

        public ProdutoDto GetById(int id)
        {
            var query = _uow.ProdutoRepository.GetById(id);

            var dto = query.Select(x => new ProdutoDto
            {

                Id = x.Id,
                Nome = x.Nome,
            
            }).FirstOrDefault();



            return dto;
        }


        public List<ProdutoDto> GetAll()
        {                       

            var produtos = from p in _uow.ProdutoRepository.GetAll()
                           join c in _uow.CategoriaRepository.GetAll() on p.IdCategoria equals c.Id
                           select new
                           {
                               Id = p.Id,
                               Nome = p.Nome,
                               IdCategoria = p.IdCategoria,
                               Preco = p.Preco,
                               NomeCategoria = c.Nome,
                           };
           

            var dto = produtos.Select(x => new ProdutoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                IdCategoria = x.IdCategoria,
                Preco = x.Preco,
                NomeCategoria = x.NomeCategoria,

            }).ToList();


            return dto;
        }

        public void Update(ProdutoDto dto, int id)
        {
            var query = _uow.ProdutoRepository.GetById(id);

            var produto = query.FirstOrDefault();

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.IdCategoria = dto.IdCategoria;
            
            _uow.Commit();

        }

        public void Delete(int id)
        {
            var query = _uow.ProdutoRepository.GetById(id);
            var produto = query.FirstOrDefault();

            _uow.ProdutoRepository.Delete(produto);
            _uow.Commit();

        }

        public void Insert(ProdutoDto dto)
        {
            var Produtodb = new ProdutoDB
            {
                Nome = dto.Nome,
                IdCategoria = dto.IdCategoria,

            };

            _uow.ProdutoRepository.Add(Produtodb);
            _uow.Commit();

        }
    }
}
