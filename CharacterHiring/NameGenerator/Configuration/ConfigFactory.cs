using CharacterHiring.NameGenerator.Configuration.Providers;
using CharacterHiring.NameGenerator.NameTypes;

namespace CharacterHiring.NameGenerator.Configuration;

public interface IConfigFactory
{
    Configuration GetConfig<T>();
}

public class ConfigFactory : IConfigFactory
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