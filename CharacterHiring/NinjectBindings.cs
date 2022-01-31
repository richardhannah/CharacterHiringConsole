using CharacterHiring;
using CharacterHiring.domain;
using CharacterHiring.domain.Attributes;
using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.Configuration;
using Ninject.Modules;

namespace CharacterHiringConsole;

public class NinjectBindings : NinjectModule
{
    public override void Load()
    {
        Bind<ICharacterMarket>().To<CharacterMarket>();
        Bind(typeof(INameFactory<>)).To(typeof(NameFactory<>));
        Bind<IConfigFactory>().To<ConfigFactory>();
        Bind<ICharacterFactory>().To<CharacterFactory>();
        Bind<ICharacterStore>().To<CharacterStore>();
        Bind<IAttributeFactory>().To<AttributeFactory>();
    }
}