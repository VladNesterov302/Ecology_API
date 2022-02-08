﻿
using Ecology.DataAccess.Common.Repositories.Air;
using Ecology.DataAccess.Common.Repositories.Location;
using Ecology.DataAccess.Common.Repositories.Radiation;
using Ecology.DataAccess.Common.Repositories.Users;
using Ecology.DataAccess.Contexts;
using Ecology.DataAccess.Repositories.Air;
using Ecology.DataAccess.Repositories.Location;
using Ecology.DataAccess.Repositories.Radiation;
using Ecology.DataAccess.Repositories.Users;
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

            Bind<DocContext>().ToSelf().InSingletonScope();



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
        }
    }
}
