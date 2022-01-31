using Autofac;
using CharacterHiring.domain;
using CharacterHiring.domain.Attributes;
using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.Configuration;

namespace CharacterHiring;

public class AutofacBindings : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CharacterMarket>().As<ICharacterMarket>();
        builder.RegisterGeneric(typeof(NameFactory<>)).As(typeof(INameFactory<>));
        builder.RegisterType<ConfigFactory>().As<IConfigFactory>();
        builder.RegisterType<CharacterFactory>().As<ICharacterFactory>();
        builder.RegisterType<CharacterStore>().As<ICharacterStore>();
        builder.RegisterType<AttributeFactory>().As<IAttributeFactory>();
    }
}