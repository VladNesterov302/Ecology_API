
using Ecology.DataAccess.Common.Repositories.Users;
using Ecology.DataAccess.Contexts;
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

            Bind<DocContext>().ToSelf().InTransientScope();



            BindRepositories();
        }

        private void BindRepositories() { 

            Bind<IUserRepository>().To<UserRepository>();          
        }
    }
}
