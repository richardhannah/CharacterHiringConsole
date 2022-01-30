using CharacterHiring;
using CharacterHiring.domain;
using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.Configuration;
using CharacterHiring.domain.NameGenerator.Configuration.Providers;
using Ninject.Modules;

namespace CharacterHiringConsole;

public class NinjectBindings : NinjectModule
{
    public override void Load()
    {
        Bind<ICharacterMarket>().To<CharacterMarket>();
        Bind(typeof(INameFactory<>)).To(typeof(NameFactory<>));
        Bind<IConfigFactory>().To<ConfigFactory>();
        Bind<IConfigProvider>().To<DefaultConfigProvider>();
        Bind<ICharacterFactory>().To<CharacterFactory>();
        Bind<ICharacterStore>().To<CharacterStore>();
    }
}