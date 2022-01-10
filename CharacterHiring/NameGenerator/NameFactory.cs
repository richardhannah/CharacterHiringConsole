using CharacterHiring.NameGenerator.Configuration;

namespace CharacterHiring.NameGenerator;

public class NameFactory<T> : INameFactory<T>
{
    private readonly Configuration.Configuration _config;
    private readonly IConfigFactory _configFactory;

    public NameFactory(IConfigFactory configFactory)
    {
        _configFactory = configFactory;
        _config = _configFactory.GetConfig<T>();

        if (typeof(T) != _config.ConfigType)
        {
            throw new ArgumentException($"Invalid configuration: {typeof(T)} is required");
        }
    }

    public T Build()
    {
        return (T) Activator.CreateInstance(typeof(T), GenerateName());
    }

    private NameData GenerateName()
    {
        var rand = new Random();
        var nameData = new Dictionary<string, string>();

        foreach (var key in _config.NameLists.Keys)
        {
            nameData[key] = _config.NameLists[key][rand.Next(0, _config.NameLists[key].Count)];
        }

        return new NameData
        {
            NameDict = nameData
        };
    }
}