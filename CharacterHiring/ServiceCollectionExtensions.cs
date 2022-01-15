using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.Configuration;
using CharacterHiring.NameGenerator.Configuration.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace CharacterHiring;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCharacterHiring(this IServiceCollection services)
    {
        return services.AddSingleton<ICharacterMarket, CharacterMarket>()
            .AddSingleton(typeof(INameFactory<>), typeof(NameFactory<>))
            .AddSingleton(typeof(IConfigFactory), typeof(ConfigFactory))
            .AddSingleton(typeof(IConfigProvider), typeof(DefaultConfigProvider))
            .AddSingleton(typeof(ICharacterFactory), typeof(CharacterFactory))
            .AddSingleton(typeof(ICharacterStore), typeof(CharacterStore));
    }
}