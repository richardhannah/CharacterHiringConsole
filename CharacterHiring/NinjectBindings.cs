using CharacterHiring;
using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.Configuration;
using CharacterHiring.NameGenerator.Configuration.Providers;
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