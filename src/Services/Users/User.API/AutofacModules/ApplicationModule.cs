using Users.API.Queries;
using Users.Application.Queries;

namespace Users.API.AutofacModules;

public class ApplicationModule
    : Autofac.Module
{
    private readonly string _queriesConnectionString;

    public ApplicationModule(string queriesConnectionString)
    {
        _queriesConnectionString = queriesConnectionString ?? throw new ArgumentNullException(nameof(queriesConnectionString));
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<UserRepository>()
            .As<IUserRepository>()
            .AutoActivate();

        builder
            .Register(c => new UserQueries(_queriesConnectionString))
            .As<IUserQueries>()
            .InstancePerLifetimeScope();
    }
}
