namespace CharacterHiring.NameGenerator;

public class NameFactory<T> : INameFactory<T>
{
    private readonly Configuration _config;

    public NameFactory(Configuration config)
    {
        _config = config;
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
            nameData[key] = _config.NameLists[key][rand.Next(0, _config.NameLists[key].Count)];

        return new NameData
        {
            NameDict = nameData
        };
    }
}