using Autofac;
using CharacterHiring.domain;
using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.Configuration;
using CharacterHiring.domain.NameGenerator.Configuration.Providers;

namespace CharacterHiring;

public class AutofacBindings : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CharacterMarket>().As<ICharacterMarket>();
        builder.RegisterGeneric(typeof(NameFactory<>)).As(typeof(INameFactory<>));
        builder.RegisterType<ConfigFactory>().As<IConfigFactory>();
        builder.RegisterType<DefaultConfigProvider>().As<IConfigProvider>();
        builder.RegisterType<CharacterFactory>().As<ICharacterFactory>();
        builder.RegisterType<CharacterStore>().As<ICharacterStore>();
    }
}