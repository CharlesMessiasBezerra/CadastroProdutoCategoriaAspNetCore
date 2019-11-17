using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.DTO.AppContext;
using App.Domain.AppContext;
using App.Infrastructure.UnitOfWork.App;


namespace App.Service.ApplicationService
{
    public class CategoriaApplicationService
    {
        private readonly CategoriaUnitOfWork _uow;

        public CategoriaApplicationService(CategoriaUnitOfWork uow)
        {

            _uow = uow;
        }

        public CategoriaDto GetById(int id)
        {
            var query = _uow.CategoriaRepository.GetById(id);

            var dto = query.Select(x => new CategoriaDto
            {

              
                Nome = x.Nome,
                
            }).FirstOrDefault();



            return dto;
        }


        public List<CategoriaDto> GetAll()
        {
            var query = _uow.CategoriaRepository.GetAll();

            var dto = query.Select(x => new CategoriaDto
            {
                Id = x.Id,
                Nome = x.Nome,
                
            }).ToList();


            return dto;
        }

        public void Update(CategoriaDto dto, int id)
        {
            var query = _uow.CategoriaRepository.GetById(id);

            var categoria = query.FirstOrDefault();

            categoria.Nome = dto.Nome;
            _uow.Commit();

        }

        public void Delete(int id)
        {
            var query = _uow.CategoriaRepository.GetById(id);
            var categoria = query.FirstOrDefault();

            _uow.CategoriaRepository.Delete(categoria);
            _uow.Commit();

        }

        public void Insert(CategoriaDto dto)
        {
            var categoriadb = new CategoriaDB
            {
                Nome = dto.Nome,

            };

            _uow.CategoriaRepository.Add(categoriadb);
            _uow.Commit();

        }
    }
}
