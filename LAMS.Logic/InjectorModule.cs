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
using Ecology.Logic.Common.Services.Radiation;
using Ecology.Logic.Services.Radiation;
using Ecology.Logic.Common.Services.Location;
using Ecology.Logic.Services.Location;
using Ecology.Logic.Services.Air;
using Ecology.Logic.Common.Services.Air;
using Ecology.Logic.Mappings.Radiation;
using Ecology.Logic.Mappings.Location;
using Ecology.Logic.Mappings.Air;
using Ecology.Logic.Common.Services.Water;
using Ecology.Logic.Services.Water;
using Ecology.Logic.Mappings.Water;
using Ecology.Logic.Mappings.Statistic;

namespace Ecology.Logic
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

            BindServices();
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

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<RadiationProfile>();
                    cfg.AddProfile<CityProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<RadiationStatisticProfile>();
                    cfg.AddProfile<LevelStatisticProfile>();
                })))
                .WhenInjectedExactlyInto<RadiationService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CityProfile>();
                })))
                .WhenInjectedExactlyInto<CityService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<WaterObjectProfile>();
                })))
                .WhenInjectedExactlyInto<WaterObjectService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AzotProfile>();
                    cfg.AddProfile<CityProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<LevelStatisticProfile>();
                })))
                .WhenInjectedExactlyInto<AzotService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OzonProfile>();
                    cfg.AddProfile<CityProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<LevelStatisticProfile>();
                })))
                .WhenInjectedExactlyInto<OzonService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PmProfile>();
                    cfg.AddProfile<CityProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<LevelStatisticProfile>();
                })))
                .WhenInjectedExactlyInto<PmService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<SeraProfile>();
                    cfg.AddProfile<CityProfile>();
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<LevelStatisticProfile>();
                })))
                .WhenInjectedExactlyInto<SeraService>();

            Bind<IMapper>().ToMethod(ctx =>
               new Mapper(new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<BioOxygenProfile>();
                   cfg.AddProfile<WaterObjectProfile>();
                   cfg.AddProfile<UserProfile>();
                   cfg.AddProfile<LevelStatisticProfile>();
               })))
               .WhenInjectedExactlyInto<BioOxygenService>();

            Bind<IMapper>().ToMethod(ctx =>
               new Mapper(new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<ChemicalOxygenProfile>();
                   cfg.AddProfile<WaterObjectProfile>();
                   cfg.AddProfile<UserProfile>();
                   cfg.AddProfile<LevelStatisticProfile>();
               })))
               .WhenInjectedExactlyInto<ChemicalOxygenService>();

            Bind<IMapper>().ToMethod(ctx =>
               new Mapper(new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<PhProfile>();
                   cfg.AddProfile<WaterObjectProfile>();
                   cfg.AddProfile<UserProfile>();
                   cfg.AddProfile<LevelStatisticProfile>();
               })))
               .WhenInjectedExactlyInto<PhService>();

        }
        private void BindServices()
        {

            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IUserService>().To<UserService>();
            Bind<IRadiationService>().To<RadiationService>();
            Bind<ICityService>().To<CityService>();
            Bind<IWaterObjectService>().To<WaterObjectService>();
            Bind<IAzotService>().To<AzotService>();
            Bind<IOzonService>().To<OzonService>();
            Bind<IPmService>().To<PmService>();
            Bind<ISeraService>().To<SeraService>();
            Bind<IBioOxygenService>().To<BioOxygenService>();
            Bind<IChemicalOxygenService>().To<ChemicalOxygenService>();
            Bind<IPhService>().To<PhService>();
        }
    }
}
