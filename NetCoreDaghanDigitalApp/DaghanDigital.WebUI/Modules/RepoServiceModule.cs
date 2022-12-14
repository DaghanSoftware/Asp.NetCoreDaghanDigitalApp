using Autofac;
using DaghanDigital.Core.Repositories;
using DaghanDigital.Core.Services;
using DaghanDigital.Core.UnitOfWorks;
using DaghanDigital.Repository;
using DaghanDigital.Repository.Repositories;
using DaghanDigital.Repository.UnitOfWorks;
using DaghanDigital.Service.Mapping;
using DaghanDigital.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace DaghanDigital.WebUI.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();



        }
    }

}
