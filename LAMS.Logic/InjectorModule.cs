using AutoMapper;
using AutoMapper.Execution;
using FluentValidation;
using Ecology.Logic.Common.Services.Users;
using Ecology.Logic.Mappings.Users;
using Ecology.Logic.Services.Users;
using Ninject;
using Ninject.Modules;
using System.Reflection;
using LAMS.Logic.Services.Users;

namespace LAMS.Logic
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            BindValidators();
            BindMappers();

            BindLogsServices();
        }

        private void BindValidators()
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => Kernel.Bind(result.InterfaceType).To(result.ValidatorType).InTransientScope());
        }

        private void BindMappers()
        {

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<UserService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<RegistrationService>();



        }
        private void BindLogsServices()
        {

            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
