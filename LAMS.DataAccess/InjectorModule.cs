
using Ecology.DataAccess.Common.Repositories.Air;
using Ecology.DataAccess.Common.Repositories.Location;
using Ecology.DataAccess.Common.Repositories.Radiation;
using Ecology.DataAccess.Common.Repositories.Users;
using Ecology.DataAccess.Common.Repositories.Water;
using Ecology.DataAccess.Contexts;
using Ecology.DataAccess.Repositories.Air;
using Ecology.DataAccess.Repositories.Location;
using Ecology.DataAccess.Repositories.Radiation;
using Ecology.DataAccess.Repositories.Users;
using Ecology.DataAccess.Repositories.Water;
using Ninject.Modules;

namespace Ecology.DataAccess
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            Bind<DocContext>().ToSelf().InTransientScope();



            BindRepositories();
        }

        private void BindRepositories() { 

            Bind<IUserRepository>().To<UserRepository>();          
            Bind<IRadiationRepository>().To<RadiationRepository>();          
            Bind<ICityRepository>().To<CityRepository>();          
            Bind<IWaterObjectRepository>().To<WaterObjectRepository>();          
            Bind<IPmRepository>().To<PmRepository>();          
            Bind<ISeraRepository>().To<SeraRepository>();          
            Bind<IAzotRepository>().To<AzotRepository>();          
            Bind<IOzonRepository>().To<OzonRepository>();          
            Bind<IBioOxygenRepository>().To<BioOxygenRepository>();          
            Bind<IChemicalOxygenRepository>().To<ChemicalOxygenRepository>();          
            Bind<IPhRepository>().To<PhRepository>();          
        }
    }
}
