namespace CharacterHiring.NameGenerator;

public interface IConfigFactory
{
    Configuration GetConfig(Type configType);
}

public class ConfigFactory : IConfigFactory
{
    private readonly IConfigProvider _configProvider;

    public ConfigFactory(IConfigProvider configProvider)
    {
        _configProvider = configProvider;
    }

    public Configuration GetConfig(Type configType)
    {
        return _configProvider.LoadConfiguration();
    }
}