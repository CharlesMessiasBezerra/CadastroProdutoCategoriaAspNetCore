using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using App.Service.ApplicationService;
using App.Common.DTO.AppContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Interface.Controllers
{
    [Route("api/categoria/")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaApplicationService _appService;

        public CategoriaController(CategoriaApplicationService appService)
        {
            _appService = appService;
        }

        [HttpGet("{id:int}")]
        public CategoriaDto geCategoria(int id)
        {
            return _appService.GetById(id);
                        
        }

        [HttpGet("")]
        public List<CategoriaDto> ListarCategoria()
        {
            return _appService.GetAll();
        }

        [HttpPost("")]
        public ActionResult Insert(CategoriaDto dto)
        {
            _appService.Insert(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(CategoriaDto dto, int id)
        {
            _appService.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _appService.Delete(id);
            return Ok();
        }
    }
}