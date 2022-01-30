using CharacterHiring.domain.NameGenerator.Configuration.Providers;
using CharacterHiring.domain.NameGenerator.NameTypes;

namespace CharacterHiring.domain.NameGenerator.Configuration;

public interface IConfigFactory
{
    Configuration GetConfig<T>();
}

internal class ConfigFactory : IConfigFactory
{
    private readonly IConfigProvider _configProvider;

    public ConfigFactory(IConfigProvider configProvider)
    {
        _configProvider = configProvider;
    }

    public Configuration GetConfig<T>()
    {
        if (typeof(T) == typeof(CharacterName))
        {
            return _configProvider.LoadConfiguration();
        }

        throw new ArgumentException($"No config provider found for {typeof(T)}");
    }
}