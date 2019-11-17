
using System;
using App.Infrastructure.Model;
using App.Infrastructure.UnitOfWork.Base;
using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.Repository.AppContext;

namespace App.Infrastructure.UnitOfWork.App
{
    public class ProdutoUnitOfWork : GenericUnitOfWork
    {
        public ProdutoRepository ProdutoRepository => _serviceProvider.GetService<ProdutoRepository>();
        public CategoriaRepository CategoriaRepository => _serviceProvider.GetService<CategoriaRepository>();


        public ProdutoUnitOfWork(Banco context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {

        }
    }
}
