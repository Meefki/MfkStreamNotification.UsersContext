using Autofac.Builder;

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
            .InstancePerLifetimeScope()
            .CreateRegistration();
    }
}
