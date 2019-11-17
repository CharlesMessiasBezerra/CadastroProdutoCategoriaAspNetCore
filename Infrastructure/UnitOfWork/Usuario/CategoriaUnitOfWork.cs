
using System;
using App.Infrastructure.Model;
using App.Infrastructure.UnitOfWork.Base;
using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.Repository.AppContext;

namespace App.Infrastructure.UnitOfWork.App
{
    public class CategoriaUnitOfWork : GenericUnitOfWork
    {
        public CategoriaRepository CategoriaRepository => _serviceProvider.GetService<CategoriaRepository>();

        public CategoriaUnitOfWork(Banco context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {

        }
    }
}
